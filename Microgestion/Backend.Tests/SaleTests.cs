using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Backend.Extensions;
using SysQ.Microgestion.Backend.Entities;

namespace Backend.Tests
{
    /// <summary>
    /// Summary description for SaleTests
    /// </summary>
    [TestClass]
    public class SaleTests
    {
        public SaleTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        
        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            string username = "test";
            string password = "test".GetMD5Hash();
            
            Assert.IsTrue(UserService.ValidateUser(username, password));
        }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void SimpleSale()
        {
            var items = ItemService.GetAll(i => i.Name);
            Assert.IsTrue(items.Count >= 3);

            Sale newSale = new Sale
            {
                Date = DateTime.Now,
                UserID = UserService.LoggedInUser.ID,
                InternalID = SaleService.GetNextNumber()
            };

            newSale.Details.Add(new SaleDetail
            {
                ItemID = items[0].ID,
                Price = items[0].CurrentPrice,
                Amount = 10,
                Subtotal = items[0].CurrentPrice.Value * 10
            });
            newSale.Details.Add(new SaleDetail
            {
                ItemID = items[1].ID,
                Price = items[1].CurrentPrice,
                Amount = 10,
                Subtotal = items[1].CurrentPrice.Value * 10
            });
            newSale.Details.Add(new SaleDetail
            {
                ItemID = items[2].ID,
                Price = items[2].CurrentPrice,
                Amount = 10,
                Subtotal = items[2].CurrentPrice.Value * 10
            });

            newSale.Total = newSale.Details.Sum(i => i.Subtotal);

            SaleService.Save(newSale);

            Sale savedSale = SaleService.GetByID(newSale.ID);

            Assert.AreEqual(newSale.Date, savedSale.Date);
            Assert.AreEqual(newSale.InternalID, savedSale.InternalID);
            Assert.AreEqual(newSale.Total, savedSale.Total);
            Assert.AreEqual(newSale.UserID, savedSale.UserID);

            foreach (var i in newSale.Details)
            {
                SaleDetail d = savedSale.Details.Where(x => x.ID.Equals(i.ID)).SingleOrDefault();
                Assert.IsNotNull(d);

                Assert.AreEqual(i.ItemID, d.ItemID);
                Assert.AreEqual(i.PriceID, d.PriceID);
                Assert.AreEqual(i.Amount, d.Amount);
                Assert.AreEqual(i.Subtotal, d.Subtotal);
            }

        }

        [TestMethod]
        public void SaleWithStockMovement()
        {
            var items = ItemService.GetAll(i => i.Name);
            Assert.IsTrue(items.Count >= 3);

            Sale newSale = new Sale
            {
                Date = DateTime.Now,
                UserID = UserService.LoggedInUser.ID,
                InternalID = SaleService.GetNextNumber()
            };

            newSale.Details.Add(new SaleDetail
            {
                ItemID = items[0].ID,
                Price = items[0].CurrentPrice,
                Amount = 10,
                Subtotal = items[0].CurrentPrice.Value * 10
            });
            newSale.Details.Add(new SaleDetail
            {
                ItemID = items[1].ID,
                Price = items[1].CurrentPrice,
                Amount = 10,
                Subtotal = items[1].CurrentPrice.Value * 10
            });

            newSale.Total = newSale.Details.Sum(i => i.Subtotal);

            SaleService.Save(newSale);

            List<StockMovementDetail> stockDetail = new List<StockMovementDetail>();
            foreach (var i in newSale.Details)
            {
                if (i.Item.MovesStock)
                {
                    stockDetail.Add(new StockMovementDetail
                    {
                        ItemID = i.ItemID,
                        Amount = i.Amount,
                        SaleDetailID = i.ID
                    });
                }
            }

            if (stockDetail.Count > 0)
            {
                StockMovement stockMovement = new StockMovement
                {
                    Date = DateTime.Now,
                    Comment  = String.Format("Generated from Sale #{0}", newSale.InternalID),
                    UserID = UserService.LoggedInUser.ID
                };

                stockMovement.Details.AddRange(stockDetail);

                StockMovementService.Save(stockMovement);

                StockMovement savedStockMovement = StockMovementService.GetByID(stockMovement.ID);

                Assert.AreEqual(stockMovement.Date, savedStockMovement.Date);
                Assert.AreEqual(stockMovement.Comment, savedStockMovement.Comment);
                Assert.AreEqual(stockMovement.UserID, savedStockMovement.UserID);

                foreach (var i in stockMovement.Details)
                {
                    StockMovementDetail d = savedStockMovement.Details.Where(x => x.ID.Equals(i.ID)).SingleOrDefault();
                    Assert.IsNotNull(d);

                    Assert.AreEqual(i.ItemID, d.ItemID);
                    Assert.AreEqual(i.Amount, d.Amount);
                    Assert.AreEqual(i.SaleDetailID, d.SaleDetailID);
                }
            }

        }

    }
}

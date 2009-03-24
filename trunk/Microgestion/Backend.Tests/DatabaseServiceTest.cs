using System;
using System.Collections.Generic;
using Blackspot.Microgestion.Backend.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Enumerations;
using Blackspot.Microgestion.Backend.Extensions;

namespace Backend.Tests
{
    
    
    /// <summary>
    ///This is a test class for DatabaseServiceTest and is intended
    ///to contain all DatabaseServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatabaseServiceTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SetupDatabase
        ///</summary>
        [TestMethod]
        //[Ignore]
        public void SetupDatabaseTest()
        {
            DatabaseService.SetupDatabase();
        }

        /// <summary>
        /// Initializes data in the database
        /// </summary>
        [TestMethod]
        public void InitializeData()
        {
            Role vendedor = new Role { Name = "Vendedor" };
            vendedor.Actions.Add(new RoleAction { Action = SystemAction.Sales });
            RoleService.Save(vendedor);

            User testuser = new User
            {
                Username = "test",
                Name = "test",
                LastName = "test",
                Password = "test".GetMD5Hash()
            };
            
            UserService.Save(testuser);

            UserService.Update(testuser, new List<Role> { vendedor });

            Measurement units = new Measurement { Name = "Unidad/es", Abbreviation = "Un." };
            MeasurementService.Save(units);

            ItemType cigarrillos = new ItemType { Name = "Cigarrillos" };
            ItemTypeService.Save(cigarrillos);

            Item item1 = new Item
            {
                Name = "Marlboro Box 10",
                InternalCode = "321",
                ExternalCode = "321",
                ItemTypeID = cigarrillos.ID,
                BaseMeasurementID = units.ID,
                MovesStock = true,
                MinimumStock = 10
            };
            item1.CurrentPrice = new Price
            {
                Date = DateTime.Now,
                Value = 2.5
            };

            Item item2 = new Item
            {
                Name = "Marlboro Box 20",
                InternalCode = "987",
                ExternalCode = "987",
                ItemTypeID = cigarrillos.ID,
                BaseMeasurementID = units.ID,
                MovesStock = true,
                MinimumStock = 10
            };
            item2.CurrentPrice = new Price
            {
                Date = DateTime.Now,
                Value = 5
            };
            Item item3 = new Item
            {
                Name = "Marlboro Comun 20",
                InternalCode = "654",
                ExternalCode = "654",
                ItemTypeID = cigarrillos.ID,
                BaseMeasurementID = units.ID,
                MovesStock = true,
                MinimumStock = 10
            };
            item3.CurrentPrice = new Price
            {
                Date = DateTime.Now,
                Value = 4.5
            };

            ItemService.Save(item1);
            ItemService.Save(item2);
            ItemService.Save(item3);
        }
    }
}

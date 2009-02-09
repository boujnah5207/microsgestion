using Blackspot.Microgestion.Backend.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Blackspot.Microgestion.Backend.Entities;
using System.Collections.Generic;

namespace Backend.Tests
{
    
    
    /// <summary>
    ///This is a test class for UserServiceTest and is intended
    ///to contain all UserServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserServiceTest
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
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestInitialize()]
        public void MyTestInitialize()
        {
            User admin = UserService.GetAdminUser();
            UserService.LoggedInUser = admin;
        }

        /// <summary>
        ///A test for LoggedInUser
        ///</summary>
        [TestMethod()]
        public void LoggedInUserTest()
        {
            User expected = UserService.GetAdminUser();
            User actual;
            UserService.LoggedInUser = expected;
            actual = UserService.LoggedInUser;
            Assert.AreEqual(expected.ID, actual.ID);
        }


        /// <summary>
        ///A test for GetAllUsers
        ///</summary>
        [TestMethod()]
        public void GetAllUsersTest()
        {
            IEnumerable<User> users;
            users = UserService.GetAll<User>();

            foreach (User u in users)
                Assert.IsInstanceOfType(u, typeof(User));
        }

        [TestMethod]
        public void CRUD_User()
        {
            // Create

            User expected = new User()
            {
                Name = "Test",
                LastName = "Test",
                Username = "Test",
                Password = "Test"
            };

            Assert.AreEqual(expected.ID, Guid.Empty);

            UserService.Save(expected);

            Assert.AreNotEqual(expected.ID, Guid.Empty);

            User actual = UserService.GetByID<User>(expected.ID);

            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.Password, actual.Password);

            // Update

            expected.Name = "Test2";
            expected.LastName = "Test2";
            expected.Username = "Test2";
            expected.Password = "Test2";

            UserService.Update(expected);

            actual = UserService.GetByID<User>(expected.ID);

            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.Password, actual.Password);


            // Delete

            UserService.Delete(expected);

            actual = UserService.GetByID<User>(expected.ID);

            Assert.IsNull(actual);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldData.Models;
using System;

namespace WorldData.Tests
{

    [TestClass]
    public class WorldDataTests : IDisposable
    {
        public void Dispose()
        {
            Country.DeleteAll();
        }
        public WorldDataTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=world_test;";
        }
        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
          //Arrange
          //Act
          int result = Country.GetAll().Count;

          //Assert
          Assert.AreEqual(0, result);
        }
    }
}

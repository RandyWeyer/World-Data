using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldData.Models;
using System.Collections.Generic;
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

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Country()
    {
      // Arrange, Act
      Country firstCountry = new Country("Mow the lawn", 1F, 1, "poop");
      Country secondCountry = new Country("Mow the lawn", 1F, 1, "poop");

      // Assert
      Assert.AreEqual(firstCountry, secondCountry);
    }

    [TestMethod]
    public void Save_SavesToDatabase_CountryList()
    {
      //Arrange
      Country testCountry = new Country("Mow the lawn", 1F, 1, "poop");

      //Act
      testCountry.Save();
      List<Country> result = Country.GetAll();
      List<Country> testList = new List<Country>{testCountry};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}

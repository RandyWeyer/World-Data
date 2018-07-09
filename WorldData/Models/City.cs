using System.Collections.Generic;
using System;
using WorldData;
using MySql.Data.MySqlClient;

namespace WorldData.Models
{
  public class City
  {
    private string _name;
    private string _district;
    private int _population;

    public City(string name, string district, int population)
    {
       _name = name;
       _district = district;
       _population = population;
    }

    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetDistrict()
    {
      return _district;
    }
    public void SetDistrict(string newDistrict)
    {
      _district = newDistrict;
    }
    public int GetPopulation()
    {
      return _population;
    }
    public void SetPopulation(int newPopulation)
    {
      _population = newPopulation;
    }

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city ORDER BY name;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        string name = rdr.GetString(1);
        string district = rdr.GetString(3);
        int population = rdr.GetInt32(4);
        City newCity = new City(name, district, population);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allCities;
    }
  }
}

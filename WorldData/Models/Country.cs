using System.Collections.Generic;
using System;
using WorldData;
using MySql.Data.MySqlClient;

namespace WorldData.Models
{
  public class Country
  {
    private string _name;
    private float _surfaceArea;
    private int _population;
    private string _government;

    // Constructors
    public Country (string name, float surfaceArea, int population, string government)
    {
      _name = name;
      _surfaceArea = surfaceArea;
      _population = population;
      _government = government;
    }

    // Getters and Setters
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public float GetSurfaceArea()
    {
      return _surfaceArea;
    }
    public void SetSurfaceArea(float newSurfaceArea)
    {
      _surfaceArea = newSurfaceArea;
    }
    public int GetPopulation()
    {
      return _population;
    }
    public void SetPopulation(int newPopulation)
    {
      _population = newPopulation;
    }
    public string GetGovernment()
    {
      return _government;
    }
    public void SetGovernment(string newGovernment)
    {
      _government = newGovernment;
    }


    // Methods
    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string name = rdr.GetString(1);
        float surfaceArea = rdr.GetFloat(4);
        int population = rdr.GetInt32(6);
        string government = rdr.GetString(11);
        Country newCountry = new Country(name, surfaceArea, population, government);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allCountries;
    }

    public static List<Country> SearchCountries(string searchable, string userInput)
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country WHERE "+searchable+" LIKE '%" +userInput+"%';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string name = rdr.GetString(1);
        float surfaceArea = rdr.GetFloat(4);
        int population = rdr.GetInt32(6);
        string government = rdr.GetString(11);
        Country newCountry = new Country(name, surfaceArea, population, government);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allCountries;
    }
    public static void DeleteAll()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM country;";
          cmd.ExecuteNonQuery();
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
        }
  }
}

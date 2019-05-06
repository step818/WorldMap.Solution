using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WorldMap.Models
{
  public class Country
  {
      private string _code;
      private string _name;
      private string _region;
      private double _lifeExpectancy;
      private string _govtForm;

      public Country(string code, string name, string region, double lifeExpectancy, string govtForm)
      {
          _code= code;
          _name = name;
          _region = region;
          _lifeExpectancy = lifeExpectancy;
          _govtForm = govtForm;
      }
      public string GetCode()
      {
          return _code;
      }
      public string GetName()
      {
          return _name;
      }
      public string GetRegion()
      {
          return _region;
      }
      public double GetLifeExpectancy()
      {
          return _lifeExpectancy;
      }
      public string GetGovtForm()
      {
          return _govtForm;
      }
    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};     
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT Code, Name, region, lifeexpectancy, governmentform FROM country where LifeExpectancy is not null order by name;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string countrycode = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        string region = rdr.GetString(2);
        double lifeExpectancy = rdr.GetDouble(3);
        string govtForm = rdr.GetString(4);
        Country country = new Country(countrycode, countryName, region, lifeExpectancy, govtForm);
        allCountries.Add(country);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allCountries;
    }
  }
}
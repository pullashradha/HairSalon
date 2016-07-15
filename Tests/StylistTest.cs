using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_EmptyDatabase_CountStylists()
    {
      int numberOfStylists = Stylist.GetAll().Count;
      Assert.Equal(0, numberOfStylists);
    }
    [Fact]
    public void Test_Equal_StylistEntriesMatch()
    {
      Stylist firstStylist = new Stylist ("Terry Jones", "555-555-5555");
      Stylist secondStylist = new Stylist ("Terry Jones", "555-555-5555");
      Assert.Equal(firstStylist, secondStylist);
    }
    [Fact]
    public void Test_Save_SavesAllStylistsToDatabase()
    {
      Stylist newStylist = new Stylist ("Terry Jones", "555-555-5555");
      newStylist.Save();
      Assert.Equal(1, Stylist.GetAll().Count);
    }
    [Fact]
    public void Test_Find_ReturnCorrectStylistById()
    {
      Stylist newStylist = new Stylist ("Terry Jones", "555-555-5555");
      newStylist.Save();
      Stylist foundStylist = Stylist.Find(newStylist.GetId());
      Assert.Equal(newStylist, foundStylist);
    }
    [Fact]
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}

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
      Stylist firstStylist = new Stylist ("Terry", "Jones", "555-555-5555", "jones@gmail.com", "101 SW Washington St.", "Portland", "OR", "97206");
      Stylist secondStylist = new Stylist ("Terry", "Jones", "555-555-5555", "jones@gmail.com", "101 SW Washington St.", "Portland", "OR", "97206");
      Assert.Equal(firstStylist, secondStylist);
    }
    [Fact]
    public void Test_Save_SavesAllStylistsToDatabase()
    {
      Stylist newStylist = new Stylist ("Terry", "Jones", "555-555-5555", "jones@gmail.com", "101 SW Washington St.", "Portland", "OR", "97206");
      newStylist.Save();
      Assert.Equal(1, Stylist.GetAll().Count);
    }
    [Fact]
    public void Test_GetClients_ReturnsAllClientsById()
    {
      Stylist newStylist = new Stylist ("Terry", "Jones", "555-555-5555", "jones@gmail.com", "101 SW Washington St.", "Portland", "OR", "97206");
      newStylist.Save();
      Client firstClient = new Client ("Rubab", "Shah", "777-777-7777", "shah@gmail.com", newStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client ("Maya", "Reddy", "888-888-8888", "reddy@gmail.com", newStylist.GetId());
      secondClient.Save();
      List<Client> allClients = new List<Client> {firstClient, secondClient};
      Assert.Equal(allClients, newStylist.GetClients());
    }
    [Fact]
    public void Test_Find_ReturnsCorrectStylistById()
    {
      Stylist newStylist = new Stylist ("Terry", "Jones", "555-555-5555", "jones@gmail.com", "101 SW Washington St.", "Portland", "OR", "97206");
      newStylist.Save();
      Stylist foundStylist = Stylist.Find(newStylist.GetId());
      Assert.Equal(newStylist, foundStylist);
    }
    [Fact]
    public void Test_Update_UpdateStylistEntry()
    {
      Stylist newStylist = new Stylist ("Terry", "Jones", "555-555-5555", "jones@gmail.com", "101 SW Washington St.", "Portland", "OR", "97206");
      newStylist.Save();
      newStylist.SetStreetAddress("2222 E Kones Blvd.");
      newStylist.Update();
      Stylist updatedStylist = Stylist.Find(newStylist.GetId());
      Assert.Equal(newStylist.GetStreetAddress(), updatedStylist.GetStreetAddress());
    }
    [Fact]
    public void Test_DeleteOne_DeletesOneStylist()
    {
      Stylist firstStylist = new Stylist ("Terry", "Jones", "555-555-5555", "jones@gmail.com", "101 SW Washington St.", "Portland", "OR", "97206");
      firstStylist.Save();
      Stylist secondStylist = new Stylist ("Page", "Williams", "000-000-0000", "williams@gmail.com", "5432 NE Jefferson Ave.", "Portland", "OR", "93210");
      secondStylist.Save();
      Stylist thirdStylist = new Stylist ("Burrow", "Davidson", "222-222-2222", "davidson@gmail.com", "1112 E Oak Blvd.", "Seattle", "WA", "87456");
      thirdStylist.Save();
      List<Stylist> testList = new List<Stylist> {secondStylist, thirdStylist};
      firstStylist.DeleteOne();
      List<Stylist> resultList = Stylist.GetAll();
      Assert.Equal(testList, resultList);
      Assert.Equal(2, Stylist.GetAll().Count);
    }
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }
  }
}

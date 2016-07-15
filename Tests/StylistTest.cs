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
    public void Test_Find_ReturnsCorrectStylistById()
    {
      Stylist newStylist = new Stylist ("Terry Jones", "555-555-5555");
      newStylist.Save();
      Stylist foundStylist = Stylist.Find(newStylist.GetId());
      Assert.Equal(newStylist, foundStylist);
    }
    [Fact]
    public void Test_DeleteOne_DeletesOneStylist()
    {
      Stylist firstStylist = new Stylist ("Terry Jones", "555-555-5555");
      firstStylist.Save();
      Stylist secondStylist = new Stylist ("Page Williams", "000-000-0000");
      secondStylist.Save();
      Stylist thirdStylist = new Stylist ("Burrow Davidson", "222-222-2222");
      thirdStylist.Save();
      Stylist.DeleteOne(firstStylist.GetId());
      Assert.Equal(2, Stylist.GetAll().Count);
    }
    [Fact]
    public void Test_GetClients_ReturnsAllClientsById()
    {
      Stylist newStylist = new Stylist ("Terry Jones", "555-555-5555");
      newStylist.Save();
      Client firstClient = new Client ("Rubab Shah", "777-777-7777", newStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client ("Maya Reddy", "888-888-8888", newStylist.GetId());
      secondClient.Save();
      List<Client> allClients = new List<Client> {firstClient, secondClient};
      Assert.Equal(allClients, newStylist.GetClients());
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_EmptyDatabase_countClients()
    {
      int numberOfClients = Client.GetAll().Count;
      Assert.Equal(0, numberOfClients);
    }
    [Fact]
    public void Test_Equal_ClientEntriesMatch()
    {
      Client firstClient = new Client ("Jennifer Smith", "333-333-3333", 1);
      Client secondClient = new Client("Jennifer Smith", "333-333-3333", 1);
      Assert.Equal(firstClient, secondClient);
    }
    [Fact]
    public void Test_Save_SavesAllClientsToDatabase()
    {
      Client newClient = new Client ("Jennifer Smith", "333-333-3333", 1);
      newClient.Save();
      Assert.Equal(1, Client.GetAll().Count);
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}

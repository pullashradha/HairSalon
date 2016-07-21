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
    public void Test_EmptyDatabase_CountClients()
    {
      int numberOfClients = Client.GetAll().Count;
      Assert.Equal(0, numberOfClients);
    }
    [Fact]
    public void Test_Equal_ClientEntriesMatch()
    {
      Client firstClient = new Client ("Jennifer", "Smith", "333-333-3333", "smith@gmail.com", 1);
      Client secondClient = new Client ("Jennifer", "Smith", "333-333-3333", "smith@gmail.com", 1);
      Assert.Equal(firstClient, secondClient);
    }
    [Fact]
    public void Test_Save_SavesAllClientsToDatabase()
    {
      Client newClient = new Client ("Jennifer", "Smith", "333-333-3333", "smith@gmail.com", 1);
      newClient.Save();
      Assert.Equal(1, Client.GetAll().Count);
    }
    [Fact]
    public void Test_Find_ReturnsCorrectClientById()
    {
      Client newClient = new Client ("Jennifer", "Smith", "333-333-3333", "smith@gmail.com", 1);
      newClient.Save();
      Client foundClient = Client.Find(newClient.GetId());
      Assert.Equal(newClient, foundClient);
    }
    [Fact]
    public void Test_DeleteOne_DeletesOneClient()
    {
      Client firstClient = new Client ("Jennifer", "Smith", "333-333-3333", "smith@gmail.com", 1);
      firstClient.Save();
      Client secondClient = new Client ("Rubab", "Shah", "777-777-7777", "shah@gmail.com", 2);
      secondClient.Save();
      Client thirdClient = new Client ("Maya", "Reddy", "888-888-8888", "reddy@gmail.com", 3);
      thirdClient.Save();
      List<Client> testList = new List<Client> {secondClient, thirdClient};
      firstClient.DeleteOne();
      List<Client> resultList = Client.GetAll();
      Assert.Equal(testList, resultList);
      Assert.Equal(2, Client.GetAll().Count);
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}

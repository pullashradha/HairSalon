using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace HairSalon
{
  public class ClientTest
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
  }
}

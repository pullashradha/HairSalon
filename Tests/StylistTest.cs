using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace HairSalon
{
  public class StylistTest
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_Empty_GetAllStylists()
    {
      Stylist newStylist = new Stylist ("Stylist Name", "Stylist's Phone Number");
      Assert.Equal(0, newStylist.GetAll());
    }
  }
}

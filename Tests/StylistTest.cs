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
    public void Test_EmptyDatabase_CountStylists()
    {
      int numberOfStylists = Stylist.GetAll().Count;
      Assert.Equal(0, numberOfStylists);
    }
    [Fact]
    public void Test_Equal_StylistEntriesMatch()
    {
      Stylist firstStylist = new Stylist ("Stylist Name", "Stylist Phone Number");
      Stylist secondStylist = new Stylist ("Stylist Name", "Stylist Phone Number");
      Assert.Equal(firstStylist, secondStylist);
    }
  }
}

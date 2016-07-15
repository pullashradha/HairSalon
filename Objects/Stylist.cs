using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _name;
    private string _phoneNumber;
    public Stylist (string Name, string PhoneNumber, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _phoneNumber = PhoneNumber;
    }
    public override bool Equals(System.Object otherStylist)
    {
      if (otherStylist is Stylist)
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool nameEquality = (this.GetName() == newStylist.GetName());
        bool phoneEquality = (this.GetPhoneNumber() == newStylist.GetPhoneNumber());
        return (nameEquality && phoneEquality && idEquality);
      }
      else
      {
        return false;
      }
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber(string newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM stylists;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        string stylistPhoneNumber = rdr.GetString(2);
        Stylist newStylist = new Stylist (stylistName, stylistPhoneNumber, stylistId);
        allStylists.Add(newStylist);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allStylists;
    }
    public void Save()
    {
      List<Stylist> stylistsList = new List<Stylist> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("INSERT INTO stylists (name, phone_number) OUTPUT INSERTED.id VALUES (@StylistName, @StylistPhoneNumber);", conn);
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@StylistName";
      nameParameter.Value = this.GetName();
      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@StylistPhoneNumber";
      phoneParameter.Value = this.GetPhoneNumber();
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(phoneParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
  }
}

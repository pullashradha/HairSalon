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
      
    }
  }
}

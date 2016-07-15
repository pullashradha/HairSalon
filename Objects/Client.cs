using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Client
  {
    private int _id;
    private string _name;
    private string _phoneNumber;
    private int _stylistId;
    public Client (string Name, string PhoneNumber, int StylistId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _phoneNumber = PhoneNumber;
      _stylistId = StylistId;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName (string newName)
    {
      _name = newName;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber (string newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public void SetStylistId (int newStylistId)
    {
      _stylistId = newStylistId;
    }
    public static List<Client> GetAll()
    {

    }
  }
}

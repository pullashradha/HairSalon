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
      List<Client> allClients = new List<Client> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM clients;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string clientPhoneNumber = rdr.GetString(2);
        int stylistId = rdr.GetInt32(0);
        Client newClient = new Client (clientName, clientPhoneNumber, stylistId, clientId);
        allClients.Add(newClient);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allClients;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Client
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    private string _email;
    private int _stylistId;
    public Client (string FirstName, string LastName, string PhoneNumber, string Email, int StylistId, int Id = 0)
    {
      _id = Id;
      _firstName = FirstName;
      _lastName = LastName;
      _phoneNumber = PhoneNumber;
      _email = Email;
      _stylistId = StylistId;
    }
    public override bool Equals (System.Object otherClient)
    {
      if (otherClient is Client)
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool firstNameEquality = (this.GetFirstName() == newClient.GetFirstName());
        bool lastNameEquality = (this.GetLastName() == newClient.GetLastName());
        bool phoneEquality = (this.GetPhoneNumber() == newClient.GetPhoneNumber());
        bool emailEquality = (this.GetEmail() == newClient.GetEmail());
        bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
        return (firstNameEquality && lastNameEquality && phoneEquality && emailEquality && stylistIdEquality && idEquality);
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
    public string GetFirstName()
    {
      return _firstName;
    }
    public void SetFirstName (string newFirstName)
    {
      _firstName = newFirstName;
    }
    public string GetLastName()
    {
      return _lastName;
    }
    public void SetLastName (string newLastName)
    {
      _lastName = newLastName;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber (string newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }
    public string GetEmail()
    {
      return _email;
    }
    public void SetEmail(string newEmail)
    {
      _email = newEmail;
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
        string clientFirstName = rdr.GetString(1);
        string clientLastName = rdr.GetString(2);
        string clientPhoneNumber = rdr.GetString(3);
        string clientEmail = rdr.GetString(4);
        int stylistId = rdr.GetInt32(5);
        Client newClient = new Client (clientFirstName, clientLastName, clientPhoneNumber, clientEmail, stylistId, clientId);
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
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("INSERT INTO clients (first_name, last_name, phone_number, email, stylist_id) OUTPUT INSERTED.id VALUES (@ClientFirstName, @ClientLastName, @ClientPhoneNumber, @ClientEmail, @StylistId);", conn);
      SqlParameter firstNameParameter = new SqlParameter();
      firstNameParameter.ParameterName = "@ClientFirstName";
      firstNameParameter.Value = this.GetFirstName();
      SqlParameter lastNameParameter = new SqlParameter();
      lastNameParameter.ParameterName = "@ClientLastName";
      lastNameParameter.Value = this.GetLastName();
      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@ClientPhoneNumber";
      phoneParameter.Value = this.GetPhoneNumber();
      SqlParameter emailParameter = new SqlParameter();
      emailParameter.ParameterName = "@ClientEmail";
      emailParameter.Value = this.GetEmail();
      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = this.GetStylistId();
      cmd.Parameters.Add(firstNameParameter);
      cmd.Parameters.Add(lastNameParameter);
      cmd.Parameters.Add(phoneParameter);
      cmd.Parameters.Add(emailParameter);
      cmd.Parameters.Add(stylistIdParameter);
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
    public static Client Find (int searchId)
    {
      List<Client> allClients = new List<Client> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM clients WHERE id = @SearchId;", conn);
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@SearchId";
      idParameter.Value = searchId;
      cmd.Parameters.Add(idParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientFirstName = rdr.GetString(1);
        string clientLastName = rdr.GetString(2);
        string clientPhoneNumber = rdr.GetString(3);
        string clientEmail = rdr.GetString(4);
        int stylistId = rdr.GetInt32(5);
        Client newClient = new Client (clientFirstName, clientLastName, clientPhoneNumber, clientEmail, stylistId, clientId);
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
      return allClients[0];
    }
    public void DeleteOne ()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM clients WHERE id = @SearchId;", conn);
      SqlParameter idParameter = new SqlParameter ();
      idParameter.ParameterName = "@SearchId";
      idParameter.Value = this.GetId();
      cmd.Parameters.Add(idParameter);
      cmd.ExecuteNonQuery();
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}

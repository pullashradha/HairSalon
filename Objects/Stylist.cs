using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    private string _email;
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _zipcode;
    public Stylist (string FirstName, string LastName, string PhoneNumber, string Email, string StreetAddress, string City, string State, string Zipcode, int Id = 0)
    {
      _id = Id;
      _firstName = FirstName;
      _lastName = LastName;
      _phoneNumber = PhoneNumber;
      _email = Email;
      _streetAddress = StreetAddress;
      _city = City;
      _state = State;
      _zipcode = Zipcode;
    }
    public override bool Equals (System.Object otherStylist)
    {
      if (otherStylist is Stylist)
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool firstNameEquality = (this.GetFirstName() == newStylist.GetFirstName());
        bool lastNameEquality = (this.GetLastName() == newStylist.GetLastName());
        bool phoneEquality = (this.GetPhoneNumber() == newStylist.GetPhoneNumber());
        bool emailEquality = (this.GetEmail() == newStylist.GetEmail());
        bool streetEquality = (this.GetStreetAddress() == newStylist.GetStreetAddress());
        bool cityEquality = (this.GetCity() == newStylist.GetCity());
        bool stateEquality = (this.GetState() == newStylist.GetState());
        bool zipcodeEquality = (this.GetZipcode() == newStylist.GetZipcode());
        return (firstNameEquality && lastNameEquality && phoneEquality && emailEquality && streetEquality && cityEquality && stateEquality && zipcodeEquality && idEquality);
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
    public void SetEmail (string newEmail)
    {
      _email = newEmail;
    }
    public string GetStreetAddress()
    {
      return _streetAddress;
    }
    public void SetStreetAddress (string newStreetAddress)
    {
      _streetAddress = newStreetAddress;
    }
    public string GetCity()
    {
      return _city;
    }
    public void SetCity (string newCity)
    {
      _city = newCity;
    }
    public string GetState()
    {
      return _state;
    }
    public void SetState (string newState)
    {
      _state = newState;
    }
    public string GetZipcode()
    {
      return _zipcode;
    }
    public void SetZipcode (string newZipcode)
    {
      _zipcode = newZipcode;
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
        string stylistFirstName = rdr.GetString(1);
        string stylistLastName = rdr.GetString(2);
        string stylistPhoneNumber = rdr.GetString(3);
        string stylistEmail = rdr.GetString(4);
        string stylistStreet = rdr.GetString(5);
        string stylistCity = rdr.GetString(6);
        string stylistState = rdr.GetString(7);
        string stylistZipcode = rdr.GetString(8);
        Stylist newStylist = new Stylist (stylistFirstName, stylistLastName, stylistPhoneNumber, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZipcode, stylistId);
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
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("INSERT INTO stylists (first_name, last_name, phone_number, email, street_address, city_address, state_address, zipcode) OUTPUT INSERTED.id VALUES (@StylistFirstName, @StylistLastName, @StylistPhoneNumber, @StylistEmail, @StylistStreetAddress, @StylistCity, @StylistState, @StylistZipcode);", conn);
      SqlParameter firstNameParameter = new SqlParameter();
      firstNameParameter.ParameterName = "@StylistFirstName";
      firstNameParameter.Value = this.GetFirstName();
      SqlParameter lastNameParameter = new SqlParameter();
      lastNameParameter.ParameterName = "@StylistLastName";
      lastNameParameter.Value = this.GetLastName();
      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@StylistPhoneNumber";
      phoneParameter.Value = this.GetPhoneNumber();
      SqlParameter emailParameter = new SqlParameter();
      emailParameter.ParameterName = "@StylistEmail";
      emailParameter.Value = this.GetEmail();
      SqlParameter streetParameter = new SqlParameter();
      streetParameter.ParameterName = "@StylistStreetAddress";
      streetParameter.Value = this.GetStreetAddress();
      SqlParameter cityParameter = new SqlParameter();
      cityParameter.ParameterName = "@StylistCity";
      cityParameter.Value = this.GetCity();
      SqlParameter stateParameter = new SqlParameter();
      stateParameter.ParameterName = "@StylistState";
      stateParameter.Value = this.GetState();
      SqlParameter zipcodeParameter = new SqlParameter();
      zipcodeParameter.ParameterName = "@StylistZipcode";
      zipcodeParameter.Value = this.GetZipcode();
      cmd.Parameters.Add(firstNameParameter);
      cmd.Parameters.Add(lastNameParameter);
      cmd.Parameters.Add(phoneParameter);
      cmd.Parameters.Add(emailParameter);
      cmd.Parameters.Add(streetParameter);
      cmd.Parameters.Add(cityParameter);
      cmd.Parameters.Add(stateParameter);
      cmd.Parameters.Add(zipcodeParameter);
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
    public static Stylist Find (int searchId)
    {
      List<Stylist> allStylists = new List<Stylist> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM stylists WHERE id = @SearchId;", conn);
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@SearchId";
      idParameter.Value = searchId;
      cmd.Parameters.Add(idParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistFirstName = rdr.GetString(1);
        string stylistLastName = rdr.GetString(2);
        string stylistPhoneNumber = rdr.GetString(3);
        string stylistEmail = rdr.GetString(4);
        string stylistStreet = rdr.GetString(5);
        string stylistCity = rdr.GetString(6);
        string stylistState = rdr.GetString(7);
        string stylistZipcode = rdr.GetString(8);
        Stylist newStylist = new Stylist (stylistFirstName, stylistLastName, stylistPhoneNumber, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZipcode, stylistId);
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
      return allStylists[0];
    }
    public static void DeleteOne (int searchId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM stylists WHERE id = @SearchId; DELETE FROM clients WHERE stylist_id = @StylistId;", conn);
      SqlParameter idParameter = new SqlParameter();
      idParameter.ParameterName = "@SearchId";
      idParameter.Value = searchId;
      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = searchId;
      cmd.Parameters.Add(idParameter);
      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM stylists; DELETE FROM clients", conn);
      cmd.ExecuteNonQuery();
    }
    public List<Client> GetClients()
    {
      List<Client> allClients = new List<Client> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM clients WHERE stylist_id = @StylistId;", conn);
      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = this.GetId();
      cmd.Parameters.Add(stylistIdParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientFirstName = rdr.GetString(1);
        string clientLastName = rdr.GetString(2);
        string clientPhoneNumber = rdr.GetString(3);
        string clientEmail = rdr.GetString(4);
        int stylistId = this._id;
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
  }
}

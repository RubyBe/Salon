using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Salon
{
  public class Stylist
  {
    // Properties
    private int _id;
    private string _name;
    private string _specialty;
    private static List<Stylist> _stylists = new List<Stylist>{};
    private static List<Client> _clients = new List<Client>{};

    // Constructors
    // A constructor that takes two paramaters and auto-assigns id
    public Stylist(string name, string specialty, int Id=0)
    {
      _name = name;
      _specialty = specialty;
      _id = Id;
      _clients = new List<Client>{};
    }

    // Getters and Setters
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetSpecialty()
    {
      return _specialty;
    }

    // Other methods
    // a method that tests equality of objects based on value of _name
    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool nameEquality =(this.GetName() == newStylist.GetName());
        return(nameEquality);
      }
    }
    // a method to return a list of all stylists
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        string stylistService = rdr.GetString(2);
        Stylist newStylist = new Stylist(stylistName, stylistService, stylistId);
        allStylists.Add(newStylist);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return allStylists;
    }
    public void Save()
    {
      // Set and open the database connection
      SqlConnection conn = DB.Connection();
      conn.Open();
      // Build the SQL query
      SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name, specialty) OUTPUT INSERTED.id VALUES (@StylistName, @StylistSpecialty);", conn);
      // Define parameters to inject into the query
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@StylistName";
      nameParameter.Value = this.GetName();
      SqlParameter specialtyParamater = new SqlParameter();
      specialtyParamater.ParameterName = "@StylistSpecialty";
      specialtyParamater.Value = this.GetSpecialty();
      // Inject parameters into the Query
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(specialtyParamater);
      // Execute the SQL query
      SqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      // Close any open connections
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
    public static Stylist Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);
      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = id.ToString();
      cmd.Parameters.Add(stylistIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();
      int foundStylistId = 0;
      string foundStylistName = null;
      string foundStylistSpecialty = null;
      while(rdr.Read())
      {
        foundStylistId = rdr.GetInt32(0);
        foundStylistName= rdr.GetString(1);
        foundStylistSpecialty = rdr.GetString(2);
      }
      Stylist foundStylist = new Stylist(foundStylistName, foundStylistSpecialty);
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return foundStylist;
    }
  }
}

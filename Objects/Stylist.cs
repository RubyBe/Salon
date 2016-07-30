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
    public Stylist(string name, string specialty, int id=0)
    {
      _name = name;
      _specialty = specialty;
      _id = _stylists.Count;
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

    // Other methods
    // method to add a client to this stylist's list of clients
    public void AddClient(Client client)
    {
      _clients.Add(client);
    }
    public static int GetCount()
    {
      return _stylists.Count;
    }
    public void Save()
    {
      _stylists.Add(this);
    }
    public static List<Stylist> GetAll()
    {
      return _stylists;
    }
    public static void DeleteAll()
    {
      _stylists.Clear();
    }
    public static Stylist FindById(int id)
    {
      return _stylists[id - 1];
    }
    public void Update(string newName)
    {
      _name = newName;
    }
    public static void DeleteById(int id)
    {
      _stylists.RemoveAt(id);
    }
    public List<Client> GetClients()
    {
      return _clients;
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

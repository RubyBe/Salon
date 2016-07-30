using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Salon
{
  public class Client
  {
    // Properties
    private int _id;
    private string _name;
    private string _treatment;
    private static List<Client> _clients = new List<Client>{};

    // Constructors
    public Client(string name, string treatment, int Id=0)
    {
      _id = Id;
      _name = name;
      _treatment = treatment;
    }

    // Getters, Setters
    public string GetName()
    {
      return _name;
    }
    public string GetTreatment()
    {
      return _treatment;
    }
    public int GetId()
    {
      return _id;
    }

    // Other Methods
    // a method that tests equality of objects based on value of _name
    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool nameEquality =(this.GetName() == newClient.GetName());
        bool idEquality = (this.GetId() == newClient.GetId());
        return(nameEquality && idEquality);
      }
    }
    public void Save()
    {
      // Set and open the database connection
      SqlConnection conn = DB.Connection();
      conn.Open();
      // Build the SQL query
      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, treatment) OUTPUT INSERTED.id VALUES (@ClientName, @ClientTreatment);", conn);
      // Define parameters to inject into the query
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClientName";
      nameParameter.Value = this.GetName();
      SqlParameter treatmentParameter = new SqlParameter();
      treatmentParameter.ParameterName = "@ClientTreatment";
      treatmentParameter.Value = this.GetTreatment();
      // Inject parameters into the Query
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(treatmentParameter);
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
    public static int GetCount()
    {
      return _clients.Count;
    }
    // a task that reads all client records from the salon database clients table
    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string clientService = rdr.GetString(2);
        Client newClient = new Client(clientName, clientService, clientId);
        allClients.Add(newClient);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return allClients;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
    public static Client FindById(int id)
    {
      return _clients[id-1];
    }
    public void Update(string name)
    {
      _name = name;
    }
    public static void DeleteById(int id)
    {
      _clients.RemoveAt(id);
    }
    public static Client Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = id.ToString();
      cmd.Parameters.Add(clientIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();
      int foundClientId = 0;
      string foundClientName = null;
      string foundClientTreatment = null;
      while(rdr.Read())
      {
        foundClientId = rdr.GetInt32(0);
        foundClientName = rdr.GetString(1);
        foundClientTreatment = rdr.GetString(1);
      }
      Client foundClient = new Client(foundClientName, foundClientTreatment, foundClientId);
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return foundClient;
    }
  }
}

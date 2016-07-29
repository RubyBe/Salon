using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Salon
{
  public class Client
  {
    // Properties
    private int _id;
    private string _name;
    private string _service;
    private static List<Client> _clients = new List<Client>{};

    // Constructors
    public Client(string name, string service, int id=0)
    {
      _name = name;
      _service = service;
      _id = _clients.Count;
    }

    // Getters, Setters
    public string GetName()
    {
      return _name;
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
        return(nameEquality);
      }
    }
    public void Save()
    {
      _clients.Add(this);
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
      _clients.Clear();
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
  }
}

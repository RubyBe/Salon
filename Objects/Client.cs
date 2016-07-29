using System.Collections.Generic;

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
    }

    // Getters, Setters
    public string GetName()
    {
      return _name;
    }

    // Other Methods
    public void Save()
    {
      _clients.Add(this);
    }
    public static int GetCount()
    {
      return _clients.Count;
    }
    public static List<Client> GetAll()
    {
      return _clients;
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
      // TODO
    }
  }
}

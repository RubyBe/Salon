using System.Collections.Generic;

namespace Salon
{
  public class Client
  {
    // Properties
    private string _name;
    private string _service;
    private static List<Client> _clients = new List<Client>{};

    // Constructors
    public Client(string name, string service)
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
  }
}

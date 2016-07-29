using System.Collections.Generic;

namespace Salon
{
  public class Client
  {
    // Properties
    private string _name;
    private string _service;
    private List<Client> _clients = new List<Client>{};

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
      // TODO
    }
    public static int GetCount()
    {
      return 0;
    }
  }
}



namespace Salon
{
  public class Client
  {
    // Properties
    private string _name;
    private string _service;

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
  }
}

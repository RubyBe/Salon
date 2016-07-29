using System;

namespace Salon
{
  public class Stylist
  {
    // Properties
    private int _id;
    private string _name;
    private string _specialty;

    // Constructors
    // A constructor that takes two paramaters and auto-assigns id
    public Stylist(string name, string specialty, int id=0)
    {
      _name = name;
      _specialty = specialty;
    }

    // Getters and Setters
    public string GetName()
    {
      return _name;
    }

    // Other methods
  }
}

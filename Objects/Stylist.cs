using System;
using System. Collections.Generic;

namespace Salon
{
  public class Stylist
  {
    // Properties
    private int _id;
    private string _name;
    private string _specialty;
    // private static int _instances;
    private static List<Stylist> _stylists = new List<Stylist>{};

    // Constructors
    // A constructor that takes two paramaters and auto-assigns id
    public Stylist(string name, string specialty, int id=0)
    {
      _name = name;
      _specialty = specialty;
      // _instances++;
      _id = _stylists.Count;
    }

    // Getters and Setters
    public string GetName()
    {
      return _name;
    }

    // Other methods
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
    public void Update(string newValue)
    {
      // TODO
    }
  }
}

using Nancy;
using System.Collections.Generic;

namespace Salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/stylists/new"] = _ =>
      {
        return View["stylists_new.cshtml"];
      };
      Post["/stylists/new"] = _ =>
      {
        return View["success.cshtml"];
      };
    }
  }
}

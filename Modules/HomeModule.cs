using Nancy;
using System;
using System.Collections.Generic;

namespace Salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        var allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };

      Post["/"] = _ => {
      var newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-specialty"]);
      newStylist.Save();
      var allStylists = Stylist.GetAll();
      return View["index.cshtml", allStylists];
      };

      Get["/stylists/{id}"] = parameters => {
       Dictionary<string, object> model = new Dictionary<string, object>();
       var selectedStylist = Stylist.Find(parameters.id);
       var stylistClients = selectedStylist.GetClients(parameters.id);
       model.Add("stylist", selectedStylist);
       model.Add("clients", stylistClients);
       return View["stylist.cshtml", model];
     };
    }
  }
}

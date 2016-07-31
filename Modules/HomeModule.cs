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

     Get["/stylist/edit/{id}"] = parameters =>
     {
       Stylist selectedStylist = Stylist.Find(parameters.id);
       return View["stylist_edit.cshtml", selectedStylist];
     };

     Patch["stylist/edit/{id}"] = parameters =>
     {
       Stylist selectedStylist = Stylist.Find(parameters.id);
       selectedStylist.Update(Request.Form["stylist-name"]);
       return View["success.cshtml"];
     };

     Post["/stylist/new"] = _ =>
     {
       Client newClient = new Client(Request.Form["client-name"], Request.Form["client-treatment"], Request.Form["stylist-id"]);
       newClient.Save();
       return View["success.cshtml"];
     };
    }
  }
}

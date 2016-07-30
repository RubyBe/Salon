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
        return View["index.cshtml"];
      };
      Get["/stylists"] = _ =>
      {
        var allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/stylists/new"] = _ =>
      {
        return View["stylist_form.cshtml"];
      };
      Post["/stylists"] = _ => {
      var newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-specialty"]);
      var allStylists = Stylist.GetAll();
      return View["stylists.cshtml", allStylists];
      };

      Get["/stylists/{id}"] = parameters => {
       Dictionary<string, object> model = new Dictionary<string, object>();
       var selectedStylist = Stylist.Find(parameters.id);
       var stylistClients = selectedStylist.GetClients();
       model.Add("stylist", selectedStylist);
       model.Add("client", stylistClients);
       return View["stylist.cshtml", model];
     };
    }
  }
}

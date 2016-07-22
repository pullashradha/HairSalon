using Nancy;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => {
        return View ["index.cshtml", Stylist.GetAll()];
      };
      Post ["/stylists/new"] = _ => {
        Stylist newStylist = new Stylist
        (
          Request.Form ["stylist-first-name"],
          Request.Form ["stylist-last-name"],
          Request.Form ["stylist-phone-number"],
          Request.Form ["stylist-email"],
          Request.Form ["stylist-street-address"],
          Request.Form ["stylist-city"],
          Request.Form ["stylist-state"],
          Request.Form ["stylist-zipcode"]
        );
        newStylist.Save();
        return View ["stylist_created.cshtml", newStylist];
      };
      Get ["/stylists/{id}/{first_name}_{last_name}"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View ["stylist.cshtml", selectedStylist];
      };
      Post ["/stylists/{id}/{first_name}_{last_name}/clients/new"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        Client newClient = new Client
        (
          Request.Form ["client-first-name"],
          Request.Form ["client-last-name"],
          Request.Form ["client-phone-number"],
          Request.Form ["client-email"],
          Request.Form ["stylist-id"]
        );
        newClient.Save();
        return View ["stylist.cshtml", Stylist.Find(Request.Form["stylist-id"])];
      };
      // Post ["/stylists/{id}/{first_name}_{last_name}/clients/deleted"] = parameters => {
      //   Stylist selectedStylist = Stylist.Find(parameters.id);
      //   Client newClient = newClient.DeleteOne(Request.Form ["client-id"]);
      //   return View ["stylist.cshtml", selectedStylist];
      // };
      Post ["/stylists/{id}/{first_name}_{last_name}/deleted"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.DeleteOne();
        return View ["stylist_deleted.cshtml", selectedStylist];
      };
      Post ["/stylists/deleted"] = _ => {
        Stylist.DeleteAll();
        return View ["index.cshtml", Stylist.GetAll()];
      };
    }
  }
}

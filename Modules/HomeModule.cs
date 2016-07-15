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
      Post ["/stylist/new/created"] = _ => {
        Stylist newStylist = new Stylist
        (
          Request.Form ["stylist-name"],
          Request.Form ["stylist-phone-number"]
        );
        newStylist.Save();
        return View ["stylist_created.cshtml", newStylist];
      };
      Get ["/{id}/{name}/client_list"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View ["stylist.cshtml", selectedStylist];
      };
      Post ["/{id}/{name}/client_list/client_added"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        Client newClient = new Client
        (
          Request.Form ["client-name"],
          Request.Form ["client-phone-number"],
          Request.Form ["stylist-id"]
        );
        newClient.Save();
        return View ["stylist.cshtml", Stylist.Find(Request.Form["stylist-id"])];
      };
      Post ["/{id}/{name}/client_list/client_deleted"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        Client.DeleteOne(Request.Form ["client-id"]);
        return View ["stylist.cshtml", selectedStylist];
      };
      Post ["/{id}/{name/stylist_deleted"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        Stylist.DeleteOne(Request.Form["stylist-id"]);
        return View ["stylist_deleted.cshtml", selectedStylist];
      };
      // Post ["/stylist/all_deleted"] = _ => {
      //   Stylist.DeleteAll();
      //   return View ["index.cshtml", Stylist.GetAll()];
      // };
    }
  }
}

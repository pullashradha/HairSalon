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
      // Post ["/{id}/{name}/client_list"] = _ => {
      //   return View ["stylist.cshtml", Stylist.GetClients()];
      // };
      // Post ["/stylist/deleted"] = _ => {
      //   return View ["stylist_deleted.cshtml", Stylist.DeleteOne()];
      // };
    }
  }
}

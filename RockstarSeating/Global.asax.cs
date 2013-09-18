using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace RockstarSeating
{
    public class Global : System.Web.HttpApplication
    {

        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("_EVENT_", 
                "event.aspx", 
                "~/tickets/event.aspx");

            routes.MapPageRoute("_VENUE_", 
                "venue.aspx", 
                "~/tickets/venue.aspx");

            routes.MapPageRoute("_SEARCH_",
                "search.aspx",
                "~/tickets/search.aspx");

            routes.MapPageRoute("_CITY_",
                "city.aspx",
                "~/tickets/city.aspx");

            routes.MapPageRoute("_RESULTSTICKET_",
                "ResultsTicket.aspx",
                "~/tickets/ResultsTicket.aspx");

            routes.MapPageRoute("_CATEGORY_",
                "category.aspx",
                "~/tickets/category.aspx");

            routes.MapPageRoute("_ResultsDate_",
                "ResultsDate.aspx",
                "~/tickets/ResultsDate.aspx");

            routes.MapPageRoute("_ResultsEmpty_",
                "ResultsEmpty.aspx",
                "~/tickets/ResultsEmpty.aspx");

            routes.MapPageRoute("_ResultsEventAtVenue_",
                "ResultsEventAtVenue.aspx",
                "~/tickets/ResultsEventAtVenue.aspx");

            routes.MapPageRoute("_ResultsGeneralAtVenue_",
                "ResultsGeneralAtVenue.aspx",
                "~/tickets/ResultsGeneralAtVenue.aspx");

            routes.MapPageRoute("_SUBCATEGORIES_",
                "subcategories.aspx",
                "~/tickets/subcategories.aspx");

            routes.MapPageRoute("_REQUESTTICKETS_",
                "requestTickets.aspx",
                "~/tickets/requestTickets.aspx");

            routes.MapPageRoute("_POLICIES_",
                "policies.aspx",
                "~/content/policies.aspx");

            routes.MapPageRoute("_COMPANYINFO_",
                "company.aspx",
                "~/content/contactus.aspx");


            routes.MapPageRoute("_SITE_",
                "site",
                "~/Default.aspx");






        }
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            //Response.Redirect("~/content/generalError.aspx?e=\"Session has ended.\"");

        }

    }
}

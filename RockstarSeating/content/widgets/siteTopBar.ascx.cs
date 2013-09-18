using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating.content.widgets
{
	public partial class siteTopBar : System.Web.UI.UserControl
	{
        protected Boolean isLoggedIn = false;
        //protected string sWebServer = HttpContext.Current.Request.RawUrl.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            isLoggedIn = Convert.ToBoolean(Session["isLoggedIn"]);
              
            if (isLoggedIn)
            {
                displayLoggedInStatus();
            }
        }




        protected void displayLoggedInStatus()
        {
            //user is logged in, so display welcome message
            welcomeMsg.Visible = true;

            logInLnk.Visible = false;
            logOutLnk.Visible = true;
            myAccountLnk.Visible = true;

            Boolean isConsignor = Convert.ToBoolean(Session["isConsignor"]);
            Boolean isAdmin = Convert.ToBoolean(Session["isAdmin"]);

        }
    }
}
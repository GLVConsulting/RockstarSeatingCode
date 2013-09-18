using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating.content.widgets
{
	public partial class header : System.Web.UI.UserControl
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
			Boolean isConsignor = Convert.ToBoolean(Session["isConsignor"]);
			Boolean isAdmin = Convert.ToBoolean(Session["isAdmin"]);


			if (isConsignor || isAdmin)
			{
				userLinksWrapper.Visible = true;

				if (isConsignor)
				{
					uploadInventoryLnk.Visible = true;
				}

				if (isAdmin)
				{
					adminLnk.Visible = true;
				}
			}


		}
	}
}
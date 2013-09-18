using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating
{
	public partial class concerts : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.Redirect("~/tickets/search.aspx?kwds=seattle%20concerts");
		}
	}
}
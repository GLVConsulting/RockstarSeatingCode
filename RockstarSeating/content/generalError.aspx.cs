using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating.content
{
	public partial class generalErr : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string errMsg = Request.QueryString["e"];

			if (errMsg != "")
			{
				validationBox.Visible = true;
				ErrMessage.Text = "\"" + errMsg +"\"";
			}
		}
	}
}
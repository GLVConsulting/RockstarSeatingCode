using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating.content.widgets
{
	public partial class leftNav : System.Web.UI.UserControl
	{
		public string pcatid = String.Empty;


		protected void Page_Load(object sender, EventArgs e)
		{
			pcatid = Request.QueryString["pcatid"];
		}
	}
}
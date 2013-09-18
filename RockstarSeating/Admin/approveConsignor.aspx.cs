using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RockstarSeating.dataFiles;

namespace RockstarSeating.Admin
{
	public partial class approveConsignor : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			String emailAddress = Request.QueryString["eid"];
			String userId = Request.QueryString["uid"];
			String adminEmail = Session["emailAddress"].ToString();

			verifyConsignor(emailAddress, userId, adminEmail);
		}


		protected void verifyConsignor(string consignorEmail, string consignorID, string adminID)
		{
			string dbErr = "dbErr";

			mySqlConnector mySqlConn = new mySqlConnector();
			if (mySqlConn.isInitialized())
			{
				if (mySqlConn.callApproveConsignor(consignorEmail, consignorID, adminID))
				{
					mySqlConn.deInitialize();
					dbErr = "";
				}
			}

			Response.Redirect("~/Admin/Default.aspx?err=" + dbErr + "&f=approveconsignor&eid=" + consignorEmail);

		}
	}
}
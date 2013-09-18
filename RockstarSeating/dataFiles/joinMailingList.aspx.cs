using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RockstarSeating.dataFiles;
using RockstarSeating.Utils;


namespace RockstarSeating.dataFiles
{
	public partial class joinMailingList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string joinSuccess = joinMailingListSuccess();
			Response.Write(joinSuccess);
		}



		protected string joinMailingListSuccess()
		{
			string addToMailingList = Request.QueryString["a"];
			string emailAddress = Request.QueryString["e"];
			string errMsg = String.Empty;

			if (addToMailingList != "")
			{
				mySqlConnector mySqlConn = new mySqlConnector();
				try
				{
					if (mySqlConn.isInitialized())
					{
						return mySqlConn.joinMailingList(emailAddress)?  "true" : mySqlConn.connErrMsg;
					}
					else
					{
						return "db connection err";
					}
				}
				catch(Exception ee)
				{
					errMsg = ee.Message.ToString();
					return "db connection error";
				}

			}
			else
			{
				return "err";
			}
		}
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RockstarSeating.Utils.TNWebSvcs;

namespace RockstarSeating.Sandbox
{
	public partial class geoLocator : System.Web.UI.Page
	{
		public String pluginHTML = String.Empty;

		protected void Page_Load(object sender, EventArgs e)
		{
			String userLocale = String.Empty;

			if (Request.Cookies["userZip"] != null)
			{
				String userZip = Request.Cookies["userZip"].Value;

				this.errMsg.Visible = true;
				this.errMsg.Text = userZip;

				//TODO: delete next line
				//userZip = "59701";
				this.userZipCode.Value = userZip;

				this.use_GetEvent_WebSvc(userZip);
			}
			else
			{
				this.use_GetEvent_WebSvc();
			}
		}


		
		//TODO: Write Code for Getting High
		#region Get High Inventory Performers

		protected void use_GetHighInventoryPerformers_WebSvc(String numReturned, String parentCategoryID, String childCagtegoryID, String grandChildCategoryID)
		{



		}
		protected void use_GetHighInventoryPerformers_WebSvc(String numReturned, String parentCategoryID, String childCagtegoryID)
		{



		}
		protected void use_GetHighInventoryPerformers_WebSvc(String numReturned, String parentCategoryID)
		{

		}

		#endregion
				
		#region Get High Sales Performers

		protected void use_GetHighSalesPerformers_WebSvc(String numReturned, String parentCategoryID, String childCagtegoryID, String grandChildCategoryID)
		{



		}
		protected void use_GetHighSalesPerformers_WebSvc(String numReturned, String parentCategoryID, String childCagtegoryID)
		{



		}
		protected void use_GetHighSalesPerformers_WebSvc(String numReturned, String parentCategoryID)
		{

		}

		#endregion




		protected void use_GetEvent_WebSvc(String userZip = "98101")
		{
			Dictionary<String, String> propsList = new Dictionary<String, String>();

			String numberOfEvents = Request.QueryString["numEvts"];
			String nearZip = Request.QueryString["nearZip"];
			String beginDate = Request.QueryString["begDate"];

			//TODO: delete next line of code
			beginDate = "12/02/2011";


			String endDate = Request.QueryString["endDate"];
			String parentCategoryID = Request.QueryString["pCatID"];			

			propsList.Add("numberOfEvents", (!String.IsNullOrWhiteSpace(numberOfEvents))? numberOfEvents : "20");
			propsList.Add("nearZip", (!String.IsNullOrWhiteSpace(nearZip))? nearZip : userZip);
			propsList.Add("endDate", (!String.IsNullOrWhiteSpace(endDate))? endDate : "12-12-2012");
			propsList.Add("parentCategoryID", (!String.IsNullOrWhiteSpace(parentCategoryID))? parentCategoryID : "1");			
			propsList.Add("orderByClause", "date");	//this will always be by date...because I said so

			if (!String.IsNullOrWhiteSpace(beginDate))
			{
				propsList.Add("beginDate", beginDate);
			}
						
			GetWebService tnWebSvcs = new GetWebService();
			try
			{
				if (tnWebSvcs.callTNWebService("getEvent", propsList))
				{
					ArrayList eventArrayList = tnWebSvcs.returnArrayList;
					this.TicketTable.DataSource = eventArrayList;
					this.TicketTable.DataBind();
				}
				else
				{	//here we reset the call and only show a generic one month list for Seattle, but only if there is no querystring value present
					//TODO: test with querystring values and form controls
					if (String.IsNullOrWhiteSpace(nearZip))
					{
						propsList["nearZip"] = "98101";
					}
					propsList["parentCategoryID"] = "2"; //concerts
					propsList["beginDate"] = null;
					propsList["childCategoryID"] = "62";

					if (tnWebSvcs.callTNWebService("getEvent", propsList))
					{
						ArrayList eventArrayList = tnWebSvcs.returnArrayList;
						this.TicketTable.DataSource = eventArrayList;
						this.TicketTable.DataBind();
						this.userZipCode.Value = propsList["nearZip"];
					}
				}
			}
			catch (Exception e)
			{
				this.errMsg.Text = e.Message.ToString();
			}
		}
		
		


		protected String Get_Cookie()
		{
			String returnVal = String.Empty;

			//Grab the cookie
			HttpCookie cookie = Request.Cookies["userLocale"];

			//Check to make sure the cookie exists
			if (cookie == null)
			{
				returnVal = "Seattle, WA";
			}
			else
			{
				//Write the cookie value
				returnVal = cookie.Value.ToString();
			}


			return returnVal;
		}


	}
}
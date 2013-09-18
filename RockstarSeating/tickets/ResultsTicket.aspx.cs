using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RockstarSeating.dataFiles;


namespace RockstarSeating.tickets
{
    public partial class ResultsTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (IsPostBack)
			{
				string formType = Request.Form["formType"];
				string selPhoneType = Request.Form["selPhoneType"];
				string txtCity = Request.Form["txtCity"];
				string txtDateTime = Request.Form["txtDateTime"];
				string txtDescription = Request.Form["txtDescription"];
				string txtEmail = Request.Form["txtEmail"];
				string txtEvent = Request.Form["txtEvent"];
				string txtFName = Request.Form["txtFName"];
				string txtLName = Request.Form["txtLName"];
				string txtPhone = Request.Form["txtPhone"];
				string txtPriceRange = Request.Form["txtPriceRange"];
				string txtSeating = Request.Form["txtSeating"];
				string txtState = Request.Form["txtState"];
				string txtStreet = Request.Form["txtStreet"];
				string txtStreet2 = Request.Form["txtStreet2"];
				string txtVenue = Request.Form["txtVenue"];
				string txtZip = Request.Form["txtZip"];

				Dictionary<string, string> formDetails = new Dictionary<string, string>();
				formDetails.Add("formType", formType);
				formDetails.Add("Best Time To Call", selPhoneType);
				formDetails.Add("City", txtCity);
				formDetails.Add("Date", txtDateTime);
				formDetails.Add("Description", txtDescription);
				formDetails.Add("Email", txtEmail);
				formDetails.Add("Event", txtEvent);
				formDetails.Add("First Name", txtFName);
				formDetails.Add("Last Name", txtLName);
				formDetails.Add("Phone Number", txtPhone);
				formDetails.Add("Price Range", txtPriceRange);
				formDetails.Add("Seats", txtSeating);
				formDetails.Add("State", txtState);
				formDetails.Add("Address1", txtStreet);
				formDetails.Add("Address2", txtStreet2);
				formDetails.Add("Venue", txtVenue);
				formDetails.Add("Zip", txtZip);


				String strErrMsg = String.Empty;
				mySqlConnector mySqlConn = new mySqlConnector();
				if (mySqlConn.isInitialized())
				{
					if (mySqlConn.sendTicketRequest(formDetails))
					{
						Response.Redirect("~/tickets/ticketRequestSuccess.aspx");
						return;
					}
					else
					{
						strErrMsg = mySqlConn.connErrMsg;
					}
				}
				else
				{
					strErrMsg = "Error connecting to Database.  Please refresh the page and try again.";
				}

				Response.Redirect("~/content/generalError.aspx?e=" + strErrMsg);
				return;
			}
			else
			{

				int bid = 3939;
				int siteId = 3;
				string evtId = Request.QueryString["evtId"];

				string plugin = "<script type=\"text/javascript\" src=\"http://tickettransaction.com/?bid=" + bid;
				plugin += "&sitenumber=" + siteId + "&tid=507&evtid=" + evtId + "\"></script>";
				ticketDetail.Text = plugin;





			//-- FB PLUGIN STUFF	#####################################################
				
				String ogURL = HttpContext.Current.Request.Url.ToString();
					if (ogURL.IndexOf("Jay-Z") > 0 && ogURL.IndexOf("Kanye") > 0)
					{
						ogURL = ogURL + "&fbid=12";
					}

				//title for facebook post/message
				String ogTitle = Request.QueryString["event"];
				ogTitle = ogTitle.Replace("+", " ");
				ogTitle = ogTitle.Replace("%20", " ");


				//the meta tags
				StringBuilder fbMetaTags = new StringBuilder();
					fbMetaTags.Append("<meta property=\"og:title\" content=\"" + ogTitle + "\" />");
					fbMetaTags.Append("<meta property=\"og:type\" content=\"activity\" />");
					fbMetaTags.Append("<meta property=\"og:url\" content=\"" + ogURL + "\" />");
					fbMetaTags.Append("<meta property=\"og:image\" content=\"http://www.rockstarseating.com/assets/img/hdrLogo.png\" />");
					fbMetaTags.Append("<meta property=\"og:site_name\" content=\"Rockstar Seating\" />");
					fbMetaTags.Append("<meta property=\"fb:admins\" content=\"1604973672\" />");
				this.metaTags.Text = fbMetaTags.ToString();
				
	
				// the script
				StringBuilder sb = new StringBuilder();
					sb.Append("<div id=\"fb-root\"></div>");
					sb.Append("<script type=\"text/javascript\">");
					sb.Append("(function (d, s, id) {");
					sb.Append("var js, fjs = d.getElementsByTagName(s)[0];");
					sb.Append("if (d.getElementById(id)) { return; }");
					sb.Append("js = d.createElement(s); js.id = id;");
					sb.Append("js.src = \"//connect.facebook.net/en_US/all.js#xfbml=1&appId=202160576522677\";");
					sb.Append("fjs.parentNode.insertBefore(js, fjs);");
					sb.Append("} (document, 'script', 'facebook-jssdk'));");
					sb.Append("</script>");

					sb.Append("<div class=\"fb-like\" data-href=\"" + ogURL + "\"");
					sb.Append(" data-send=\"true\" data-layout=\"button_count\" data-width=\"200\"");
					sb.Append(" data-show-faces=\"true\" data-action=\"recommend\" data-font=\"arial\"></div>");
				this.likeBtn.Text = sb.ToString();




	

	
	

	
	
	
	
	




			}//end postBack check





        }
    }
}
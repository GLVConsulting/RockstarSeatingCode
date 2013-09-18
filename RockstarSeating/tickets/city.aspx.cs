using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating.tickets
{
    public partial class ResultsCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
		{
			int bid = 3939;
			int siteId = 3;
			int tid = 305;	//uses LOCATION RESULTS
			string sortOrd = Request.QueryString["sortord"];
			string sortCol = Request.QueryString["sortcol"];
			string pageNum = Request.QueryString["pageNum"];
			string city = Request.QueryString["city"];
			string stprvid = Request.QueryString["stprvid"];	//state
			string zip = Request.QueryString["zip"];

			StringBuilder plugin = new StringBuilder();
			plugin.Append("<script type=\"text/javascript\" src=\"http://tickettransaction.com/?bid=" + bid);
			plugin.Append("&sitenumber=" + siteId);
			plugin.Append("&tid=" + tid);
			plugin.Append("&city=" + city);
			plugin.Append("&stprvid=" + stprvid);
			plugin.Append("&sortcol=" + sortCol + "&sortord=" + sortOrd);
			plugin.Append("&pageNum=" + pageNum);
			plugin.Append("&zip=" + zip);
			plugin.Append("\"></script>");
			ticketDetail.Text = plugin.ToString();

			string hdrText = "Events In " + city.ToUpper();
			hdrText = (stprvid == "8") ? hdrText + " DC" : hdrText;
			searchCity.Text = hdrText;

        }
    }
}
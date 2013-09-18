using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating.tickets
{
    public partial class ResultsVenue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            int bid = 3939;
            int siteId = 3;
            string searchTerm = Request.QueryString["venid"];
			string sortOrd = Request.QueryString["sortord"];
			string sortCol = Request.QueryString["sortcol"];
			string pageNum = Request.QueryString["pageNum"];
            

			StringBuilder plugin = new StringBuilder();
			plugin.Append("<script type=\"text/javascript\" src=\"http://tickettransaction.com/?bid=" + bid);
			plugin.Append("&sitenumber=" + siteId + "&tid=304&venid=" + searchTerm);
			plugin.Append("&sortcol=" + sortCol + "&sortord=" + sortOrd);
			plugin.Append("&pageNum=" + pageNum);
			plugin.Append("\"></script>");

			ticketDetail.Text = plugin.ToString();

        }
    }
}
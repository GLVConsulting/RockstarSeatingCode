using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int bid = 3939;
            int siteId = 2;
			int tid = 307;
			string sortOrd = Request.QueryString["sortord"];
			string sortCol = Request.QueryString["sortcol"];
			string pageNum = Request.QueryString["pageNum"];
			string pcatid = Request.QueryString["pcatid"];

			//TODO:  GetDataItem ZIP
			string zip = "";
			
			//get today
			DateTime dt = DateTime.Now;
			string today = dt.ToString("M/d/yy");

			//now get one month from today
			int endMonth = dt.Month + 1;
			int endYear = dt.Year;
			if(endMonth > 12){
				endMonth = 1;
				endYear = endYear + 1;
			}			
			string nextMonth = endMonth + "/" + dt.Day + "/" + endYear;

			//now show concerts, or theatre in localEvents plugin
			int parentCategory;
			Random random = new Random();
			int randNum = random.Next(0, 2);

			//2=concerts, 3=theatre
			if (!string.IsNullOrWhiteSpace(pcatid))
			{
				parentCategory = Convert.ToInt16(pcatid);
			}
			else
			{
				parentCategory = (randNum == 1) ? 2 : 3;
			}

            lblPluginCategory.Visible = false;

			
			StringBuilder plugin = new StringBuilder();
			plugin.Append("<script type=\"text/javascript\" src=\"http://tickettransaction.com/?bid=" + bid);
			plugin.Append("&sitenumber=" + siteId);
			plugin.Append("&tid=" + tid);
			plugin.Append("&zip=" + zip);
			plugin.Append("&sdate=" + today);
			plugin.Append("&edate=" + nextMonth);
			plugin.Append("&pcatid=" + parentCategory);
			plugin.Append("&sortcol=" + sortCol + "&sortord=" + sortOrd);
			plugin.Append("&pageNum=" + pageNum);
			plugin.Append("&showAll=30");
			plugin.Append("\"></script>");
            ticketDetail.Text = plugin.ToString();
        }
    }
}

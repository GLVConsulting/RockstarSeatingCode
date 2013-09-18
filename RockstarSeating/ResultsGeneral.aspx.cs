using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating
{
	public partial class ResultsGeneral : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string searchTerm = Request.QueryString["kwds"];

			string sortOrd = Request.QueryString["sortord"];
			string sortCol = Request.QueryString["sortcol"];
			string pageNum = Request.QueryString["pageNum"];

			string venid = Request.QueryString["venid"];
			string city = Request.QueryString["city"];
			string zip = Request.QueryString["zip"];
			string stprvid = Request.QueryString["stprvid"];
			string countryid = Request.QueryString["countryid"];

			string pcatid = Request.QueryString["pcatid"];
			string ccatid = Request.QueryString["ccatid"];
			string gcatid = Request.QueryString["gcatid"];

			string sdate = Request.QueryString["sdate"];
			string edate = Request.QueryString["edate"];

			string stype = Request.QueryString["stype"];

			StringBuilder queryParams = new StringBuilder();
			queryParams.Append("?kwds=" + searchTerm);
			queryParams.Append("&sortcol=" + sortCol + "&sortord=" + sortOrd + "&pageNum=" + pageNum);
			queryParams.Append("&venid=" + venid);
			queryParams.Append("&city=" + city);
			queryParams.Append("&zip=" + zip);
			queryParams.Append("&stprvid=" + stprvid);
			queryParams.Append("&countryid=" + countryid);
			queryParams.Append("&pcatid=" + pcatid);
			queryParams.Append("&ccatid=" + ccatid);
			queryParams.Append("&gcatid=" + gcatid);
			queryParams.Append("&sdate=" + sdate);
			queryParams.Append("&edate=" + edate);
			queryParams.Append("&stype=" + stype);

			Response.Redirect("~/tickets/search.aspx" + queryParams.ToString());
		}
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating.tickets
{
    public partial class ResultsCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

			//TODO: add this category info into the db for cross reference??

			//PARENT CATEGORIES
			Hashtable categories = new Hashtable();
			categories.Add(1, "SPORTS");
			categories.Add(2, "CONCERTS");
			categories.Add(3, "THEATRE");
			categories.Add(4, "OTHER");

			//CHILD CATEGORIES
			Hashtable c_Categories = new Hashtable();
			c_Categories.Add(22, "ALTERNATIVE");
			c_Categories.Add(60, "BALLET");
			c_Categories.Add(63, "BASEBALL");
			c_Categories.Add(66, "BASKETBALL");
			c_Categories.Add(46, "BLUEGRASS");
			c_Categories.Add(50, "BOXING");
			c_Categories.Add(70, "BROADWAY");
			c_Categories.Add(55, "CHILDREN / FAMILY SHOWS");
			c_Categories.Add(43, "CHRISTIAN / RELIGIOUS");
			c_Categories.Add(59, "CIRCUS");
			c_Categories.Add(49, "CLASSICAL");
			c_Categories.Add(24, "COMEDY");
			c_Categories.Add(23, "COUNTRY / FOLK");
			c_Categories.Add(58, "FAIRS / FESTIVALS");
			c_Categories.Add(65, "FOOTBALL");
			c_Categories.Add(67, "GOLF");
			c_Categories.Add(61, "HARD ROCK / METAL");
			c_Categories.Add(68, "HOCKEY");
			c_Categories.Add(21, "JAZZ / BLUES");
			c_Categories.Add(76, "LACROSSE");
			c_Categories.Add(35, "LAS VEGAS");
			c_Categories.Add(34, "LAS VEGAS SHOWS");
			c_Categories.Add(73, "LATIN");
			c_Categories.Add(72, "MAGIC SHOWS");
			c_Categories.Add(38, "MUSICAL / PLAY");
			c_Categories.Add(48, "NEW AGE / SPIRITUAL");
			c_Categories.Add(32, "OFF-BROADWAY");
			c_Categories.Add(75, "OPERA");
			c_Categories.Add(74, "OTHER");
			c_Categories.Add(33, "OTHER");
			c_Categories.Add(37, "OTHER");
			c_Categories.Add(41, "OTHER");
			c_Categories.Add(62, "POP / ROCK");
			c_Categories.Add(45, "R&B / SOUL");
			c_Categories.Add(69, "RACING");
			c_Categories.Add(36, "RAP / HIP HOP");
			c_Categories.Add(53, "RODEO");
			c_Categories.Add(77, "RUGBY");
			c_Categories.Add(52, "SKATING");
			c_Categories.Add(71, "SOCCER");
			c_Categories.Add(27, "TENNIS");
			c_Categories.Add(47, "VOLLEYBALL");
			c_Categories.Add(57, "WORLD");
			c_Categories.Add(39, "WRESTLING");

			//Grandchild Category
			Hashtable g_Categories = new Hashtable();
			g_Categories.Add(40, "AHL");
			g_Categories.Add(20, "Auto");
			g_Categories.Add(36, "CFL");
			g_Categories.Add(17, "College");
			g_Categories.Add(41, "ECHL");
			g_Categories.Add(37, "Frontier League");
			g_Categories.Add(35, "Horse");
			g_Categories.Add(33, "Ice (figure)");
			g_Categories.Add(34, "Ice (show)");
			g_Categories.Add(39, "IHL");
			g_Categories.Add(27, "Minors (AAA)");
			g_Categories.Add(21, "Motorcycle");
			g_Categories.Add(32, "NFL");
			g_Categories.Add(38, "NLL");
			g_Categories.Add(29, "Other");
			g_Categories.Add(16, "Professional (MLB)");
			g_Categories.Add(22, "Professional (MLS)");
			g_Categories.Add(30, "Professional (NBA)");
			g_Categories.Add(19, "Professional (NHL)");
			g_Categories.Add(18, "Professional (PGA)");
			g_Categories.Add(24, "Professional (USPTA)");
			g_Categories.Add(31, "Professional (WNBA)");
			g_Categories.Add(28, "World Cup");
			g_Categories.Add(26, "WWE");


            int bid = 3939;
            int siteId = 3;
			int tid = 307;
			string sortOrd = Request.QueryString["sortord"];
			string sortCol = Request.QueryString["sortcol"];
			string pageNum = Request.QueryString["pageNum"];
			
			string pcatid = Request.QueryString["pcatid"];
			string ccatid = Request.QueryString["ccatid"];
			string gcatid = Request.QueryString["gcatid"];
			
			string zip = Request.QueryString["zip"];
			string venid = Request.QueryString["venid"];
			string city = Request.QueryString["city"];

			string sdate = Request.QueryString["sdate"];
			string edate = Request.QueryString["edate"];
			

			
			StringBuilder plugin = new StringBuilder();
			plugin.Append("<script type=\"text/javascript\" src=\"http://tickettransaction.com/?bid=" + bid);
			plugin.Append("&sitenumber=" + siteId);
			plugin.Append("&tid=" + tid);
			plugin.Append("&sortcol=" + sortCol + "&sortord=" + sortOrd);
			plugin.Append("&pageNum=" + pageNum);

			plugin.Append("&pcatid=" + pcatid);
			plugin.Append("&ccatid=" + ccatid);
			plugin.Append("&gcatid=" + gcatid);

			plugin.Append("&zip=" + zip);
			plugin.Append("&venid=" + venid);
			plugin.Append("&city=" + city);

			plugin.Append("&sdate=" + sdate);
			plugin.Append("&edate=" + edate);

			plugin.Append("\"></script>");

			ticketDetail.Text = plugin.ToString();

			//pluginCategory.Text = "SOMETHING SOMETHING.";
			pluginCategory.Visible = false;
        }
    }
}
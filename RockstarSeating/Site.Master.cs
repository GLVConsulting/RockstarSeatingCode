using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RockstarSeating.dataFiles;
using RockstarSeating.baseClasses;

namespace RockstarSeating
{

    public partial class SiteMaster : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String liveUrl = "glvconsulting.com/portfolio";

            String dUrl = HttpContext.Current.Request.Url.ToString();
            
            if (dUrl.IndexOf("glvconsulting.com") > -1 && dUrl.IndexOf("glvconsulting.com/") < 0)
            {
                Response.Redirect("http://www.glvconsulting.com/site/");
            }

            else if (dUrl.IndexOf("glvconsulting.com/default.aspx") > -1)
            {
                Response.Redirect("http://www.glvconsulting.com/site/");
            }

            else if (dUrl.IndexOf(liveUrl) > -1)
            {
                dUrl.Replace("/portfolio/", "/site/portfolio/");
                Response.Redirect(dUrl);
            }
            else
            {
            }



        }
    }
}


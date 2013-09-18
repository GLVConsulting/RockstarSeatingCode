using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockstarSeating.tickets
{
    public partial class ResultsEmpty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			//TODO: in order to redirect to a general results search and avoid an endless loop..
			// use a session variable set on initial page load.  after redirect, check value and break loop that way.

        }
    }
}
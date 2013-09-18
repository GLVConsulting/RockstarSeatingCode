using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RockstarSeating.dataFiles;
using RockstarSeating.Utils;
using RockstarSeating.baseClasses;

namespace RockstarSeating.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected Boolean isLoggedIn = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Request.IsSecureConnection)
            {
                String curUrl = Request.Url.ToString();

                if (curUrl.IndexOf("testlab") < 0)
                {
                    string redirectUrl = curUrl.Replace("http:", "https:");
                    Response.Redirect(redirectUrl);
                }
            }


            if (IsPostBack)
            {
                authenticateUser();
            }
            else
            {
                isLoggedIn = Convert.ToBoolean(Session["isLoggedIn"]);
                
                if (isLoggedIn)
                {
                    Response.Redirect("~/Account/myAccount.aspx");
                }
            }
        }




        protected void authenticateUser()
        {
            mySqlConnector mySqlconn = new mySqlConnector();
            if (mySqlconn.isInitialized())
            {
                if (mySqlconn.login(EmailAddress.Text, Password.Text, false))
                {
                    //validated, so write user session info
                    Session["firstname"] = mySqlconn.UserObj.FirstName;
                    Session["lastName"] = mySqlconn.UserObj.LastName;
                    Session["emailAddress"] = mySqlconn.UserObj.Email;
                    Session["isConsignor"] = mySqlconn.UserObj.isConsignor;
                    Session["isAdmin"] = mySqlconn.UserObj.isAdmin;
                    Session["userId"] = mySqlconn.UserObj.UserId;
                    Session["isLoggedIn"] = true;

                    //close connection
                    mySqlconn.deInitialize();
                    //success!
                    redirectUser();
                }
                else
                {//AUTHENTICATION HAS FAILED
                    //displayResponseMessage(true, "Email & password combination are incorrect.  <br/>Please try again.");
                    string errMsg = mySqlconn.connErrMsg;

                    if (errMsg.IndexOf("Please register") > 0)
                    {
                        displayResponseMessage(true, errMsg);
                    }
                    else
                    {
                        displayResponseMessage(true, mySqlconn.connErrMsg);
                        return;
                    }
                }
            }
            else
            {
                string whatGives = mySqlconn.testConnection();
                displayResponseMessage(true, "Database Connection Failure: " + whatGives);
            }

        }


        protected void displayResponseMessage(bool show, string msg = "")
        {
            if (show)
            {
                responseText.Visible = true;
                responseText.Text = "<b>Error</b>: " + msg;
            }
            else
            {
                responseText.Visible = false;
            }
        }

        protected void redirectUser()
        {
            //push user to new page
            if (Convert.ToString(Session["autofill"]) == "yes")
            {
                Response.Redirect("~/Inventory");
            }
            else if(Convert.ToBoolean(Session["isAdmin"]))
            {
                Response.Redirect("~/Admin");
            }
            Response.Redirect("~/Account/myAccount.aspx");
        }

        protected void autoLogin()
        {
            mySqlConnector mySqlconn = new mySqlConnector();
            if (mySqlconn.isInitialized())
            {
                responseText.Visible = true;
                if (mySqlconn.login("me@me.com", "testing"))
                {
                    //validated, so write user session info
                    Session["firstname"] = mySqlconn.UserObj.FirstName;
                    Session["lastName"] = mySqlconn.UserObj.LastName;
                    Session["emailAddress"] = mySqlconn.UserObj.Email;
                    Session["isConsignor"] = mySqlconn.UserObj.isConsignor;
                    Session["isAdmin"] = mySqlconn.UserObj.isAdmin;
                    Session["userId"] = mySqlconn.UserObj.UserId;
                    Session["isLoggedIn"] = true;

                    //close connection
                    mySqlconn.deInitialize();

                    redirectUser();
                }
                else
                {
                    //displayResponseMessage(true, "Email & password combination are incorrect.  <br/>Please try again.");
                    displayResponseMessage(true, mySqlconn.connErrMsg);
                }
            }
            else
            {
                string whatGives = mySqlconn.testConnection();
                displayResponseMessage(true, "Database Connection Failure: " + whatGives);
            }

        }
    }
}

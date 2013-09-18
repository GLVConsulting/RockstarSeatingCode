using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RockstarSeating.dataFiles;

namespace RockstarSeating.Inventory
{
    public partial class _default : System.Web.UI.Page
    {
        string saveErr = string.Empty;
        List<string> saveErrs;


        protected void Page_Load(object sender, EventArgs e)
        {

            //this code for sellBtn referer
            String autoFill = Request.QueryString["autofill"];
            if (autoFill == "yes")
            {
                String eventTitle = Request.QueryString["event"];
                String venue = Request.QueryString["venue"];
                String eventDate = Request.QueryString["eventDate"];
                String eventTime = Request.QueryString["eventTime"];

                Session["autofill"] = "yes";
                Session["event"] = eventTitle;
                Session["venue"] = venue;
                Session["eventDate"] = eventDate;
                Session["eventTime"] = eventTime;
            }
            else
            {
                if (Convert.ToString(Session["autofill"]) != "yes")
                {
                    Session["autofill"] = "no";
                }
            }


            //now check secure connection
            if (!Request.IsSecureConnection)
            {
                string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(redirectUrl);
            }

            checkUserStatus();
        }

        


        protected void checkUserStatus()
        {
            Boolean isConsignor = Convert.ToBoolean(Session["isConsignor"]);
            Boolean isLoggedIn = Convert.ToBoolean(Session["isLoggedIn"]);

            if (!Request.IsSecureConnection || !isLoggedIn)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else if (!isConsignor)
            {
                Response.Redirect("~/Account/RequestConsignorStatus.aspx");
            }
            else
            {

                saveErrs = new List<string>();
                ErrorMessage.Text = "";

                if (!IsPostBack)
                {
                    for (int ix = 1; ix <= 12; ix++)
                    {
                        ddlHours.Items.Add(ix.ToString("00"));
                    }
                    for (int xx = 0; xx <= 59; xx++)
                    {
                        ddlMins.Items.Add(xx.ToString("00"));
                    }
                    Session["dateSelected"] = "no";

                    this.btnSubmit.Enabled = false;

                    if (Convert.ToString(Session["autofill"]) == "yes")
                    {
                        this.Event.Text = Convert.ToString(Session["event"]);
                        this.Venue.Text = Convert.ToString(Session["venue"]);

                        String eventDate = Convert.ToString(Session["eventDate"]);

                        //convert from mm/dd/yyyy
                            String StrEventMonth = eventDate.Substring(0, eventDate.IndexOf("/"));
                            int eventMonth = Convert.ToInt16(StrEventMonth) - 1;
                            String eventDay = eventDate.Substring(eventDate.IndexOf("/") + 1);
                            eventDay = eventDay.Substring(0, eventDay.IndexOf("/"));
                            String eventYear = eventDate.Substring(eventDate.LastIndexOf("/") + 1);

                        eventDate = eventYear + "," + eventMonth + "," + eventDay;
                        
                        //now set datepicker
                        String dScript = "<script language = \"javascript\"> $('#MainContent_DatePicker').datepicker(\"setDate\", new Date(" + eventDate + ")); </script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "setDatePicker", dScript);



                        String eventTime = Convert.ToString(Session["eventTime"]);
                        //parse date out, check for AM and PM, handle accordingly

                        String hh = eventTime.Substring(0, eventTime.IndexOf(":"));
                        this.ddlHours.SelectedValue = hh.PadLeft(2, '0');

                        String mm = eventTime.Substring(eventTime.IndexOf(":") + 1, 2);
                        this.ddlMins.SelectedValue = mm;
                        
                        String tod = (eventTime.ToLower().IndexOf("pm") > 0) ? "PM" : "AM";
                        this.ddlMeridian.SelectedValue = tod;
                    }
                }
                else
                {
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        getFormData();
                    }
                    else
                    {
                        displayFormErrors(saveErrs);
                        return;
                    }
                }
            }
        }



        protected void getFormData()
        {
            string EventTime = string.Empty;
            string event_Hr = ddlHours.Text;
            string event_Mins = ddlMins.Text;
            string event_Meridian = ddlMeridian.Text;

            if (event_Meridian == "PM")
            {
                switch (Convert.ToInt16(event_Mins))
                {
                    case 1:
                        event_Mins = "13";
                        break;
                    case 2:
                        event_Mins = "14";
                        break;
                    case 3:
                        event_Mins = "15";
                        break;
                    case 4:
                        event_Hr = "16";
                        break;
                    case 5:
                        event_Hr = "17";
                        break;
                    case 6:
                        event_Hr = "18";
                        break;
                    case 7:
                        event_Hr = "19";
                        break;
                    case 8:
                        event_Hr = "20";
                        break;
                    case 9:
                        event_Hr = "21";
                        break;
                    case 10:
                        event_Hr = "22";
                        break;
                    case 11:
                        event_Hr = "23";
                        break;
                    case 12:
                        event_Hr = "24";
                        break;
                }

            }

            EventTime = event_Hr + ":" + event_Mins + ":00";

            //get values into dictionary
            Dictionary<string, string> formData = new Dictionary<string, string>()
            {
                {"Event Title", Event.Text},
                {"Venue", Venue.Text},
                {"Row", Row.Text},
                {"Seat From", Section.Text},
                {"Seat Thru", SeatThru.Text}, 
                {"Section", Section.Text}, 
                {"Quantity", Quantity.Text},
                {"Cost", Cost.Text},
                {"Event Time", EventTime},
                {"Event Date", DatePicker.Text},
                {"Notes", Notes.Text},
                {"UserId", Session["userId"].ToString()},
                {"EmailAddress", Session["emailAddress"].ToString()}
            };

            saveInventoryForm(formData);
            Response.Redirect("~/Account/myAccount.aspx");
            
        }


        protected void saveInventoryForm(Dictionary<string, string> inventoryUploadForm)
        {
            saveErr = "";

            try
            {
                mySqlConnector mySqlConn = new mySqlConnector();
                if (mySqlConn.isInitialized())
                {
                    saveErr = mySqlConn.uploadInventory(inventoryUploadForm) ? "" : mySqlConn.connErrMsg;
                    if (saveErr != "")
                    {
                        displayFormErrors();
                    }
                    mySqlConn.deInitialize();
                }
                else
                {
                    if (mySqlConn.connErrMsg == "already registered")
                    {
                        saveErr = "Email Address already registered.";
                        //trigger reset password link
                    }
                    else
                    {
                        saveErr = "Error connecting to database. Please try again later.";
                    }
                    displayFormErrors();
                    return;
                }
            }
            catch (Exception ee)
            {
                saveErr = ee.Message.ToString();
                displayFormErrors();
                return;
            }


            //push user to success page and consignment agreement
           // Response.Redirect("~/Default.aspx");
        }
        
        protected void displayFormErrors(List<string> multiErrs = null)
        {
            ErrorMessage.Visible = true;
            if (multiErrs != null)
            {
                ErrorMessage.Text = "Errors:<ul>" + string.Join("", multiErrs) + "</ul>";
            }
            else
            {
                ErrorMessage.Text = "Error: " + saveErr;
            }
        }
        
        protected void QuantityInt_Validator(object source, ServerValidateEventArgs args)
        {
            int result;
            Boolean passedValidation = int.TryParse(Quantity.Text, out result);
            if (!passedValidation)
            {
                saveErrs.Add("<li>The Cost field will only accept a whole number, without commas.<li>");
            }
            args.IsValid = passedValidation;
        }
        
        protected void CostInt_Validator(object source, ServerValidateEventArgs args)
        {
            int result;
            Boolean passedValidation = int.TryParse(Cost.Text, out result);
            if (!passedValidation)
            {
                saveErrs.Add("<li>The Cost field will only accept a whole number, without commas.<li>");
            }
            args.IsValid = passedValidation;
        }

    }
}
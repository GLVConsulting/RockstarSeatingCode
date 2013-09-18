using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using RockstarSeating.Utils;

using RockstarSeating.dataFiles;

namespace RockstarSeating.Account
{
    public partial class Register : System.Web.UI.Page
    {

        List<string> invalidFlds = new List<string>();
        string saveErr = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsSecureConnection)
            {
                string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(redirectUrl);
            }


            if (IsPostBack)
            {
                //ErrorMessage.Text = "";
                this.formErrors.Visible = false;
                Page.Validate("RegisterUserValidationGroup");

                if (Page.IsValid)
                {
                    getRegisterUserForm();
                }
                else
                {
                    this.formErrors.Visible = true;
                }
            }
        }

        protected void getRegisterUserForm()
        {
            //Boolean formValidated = false;
            Boolean mailingListOptIn = OptIn.Checked;
			SaltUtility saltTool = new SaltUtility();



            //get values into dictionary
            Dictionary<string, string> registerForm = new Dictionary<string, string>()
            {
                {"First Name", FirstName.Text},
                {"Last Name", LastName.Text},
                {"Email", Email.Text},
                {"Phone Number", PhoneNumber.Text},
                {"Password", Password.Text}, 
                {"Confirm Password", ConfirmPassword.Text}, 
                {"Address1", Address1.Text},
                {"Address2", Address2.Text},
                {"City", City.Text},
                {"State", State.Text},
                {"Zip", Zip.Text},
                {"Zip2", Zip2.Text},
                {"OptIn", mailingListOptIn.ToString()},
				{"LoginHash", saltTool.randomString(16)},
				{"LoginV", saltTool.randomString(16)},
				{"ConsignorCode", saltTool.randomString(8)},
                {"AcceptedAgreement", hidAcceptedAgreement.Value.ToString()}
            };

            saveUserInfo(registerForm);

        }
        protected void saveUserInfo(Dictionary<string, string> formInfo)
        {
            saveErr = "";

            try
            {
                mySqlConnector mySqlConn = new mySqlConnector();
                if (mySqlConn.isInitialized() && mySqlConn.registerUser(formInfo))
                {
                    saveErr = mySqlConn.login(Email.Text, Password.Text) ? "" : mySqlConn.connErrMsg;
                    if (saveErr != "")
                    {
                        displayFormErrors();
                        mySqlConn.deInitialize();
                    }
                    else
                    {   //write session out for sng
                        Session["emailAddress"] = Email.Text;
                        Session["firstName"] = FirstName.Text;
                        Session["lastName"] = LastName.Text;
                        Session["isLoggedIn"] = true;
                        Session["userId"] = mySqlConn.UserObj.UserId;

                        //push user to success page and consignment agreement
                        mySqlConn.deInitialize();
                        Response.Redirect("RegisterSuccess.aspx");
                    }
                }
                else
                {
                    if (mySqlConn.connErrMsg == "already registered")
                    {
                        saveErr = "Email Address already registered.";
                    }
                    else
                    {
						//TODO: refactor this code to produce a more specific error that can be reported??
                        saveErr = mySqlConn.connErrMsg;
                    }
                    displayFormErrors();
                }
            }
            catch (Exception ee)
            {
                saveErr = ee.Message.ToString();
                displayFormErrors();
            }
        }




        protected void displayFormErrors()
        {
			backEndErrors.Visible = true;
            ErrorMessage.Text = "Error: " + saveErr;
        }






        /*********  BEGIN: VALIDATOR EVENT HANDLERS    ***************************/

        protected void PasswordLength_Validator(object source, ServerValidateEventArgs args)
        {
            Boolean minCheck = (Password.Text.Length > 5);
            Boolean maxCheck = (Password.Text.Length < 16);
            Boolean passedValidation = (minCheck && maxCheck);
            args.IsValid = passedValidation;
        }

        protected void ZipCodeInt_Validator(object source, ServerValidateEventArgs args)
        {
            //BACKEND VALIDATOR, removing because i dont care about nonJS users.   lv 9/15/11
            int result;
            Boolean passedValidation = int.TryParse(Zip.Text, out result);
            args.IsValid = passedValidation;
        }

        protected void ZipCodeLength_Validator(object source, ServerValidateEventArgs args)
        {
            //BACKEND VALIDATOR, removing because i dont care about nonJS users.   lv 9/15/11
            Boolean passedValidation = (Zip.Text.Length == 5);
            args.IsValid = passedValidation;
        }




        /*********  END: VALIDATOR EVENT HANDLERS    ***************************/
    }
}

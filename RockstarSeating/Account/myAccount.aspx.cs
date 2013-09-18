using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RockstarSeating.dataFiles;

using RockstarSeating.Utils;

namespace RockstarSeating.Account
{
    public partial class myAccount : System.Web.UI.Page
    {
        protected Boolean isLoggedIn = false;
        protected Boolean isConsignor = false;
		protected Boolean isAdmin = false;
		protected String stateVal = String.Empty;
		string saveErr = string.Empty;
                
        protected void Page_Load(object sender, EventArgs e)
        {            
            isLoggedIn = Convert.ToBoolean(Session["isLoggedIn"]);
            isConsignor = Convert.ToBoolean(Session["isConsignor"]);
            isAdmin = Convert.ToBoolean(Session["isAdmin"]);

            if (!isLoggedIn)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                if (!Request.IsSecureConnection)
                {
                    string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                    Response.Redirect(redirectUrl);
                }
                else
                {

					if (!Request.IsSecureConnection)
					{
						string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
						Response.Redirect(redirectUrl);
					}

					if (isConsignor && !IsPostBack)
					{
						showConsignorsPanel();
					}
                }
            }
        }


		protected void fillEditUserForm()
		{
			consignorsPanel.Visible = false;
			editUserInfo.Visible = false;

			mySqlConnector mySqlConn = new mySqlConnector(); 
			if(mySqlConn.isInitialized()){

				if (mySqlConn.getUserInfo(Session["emailAddress"].ToString()))
				{
					FirstName.Text = mySqlConn.UserObj.FirstName;
					LastName.Text = mySqlConn.UserObj.LastName;
					Email.Text = mySqlConn.UserObj.Email;
					
					//split this string
					PhoneNumber.Text = mySqlConn.UserObj.Phone;

					Address1.Text = mySqlConn.UserObj.Address1;
					Address2.Text = mySqlConn.UserObj.Address2;
					City.Text = mySqlConn.UserObj.City;
					State.SelectedValue = State.Items.FindByValue(mySqlConn.UserObj.State).Value;
					stateVal = mySqlConn.UserObj.State;

					//split this string
					Zip.Text = mySqlConn.UserObj.Zip;
					Zip2.Text = mySqlConn.UserObj.Zip2;

					OptIn.Checked = mySqlConn.UserObj.mailingList;
				}


			}
			else{
				displayEditErrors("DB Error. Please refresh and try again.");
			}


		}

		protected void setStateValue(Object sender, EventArgs e)
		{
			//State.SelectedValue = State.Items.FindByText(stateVal).Value;
		}


		protected void getEditUserForm(Object sender, EventArgs e)
		{
			this.formErrors.Visible = false;
			Page.Validate("UpdateUserInfoValidationGroup");

			if(!Page.IsValid){
				this.formErrors.Visible = true;
				return;
			}

			Boolean mailingListOptIn = OptIn.Checked;

			//get values into dictionary
			Dictionary<string, string> userInfoEditForm = new Dictionary<string, string>()
            {
				{"userId", Session["userId"].ToString()},
                {"First Name", FirstName.Text},
                {"Last Name", LastName.Text},
                {"Email", Email.Text},
                {"Phone Number", PhoneNumber.Text},
                {"Address1", Address1.Text},
                {"Address2", Address2.Text},
                {"City", City.Text},
                {"State", State.Text},
                {"Zip", Zip.Text},
                {"Zip2", Zip2.Text},
                {"OptIn", mailingListOptIn.ToString()}
            };

			saveEditedUserInfo(userInfoEditForm);
		}

		protected void saveEditedUserInfo(Dictionary<string, string> formInfo)
		{
			saveErr = "";

			try
			{
				mySqlConnector mySqlConn = new mySqlConnector();
				if (mySqlConn.isInitialized())
				{
					saveErr = mySqlConn.saveUserEditInfo(Email.Text, formInfo) ? "" : mySqlConn.connErrMsg;
					if (saveErr != "")
					{
						displayEditErrors(saveErr);
						mySqlConn.deInitialize();
					}
					else
					{   //write new session values
						Session["emailAddress"] = formInfo["Email"];
						Session["firstname"] = formInfo["First Name"];
						Session["lastName"] = formInfo["Last Name"];

						mySqlConn.deInitialize();
						resetPage("Your Information has been updated!");						
					}
				}
				else
				{
					displayEditErrors(mySqlConn.connErrMsg);
				}
			}
			catch (Exception ee)
			{
				displayEditErrors(ee.Message.ToString());
			}
		}



		protected void resetPage(String statusMsg = "")
		{
			if (isConsignor)
			{
				showConsignorsPanel();
			}
			editUserInfo.Visible = true;		//show btn
			accountPanel.Visible = false;


			if (statusMsg != "")
			{
				this.statusMsg.Text = statusMsg;
				this.statusMsg.Visible = true;
			}
		}

		protected void showConsignorsPanel()
        {

			string errMsg = string.Empty;
   
            mySqlConnector mySqlConn = new mySqlConnector();

            if (mySqlConn.isInitialized())
            {
				BoundField eventTitle = new BoundField();
				eventTitle.ReadOnly = true;
				eventTitle.HeaderText = "Event";
				eventTitle.DataField = "eventtitle";
				//eventTitle.SortExpression = "eventtitle";
				gvExportList.Columns.Add(eventTitle);

				BoundField venue = new BoundField();
				venue.ReadOnly = true;
				venue.HeaderText = "Venue";
				venue.DataField = "venue";
				//venue.SortExpression = "venue";
				gvExportList.Columns.Add(venue);

				BoundField eventDate = new BoundField();
				eventDate.ReadOnly = true;
				eventDate.HeaderText = "Date";
				eventDate.DataField = "eventdate";
				//eventDate.SortExpression = "eventdate";
				gvExportList.Columns.Add(eventDate);

				BoundField eventTime = new BoundField();
				eventTime.ReadOnly = true;
				eventTime.HeaderText = "Time";
				eventTime.DataField = "eventtime";
			//	eventTime.SortExpression = "eventtime";
				gvExportList.Columns.Add(eventTime);

				BoundField qty = new BoundField();
				qty.ReadOnly = true;
				qty.HeaderText = "Qty";
				qty.DataField = "quantity";
				//qty.SortExpression = "quantity";
				gvExportList.Columns.Add(qty);

				BoundField sec = new BoundField();
				sec.ReadOnly = true;
				sec.HeaderText = "Section";
				sec.DataField = "section";
				//sec.SortExpression = "section";
				gvExportList.Columns.Add(sec);

				BoundField seatRow = new BoundField();
				seatRow.ReadOnly = true;
				seatRow.HeaderText = "Row";
				seatRow.DataField = "seatrow";
				//seatRow.SortExpression = "seatrow";
				gvExportList.Columns.Add(seatRow);

				BoundField seatFrom = new BoundField();
				seatFrom.ReadOnly = true;
				seatFrom.HeaderText = "From";
				seatFrom.DataField = "seatfrom";
				//seatFrom.SortExpression = "seatfrom";
				gvExportList.Columns.Add(seatFrom);

				BoundField seatThru = new BoundField();
				seatThru.ReadOnly = true;
				seatThru.HeaderText = "Thru";
				seatThru.DataField = "seatthru";
				//seatThru.SortExpression = "seatthru";
				gvExportList.Columns.Add(seatThru);

				BoundField cost = new BoundField();
				cost.ReadOnly = true;
				cost.HeaderText = "Price";
				cost.DataField = "cost";
				//cost.SortExpression = "cost";
				gvExportList.Columns.Add(cost);

				BoundField cNotes = new BoundField();
				cNotes.ReadOnly = true;
				cNotes.HeaderText = "Notes";
				cNotes.DataField = "consignornotes";
				//cNotes.SortExpression = "consignornotes";
				gvExportList.Columns.Add(cNotes);

				//now make call to database for rows
				if (mySqlConn.getExportList(Convert.ToInt16(Session["userId"]), true))
				{
					gvExportList.DataSource = null;
					gvExportList.Dispose();
					gvExportList.DataSource = mySqlConn.ds;
					gvExportList.DataBind();
				}
				else
				{
					noExports.Text = mySqlConn.connErrMsg;
					noExports.Visible = true;
				}
            }
            else
            {
                errMsg = "db connection error!";
                displayMySqlConnErr(errMsg);
            }


            mySqlConn.deInitialize();

            consignorsPanel.Visible = true;

        }
        protected void showAccountPanel(object sender, EventArgs e)
        {
            accountPanel.Visible = true;
			fillEditUserForm();
        }
		protected void cancelEditUserInfoForm(object sender, EventArgs e)
        {
			resetPage();
        }



		#region VALIDATOR EVENT HANDLERS


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

		#endregion



		protected void displayMySqlConnErr(string strErrMsg)
        {
            ErrorMessage.Text = "Errors:<ul><li>" + strErrMsg + "</li></ul>";
			backEndErrors.Visible = true;
        }
		protected void displayEditErrors(String errMsg)
		{
			vErrMsg.Text = errMsg;
			validationBox.Visible = true;
		}



	}
}
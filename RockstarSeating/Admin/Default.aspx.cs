using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RockstarSeating.dataFiles;
using RockstarSeating.Utils;

namespace RockstarSeating.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean isAdmin = Convert.ToBoolean(Session["isAdmin"]);
			Boolean isLoggedIn = Convert.ToBoolean(Session["isLoggedIn"]);

			if (!isLoggedIn)
			{
				Response.Redirect("~/Account/Login.aspx");
			}



            if (!Request.IsSecureConnection)
            {
                string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(redirectUrl);
            }
            else if (!isAdmin && !Request.IsSecureConnection)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                getLastExportTime();
				showPendingInventoryExports();
				checkForConsignmentApprovals();
            }
        }


        protected void getLastExportTime()
        {
            string lastExport = String.Empty;
            mySqlConnector mySqlConn = new mySqlConnector();

            if (mySqlConn.isInitialized())
            {
                lastExport = mySqlConn.getLastInventoryExport();
            }
            else
            {
                lastExport = "db connection error!";
            }
            mySqlConn.deInitialize();
            lastExported.Text = lastExport;
        }




        protected void exportBtn_click(object sender, EventArgs e)
        {
            //ten fields for export
            string[] columnHeaderList = new string[]{"Event, Venue, EventDate, EventTime, Quantity, Section, Row, SeatFrom, SeatThru, Notes, Cost"};            
            
            List<List<string>> exportList;

            mySqlConnector mySqlConn = new mySqlConnector();

            if (mySqlConn.isInitialized())
            {
                exportList = mySqlConn.exportLatestUploads();

				if (exportList.Count < 1)
				{
					noExports.Text = "Nothing to export.";
					noExports.Visible = true;
				}
				else
				{
					List<string> exportItem = exportList[0];
					if (exportItem[0].IndexOf("Error:") > -1)
					{
						displayFormErrors(exportList[0].ToString());
					}
					else
					{
						mySqlConn.deInitialize();
						showPendingInventoryExports();
						CSVExporter csvExport = new CSVExporter(exportList, columnHeaderList);
					}

				}
                mySqlConn.deInitialize();
            }
            else
            {
                displayFormErrors("Error connecting to database!");
            }
        }

        protected void viewBtn_click(object sender, EventArgs e)
        {
			showPendingInventoryExports();
        }


		protected void GVExportList_Clear()
		{

			gvExportList.DataSource = null;
			gvExportList.Dispose();
			gvExportList.Columns.Clear();

		}

		protected void showPendingInventoryExports()
		{
			string errMsg = string.Empty;

			mySqlConnector mySqlConn = new mySqlConnector();

			if (mySqlConn.isInitialized())
			{
				if (mySqlConn.getExportList())
				{
					GVExportList_Clear();

					if (gvExportList.Columns.Count < 1)
					{

						BoundField userId = new BoundField();
						userId.ReadOnly = true;
						userId.HeaderText = "UserId";
						userId.DataField = "emailaddress";
						//userId.SortExpression = "emailaddress";
						gvExportList.Columns.Add(userId);

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

						gvExportList.DataSource = mySqlConn.ds;
						gvExportList.DataBind();
					}
				}
				else
				{
					GVExportList_Clear();
					noExports.Text = mySqlConn.connErrMsg;
					noExports.Visible = true;
				}
			}
			else
			{
				errMsg = "db connection error!";
				displayFormErrors(errMsg);
			}


			mySqlConn.deInitialize();


		}


		protected void checkForConsignmentApprovals()
		{
			string errMsg = string.Empty;
			string statusMsg = string.Empty;
			string cEmailID = (!String.IsNullOrEmpty(Request.QueryString["eid"]))? Request.QueryString["eid"].ToString() : "";
			string dbErr = 
(!String.IsNullOrEmpty(Request.QueryString["dbErr"]))? Request.QueryString["dbErr"].ToString() : "";
			string funkShun = 
(!String.IsNullOrEmpty(Request.QueryString["f"]))? Request.QueryString["f"].ToString() : "";

			if (funkShun == "approveconsignor")
			{
				if (dbErr == "")
				{
					statusMsg = "Consignor [ " + cEmailID + " ] approved.";
					lblStatusMsg.CssClass = "statusMsg";
				}
				else
				{
					statusMsg = "DB error on Consignor Approval: [ " + cEmailID + " ]. Please try again.";
					lblStatusMsg.CssClass = "errMsg";
				}

				lblStatusMsg.Visible = true;
				lblStatusMsg.Text = statusMsg;
			}



			mySqlConnector mySqlConn = new mySqlConnector();

			if (mySqlConn.isInitialized())
			{
				//--	now check db for pending approvals
				if (mySqlConn.checkForPending_C_Approvals())
				{
					HyperLinkField userId = new HyperLinkField();
					userId.HeaderText = "UserId";
					userId.DataTextField = "emailaddress";
					userId.DataNavigateUrlFields = new string[] { "emailaddress", "userId" };
					userId.DataNavigateUrlFormatString = "~/admin/approveConsignor.aspx?eid={0}&uid={1}&aid=" + Session["emailAddress"].ToString();
					//userId.SortExpression = "emailaddress";
					gvConsingorApproveList.Columns.Add(userId);

					BoundField firstname = new BoundField();
					firstname.ReadOnly = true;
					firstname.HeaderText = "First";
					firstname.DataField = "firstname";
					//firstname.SortExpression = "firstname";
					gvConsingorApproveList.Columns.Add(firstname);

					BoundField lastname = new BoundField();
					lastname.ReadOnly = true;
					lastname.HeaderText = "Last";
					lastname.DataField = "lastname";
					//lastname.SortExpression = "lastname";
					gvConsingorApproveList.Columns.Add(lastname);


					BoundField address1 = new BoundField();
					address1.ReadOnly = true;
					address1.HeaderText = "Address";
					address1.DataField = "address1";
					//address1.SortExpression = "address1";
					gvConsingorApproveList.Columns.Add(address1);

					BoundField address2 = new BoundField();
					address2.ReadOnly = true;
					address2.HeaderText = "Address2";
					address2.DataField = "address2";
					//	address2.SortExpression = "address2";
					gvConsingorApproveList.Columns.Add(address2);

					BoundField city = new BoundField();
					city.ReadOnly = true;
					city.HeaderText = "City";
					city.DataField = "city";
					//city.SortExpression = "city";
					gvConsingorApproveList.Columns.Add(city);

					BoundField state = new BoundField();
					state.ReadOnly = true;
					state.HeaderText = "State";
					state.DataField = "state";
					//state.SortExpression = "state";
					gvConsingorApproveList.Columns.Add(state);

					BoundField zip = new BoundField();
					zip.ReadOnly = true;
					zip.HeaderText = "Zip";
					zip.DataField = "zip";
					//	zip.SortExpression = "zip";
					gvConsingorApproveList.Columns.Add(zip);

					BoundField phoneNumber = new BoundField();
					phoneNumber.ReadOnly = true;
					phoneNumber.HeaderText = "Phone";
					phoneNumber.DataField = "phoneNumber";
					//phoneNumber.SortExpression = "phoneNumber";
					gvConsingorApproveList.Columns.Add(phoneNumber);

					BoundField createDate = new BoundField();
					createDate.ReadOnly = true;
					createDate.HeaderText = "__date";
					createDate.DataField = "created";
					//phoneNumber.SortExpression = "phoneNumber";
					gvConsingorApproveList.Columns.Add(createDate);


					gvConsingorApproveList.DataSource = null;
					gvConsingorApproveList.Dispose();
					gvConsingorApproveList.DataSource = mySqlConn.ds;
					gvConsingorApproveList.DataBind();
					consingorApproveList.Visible = true;
				}
				else
				{
					noConsignors.Text = mySqlConn.connErrMsg;
					noConsignors.Visible = true;
				}
			}
			else
			{
				errMsg = "db connection error!";
				displayFormErrors(errMsg);
			}
			

			mySqlConn.deInitialize();

		}



        protected void displayFormErrors(string strErrMsg)
        {
            ErrorMessage.Text = "Errors:<ul><li>" + strErrMsg + "</li></ul>";
            validationBox.Visible = true;
        }


    }
}
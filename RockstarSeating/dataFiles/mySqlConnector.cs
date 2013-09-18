using RockstarSeating.Utils;

using MySql.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

using System.Data;
using System.Data.Odbc;

using System.Linq;
using System.Text;

using System.Web;
using System.Web.Configuration;
using System.Web.UI;

namespace RockstarSeating.dataFiles
{
    public class mySqlConnector
    {

        protected string sConn;
        protected MySqlConnection mySqlConn;
        protected String sWebServer = HttpContext.Current.Request.Url.ToString();
        protected Boolean connErr = false;
        public string connErrMsg = string.Empty;
        public Boolean methodFlag = false;
        public UserObj UserObj = new UserObj();

        public DataTable dt;
        public DataSet ds;


        #region constructorMethod
        public mySqlConnector()
        {

        }
        #endregion


        #region connectionRelated

        //checking the connection
        public Boolean isInitialized()
        {
            if (initialize())
            {
                return true;
            }
            return false;
        }
        public string isConnOpen()
        {
            return mySqlConn.State.ToString();
        }
        public string testConnection()
        {
            if (openConn(GetConnectionString()))
            {
                return "successful conn.Open!";
            }
            else
            {
                return connErrMsg;
            }
        }



        // opening the connection
        protected Boolean initialize()
        {
            if (openConn(GetConnectionString()))
            {
                return true;
            }
            return false;
        }
        protected string GetConnectionString()
        {
            string sConn = string.Empty;

            SaltUtility saltTool = new SaltUtility();
            StringBuilder myStr = new StringBuilder();


            // ###########	TODO: This is a good place for a static variable	#####################
            if (sWebServer.ToLower().Contains("localhost"))
            {
                //	THESE ARE MOST SECURE BECAUSE THE PLAIN TEXT PASSWORDS ARE IN MY HEAD...not hardcoded
                string password = saltTool.deSeasonIt("vhpYqqpTT7SGOE82jW26+A==");
                myStr.Append("server=localhost;");
                myStr.Append("userid=webUser;");
                myStr.Append("password=" + password + ";");
                myStr.Append("database=rockstarseating");
            }
            else
            {
                //	THESE ARE MOST SECURE BECAUSE THE PLAIN TEXT PASSWORDS ARE IN MY HEAD...not hardcoded
                string password = saltTool.deSeasonIt("yHXCcF0CU0rdI5WkR5O5gQ==");
                myStr.Append("server=rockstarseating.db.8117053.hostedresource.com;");
                myStr.Append("userid=rockstarseating;");
                myStr.Append("password=" + password + ";");
                myStr.Append("database=rockstarseating");
            }

            sConn = myStr.ToString();
            saltTool = null;
            return sConn;
        }

        protected Boolean openConn(string connStr)
        {
            mySqlConn = new MySqlConnection(connStr);
            try
            {
                mySqlConn.Open();
                return true;
            }
            catch (Exception ee)
            {
                connErrMsg = ee.Message.ToString();
                return false;
            }
        }

        // closing the connection
        public void deInitialize()
        {
            closeConn();
        }
        protected void closeConn()
        {
            mySqlConn.Close();
        }


        //
        #endregion


        #region authentication methods
        public Boolean login(string username, string userpassword, bool isCheckOnly = false)
        {
            return authenticateUser(username, userpassword, isCheckOnly);
        }
        protected Boolean authenticateUser(string loginId, string loginPass, bool checkOnly = false)
        {
            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_getUserInfo", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            MySqlParameter pLoginID;
            pLoginID = new MySqlParameter("?loginId", MySqlDbType.VarChar);
            pLoginID.Value = loginId;
            pLoginID.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pLoginID);

            MySqlParameter pGetFullDetails;
            pGetFullDetails = new MySqlParameter("?getFullDetails", MySqlDbType.Bit);
            pGetFullDetails.Value = false;
            pGetFullDetails.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pGetFullDetails);

            //try
            //{
            if (!isInitialized())
            {
                cmd.Connection.Open();
            }
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (dr.HasRows)
            {
                // exit here if checking db for registerUser
                //10-10-11  I'm not even sure what this variable was intended for, but its... [useless now??]
                if (checkOnly)
                {
                    return true;
                }

                while (dr.Read())
                {
                    UserObj.FirstName = Convert.ToString(dr["firstname"]);
                    UserObj.LastName = Convert.ToString(dr["lastname"]);
                    UserObj.Email = Convert.ToString(dr["emailAddress"]);
                    UserObj.UserPass = Convert.ToString(dr["userPass"]);
                    UserObj.LoginHash = Convert.ToString(dr["userPassP"]);
                    UserObj.LoginV = Convert.ToString(dr["userPassV"]);
                    UserObj.isConsignor = Convert.ToBoolean(dr["isConsignor"]);
                    UserObj.isAdmin = Convert.ToBoolean(dr["isAdmin"]);
                    UserObj.UserId = Convert.ToInt32(dr["userId"]);
                }

                if (UserObj.UserId > 39)
                {
                    //connErrMsg = "Logins are turned off for site maintenance. Sorry...";
                    //return false;
                }

                SaltUtility saltTool = new SaltUtility();
                if (loginPass == saltTool.deSeasonIt(UserObj.UserPass, UserObj.LoginHash, UserObj.LoginV))
                {
                    //clear password from memory
                    UserObj.UserPass = "";
                    UserObj.LoginHash = "";
                    UserObj.LoginV = "";

                    //close dataReader obj
                    dr.Close();

                    //user validated
                    return true;
                }
                else
                {
                    connErrMsg = "Email and Password combination are incorrect";
                }
            }
            else
            {
                connErrMsg = "Account not found.  Please register in order to login.";
            }
            dr.Close();
            return false;
            //}
            //catch (Exception ee)
            //{
            //    connErrMsg = ee.Message.ToString();
            //    return false;
            //}
        }
        #endregion


        #region userAccount methods
        public Boolean getUserInfo(string userId)
        {
            return fillUserObject(userId);
        }
        protected Boolean fillUserObject(string loginId)
        {
            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_getUserInfo", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            MySqlParameter pLoginID;
            pLoginID = new MySqlParameter("?loginId", MySqlDbType.VarChar);
            pLoginID.Value = loginId;
            pLoginID.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pLoginID);

            MySqlParameter pGetFullDetails;
            pGetFullDetails = new MySqlParameter("?getFullDetails", MySqlDbType.Bit);
            pGetFullDetails.Value = true;
            pGetFullDetails.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pGetFullDetails);

            //try
            //{
            if (!isInitialized())
            {
                cmd.Connection.Open();
            }
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    UserObj.FirstName = Convert.ToString(dr["firstname"]);
                    UserObj.LastName = Convert.ToString(dr["lastname"]);
                    UserObj.Email = Convert.ToString(dr["emailAddress"]);
                    UserObj.Address1 = Convert.ToString(dr["address1"]);
                    UserObj.Address2 = Convert.ToString(dr["address2"]);
                    UserObj.City = Convert.ToString(dr["city"]);
                    UserObj.State = Convert.ToString(dr["state"]);
                    UserObj.Zip = Convert.ToString(dr["zip"]);
                    UserObj.Zip2 = Convert.ToString(dr["zip2"]);
                    UserObj.Phone = Convert.ToString(dr["phoneNumber"]);
                    UserObj.mailingList = Convert.ToBoolean(dr["mailingList"]);
                }
                return true;
            }
            else
            {
                connErrMsg = "Database Error.  Please refresh and try again.";
                return false;
            }
        }
        public Boolean saveUserEditInfo(string username, Dictionary<string, string> editForm)
        {
            return saveUserInfoEdits(username, editForm);
        }
        protected Boolean saveUserInfoEdits(string loginId, Dictionary<string, string> userEditInfo)
        {
            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_saveUserEditInfo", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //set params for stored proc
            MySqlParameter pUserId;
            pUserId = new MySqlParameter("?pUserId", MySqlDbType.VarChar);
            pUserId.Value = userEditInfo["userId"];
            pUserId.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pUserId);

            MySqlParameter pFirstName;
            pFirstName = new MySqlParameter("?pFirstName", MySqlDbType.VarChar);
            pFirstName.Value = userEditInfo["First Name"];
            pFirstName.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pFirstName);

            MySqlParameter pLastName;
            pLastName = new MySqlParameter("?pLastName", MySqlDbType.VarChar);
            pLastName.Value = userEditInfo["Last Name"];
            pLastName.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pLastName);

            MySqlParameter pLoginId;
            pLoginId = new MySqlParameter("?pLoginID", MySqlDbType.VarChar);
            pLoginId.Value = userEditInfo["Email"];
            pLoginId.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pLoginId);

            MySqlParameter pPhoneNum;
            pPhoneNum = new MySqlParameter("?pPhone", MySqlDbType.VarChar);
            pPhoneNum.Value = !string.IsNullOrEmpty(userEditInfo["Phone Number"]) ? userEditInfo["Phone Number"] : null;
            pPhoneNum.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pPhoneNum);

            MySqlParameter pAddress1;
            pAddress1 = new MySqlParameter("?pAddress1", MySqlDbType.VarChar);
            pAddress1.Value = !string.IsNullOrEmpty(userEditInfo["Address1"]) ? userEditInfo["Address1"] : null;
            pAddress1.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pAddress1);

            MySqlParameter pAddress2;
            pAddress2 = new MySqlParameter("?pAddress2", MySqlDbType.VarChar);
            pAddress2.Value = !string.IsNullOrEmpty(userEditInfo["Address2"]) ? userEditInfo["Address2"] : null;
            pAddress2.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pAddress2);

            MySqlParameter pCity;
            pCity = new MySqlParameter("?pCity", MySqlDbType.VarChar);
            pCity.Value = !string.IsNullOrEmpty(userEditInfo["City"]) ? userEditInfo["City"] : null;
            pCity.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pCity);

            MySqlParameter pState;
            pState = new MySqlParameter("?pState", MySqlDbType.VarChar);
            pState.Value = !string.IsNullOrEmpty(userEditInfo["State"]) ? userEditInfo["State"] : null;
            pState.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pState);

            MySqlParameter pZip;
            pZip = new MySqlParameter("?pZip", MySqlDbType.Int32);
            if(!string.IsNullOrEmpty(userEditInfo["Zip"])){
                pZip.Value = Convert.ToInt32(userEditInfo["Zip"]);
            }
            else{
                pZip.Value = null;
            }
            pZip.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pZip);

            MySqlParameter pZip2;
            pZip2 = new MySqlParameter("?pZip2", MySqlDbType.Int16);
            if(!string.IsNullOrEmpty(userEditInfo["Zip2"])){
                pZip2.Value = Convert.ToInt16(userEditInfo["Zip2"]);
            }
            else{
                pZip2.Value = null;
            }
            pZip2.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pZip2);

            MySqlParameter pOptIn;
            pOptIn = new MySqlParameter("?pMailingList", MySqlDbType.Bit);
            if (!string.IsNullOrEmpty(userEditInfo["OptIn"]))
            {
                try
                {
                    Boolean optingIn = Convert.ToBoolean(userEditInfo["OptIn"]);
                    pOptIn.Value = optingIn ? 1 : 0;
                }
                catch
                {
                    pOptIn.Value = 0;
                }
                pOptIn.Direction = System.Data.ParameterDirection.Input;
            }
            cmd.Parameters.Add(pOptIn);           


            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ee)
            {
                connErrMsg = ee.Message.ToString();
                return false;
            }
        }
        #endregion


        #region registrationMethods
        public Boolean registerUser(Dictionary<string, string> cRegForm)
        {
            return saveUserInfo(cRegForm);
        }
        protected Boolean saveUserInfo(Dictionary<string, string> userInfo, Boolean skipSendEmail = false)
        {
            //check to make sure user is not already registered
            if (authenticateUser(userInfo["Email"].ToString(), "", true))
            {
                connErrMsg = "already registered";
                return false;
            }


            SaltUtility saltTool = new SaltUtility();
            StringBuilder myStr = new StringBuilder();

            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_registerUser", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //set params for stored proc
            MySqlParameter pFirstName;
            pFirstName = new MySqlParameter("?firstname", MySqlDbType.VarChar);
            pFirstName.Value = userInfo["First Name"];
            pFirstName.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pFirstName);

            MySqlParameter pLastName;
            pLastName = new MySqlParameter("?lastname", MySqlDbType.VarChar);
            pLastName.Value = userInfo["Last Name"];
            pLastName.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pLastName);

            MySqlParameter pEmail;
            pEmail = new MySqlParameter("?loginId", MySqlDbType.VarChar);
            pEmail.Value = userInfo["Email"];
            pEmail.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pEmail);

            MySqlParameter pPhoneNum;
            pPhoneNum = new MySqlParameter("?phoneNumber", MySqlDbType.VarChar);
            pPhoneNum.Value = !string.IsNullOrEmpty(userInfo["Phone Number"]) ? userInfo["Phone Number"] : null;
            pPhoneNum.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pPhoneNum);

            MySqlParameter pAddress1;
            pAddress1 = new MySqlParameter("?address1", MySqlDbType.VarChar);
            pAddress1.Value = !string.IsNullOrEmpty(userInfo["Address1"]) ? userInfo["Address1"] : null;
            pAddress1.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pAddress1);

            MySqlParameter pAddress2;
            pAddress2 = new MySqlParameter("?address2", MySqlDbType.VarChar);
            pAddress2.Value = !string.IsNullOrEmpty(userInfo["Address2"]) ? userInfo["Address2"] : null;
            pAddress2.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pAddress2);

            MySqlParameter pCity;
            pCity = new MySqlParameter("?city", MySqlDbType.VarChar);
            pCity.Value = !string.IsNullOrEmpty(userInfo["City"]) ? userInfo["City"] : null;
            pCity.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pCity);

            MySqlParameter pState;
            pState = new MySqlParameter("?state", MySqlDbType.VarChar);
            pState.Value = !string.IsNullOrEmpty(userInfo["State"]) ? userInfo["State"] : null;
            pState.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pState);

            MySqlParameter pZip;
            pZip = new MySqlParameter("?zip", MySqlDbType.Int32);
            if (!string.IsNullOrEmpty(userInfo["Zip"]))
            {
                pZip.Value = Convert.ToInt32(userInfo["Zip"]);
            }
            else
            {
                pZip.Value = null;
            }
            pZip.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pZip);

            MySqlParameter pZip2;
            pZip2 = new MySqlParameter("?zip2", MySqlDbType.Int16);
            if (!string.IsNullOrEmpty(userInfo["Zip2"]))
            {
                pZip2.Value = Convert.ToInt16(userInfo["Zip2"]);
            }
            else
            {
                pZip.Value = null;
            }
            pZip2.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pZip2);


            MySqlParameter pOptIn;
            pOptIn = new MySqlParameter("?mailingList", MySqlDbType.Bit);
            if (!string.IsNullOrEmpty(userInfo["OptIn"]))
            {
                try
                {
                    Boolean optingIn = Convert.ToBoolean(userInfo["OptIn"]);
                    pOptIn.Value = optingIn ? 1 : 0;
                }
                catch
                {
                    pOptIn.Value = 0;
                }
                pOptIn.Direction = System.Data.ParameterDirection.Input;
            }
            cmd.Parameters.Add(pOptIn);

            MySqlParameter pLoginPass;
            pLoginPass = new MySqlParameter("?loginPass", MySqlDbType.VarChar);
            pLoginPass.Value = saltTool.seasonIt(userInfo["Password"], userInfo["LoginHash"], userInfo["LoginV"]);
            pLoginPass.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pLoginPass);

            MySqlParameter pLoginHash;
            pLoginHash = new MySqlParameter("?loginHash", MySqlDbType.VarChar);
            pLoginHash.Value = saltTool.seasonIt(userInfo["LoginHash"]);
            pLoginHash.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pLoginHash);

            MySqlParameter pLoginV;
            pLoginV = new MySqlParameter("?loginV", MySqlDbType.VarChar);
            pLoginV.Value = saltTool.seasonIt(userInfo["LoginV"]);
            pLoginV.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pLoginV);

            MySqlParameter pAcceptedAgreement;
            pAcceptedAgreement = new MySqlParameter("?acceptedAgreement", MySqlDbType.Bit);
            pAcceptedAgreement.Value = Convert.ToBoolean(userInfo["AcceptedAgreement"]);
            pAcceptedAgreement.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pAcceptedAgreement);
            Boolean acceptedAgreement = Convert.ToBoolean(userInfo["AcceptedAgreement"]);


            //**This is the approval code for consingment application submissions.  user should get this in email when they sign up to be a ticketSeller.  Our Rep will ask for that code upon initial contact.
            MySqlParameter pConsignorCode;
            pConsignorCode = new MySqlParameter("?consignorCode", MySqlDbType.VarChar);
            pConsignorCode.Value = saltTool.seasonIt(userInfo["ConsignorCode"]);
            pConsignorCode.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pConsignorCode);

            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();

                /*
                 *  Never want to send email locally or if autoRegister occurs from joining mailing list.
                 */
                if (!skipSendEmail && sWebServer.ToLower().IndexOf("localhost") < 0 && acceptedAgreement)
                {
                    cdontsUtil emailObj = new cdontsUtil();
                    emailObj.emailDetails = userInfo;
                    emailObj.sendEmail("consignorApp_Verify", "RockstarSeating.com User Registration Success", userInfo["Email"]);
                    emailObj.sendEmail("consignorApp_Approve", "New Ticket Consignment Registration", "tickets@rockstarseating.com");
                    emailObj.sendEmail("consignorApp_Approve", "New Ticket Consignment Registration", "leroyv@glvconsulting.com");
                }
                return true;
            }
            catch (Exception ee)
            {
                connErrMsg = ee.Message.ToString();
                return false;
            }
        }
        #endregion

                
        #region inventoryUploading methods
        public Boolean uploadInventory(Dictionary<string, string> cInvUpload)
        {
            return saveInventoryToDB(cInvUpload);
        }
        protected Boolean saveInventoryToDB(Dictionary<string, string> uploadInfo)
        {

            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_uploadInventory", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //set params for stored proc
            MySqlParameter pEventTitle;
            pEventTitle = new MySqlParameter("?eventTitle", MySqlDbType.VarChar);
            pEventTitle.Value = uploadInfo["Event Title"];
            pEventTitle.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pEventTitle);

            MySqlParameter pVenue;
            pVenue = new MySqlParameter("?venue", MySqlDbType.VarChar);
            pVenue.Value = uploadInfo["Venue"];
            pVenue.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pVenue);

            MySqlParameter pRow;
            pRow = new MySqlParameter("?seatRow", MySqlDbType.VarChar);
            pRow.Value = uploadInfo["Row"];
            pRow.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pRow);

            MySqlParameter pSeatFrom;
            pSeatFrom = new MySqlParameter("?seatFrom", MySqlDbType.VarChar);
            pSeatFrom.Value = !string.IsNullOrEmpty(uploadInfo["Seat From"]) ? uploadInfo["Seat From"] : null;
            pSeatFrom.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pSeatFrom);

            MySqlParameter pSeatThru;
            pSeatThru = new MySqlParameter("?seatThru", MySqlDbType.VarChar);
            pSeatThru.Value = !string.IsNullOrEmpty(uploadInfo["Seat Thru"]) ? uploadInfo["Seat Thru"] : null;
            pSeatThru.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pSeatThru);

            MySqlParameter pSection;
            pSection = new MySqlParameter("?section", MySqlDbType.VarChar);
            pSection.Value = uploadInfo["Section"];
            pSection.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pSection);

            MySqlParameter pQuantity;
            pQuantity = new MySqlParameter("?Quantity", MySqlDbType.VarChar);
            pQuantity.Value = !string.IsNullOrEmpty(uploadInfo["Quantity"]) ? uploadInfo["Quantity"] : "1";
            pQuantity.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pQuantity);

            MySqlParameter pCost;
            pCost = new MySqlParameter("?cost", MySqlDbType.Int16);
            string strCost = uploadInfo["Cost"];
            int ix = strCost.IndexOf('.');
            strCost = ix > 0 ? strCost.Substring(ix) : strCost;
            pCost.Value = Convert.ToInt16(strCost);
            pCost.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pCost);


            MySqlParameter pEventDate;
            pEventDate = new MySqlParameter("?eventDate", MySqlDbType.VarChar);
            pEventDate.Value = uploadInfo["Event Date"];
            pEventDate.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pEventDate);


            MySqlParameter pEventTime;
            pEventTime = new MySqlParameter("?eventTime", MySqlDbType.VarChar);
            pEventTime.Value = uploadInfo["Event Time"];
            pEventTime.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pEventTime);


            MySqlParameter pUserId;
            pUserId = new MySqlParameter("?userId", MySqlDbType.VarChar);
            pUserId.Value = uploadInfo["UserId"];
            pUserId.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pUserId);

            MySqlParameter pNotes;
            pNotes = new MySqlParameter("?notes", MySqlDbType.LongText);
            pNotes.Value = uploadInfo["Notes"];
            pNotes.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pNotes);

            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();                

                //create the sendMail object here
                cdontsUtil mailObj = new cdontsUtil();
                string emailTo = uploadInfo["EmailAddress"];
                string emailSubj = "Rockstar Seating Ticket Consignment: Please verify your Ticket Seller Account Upload Information";
                mailObj.emailDetails = uploadInfo;
                
                mailObj.sendEmail("consignmentUpload_success", emailSubj, emailTo);
                mailObj.sendEmail("consignmentUpload_success", emailSubj, "tickets@rockstarseating.com");
                mailObj.sendEmail("consignmentUpload_success", emailSubj, "leroyv@glvconsulting.com");

                return true;
            }
            catch (Exception ee)
            {
                connErrMsg = ee.Message.ToString();
                return false;
            }
        }
        #endregion


        #region Inventory Exporting/Viewing Methods
        public string getLastInventoryExport()
        {
            return getLastExportedTime();
        }
        protected string getLastExportedTime()
        {
            string lastExport = String.Empty;

            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_getLastExportTime", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lastExport = Convert.ToString(dr["LastExportTime"]);
                    }
                }
            }
            catch (Exception e)
            {
                lastExport = e.Message.ToString();
            }
            return lastExport;
        }


        //export Methods
        public List<List<string>> exportLatestUploads(){
            return getLatestUploads();
        }
        protected List<List<string>> getLatestUploads(){
            List<string> itemRow;

            List<List<string>> exportList = new List<List<string>>();

            MySqlCommand cmd = new MySqlCommand("usp_exportInventoryUploads", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }

                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                
                int cnt = 0;
                while (dr.Read())
                {
                    itemRow = new List<string>();
                    itemRow.Add(dr["EventTitle"].ToString());
                    itemRow.Add(dr["Venue"].ToString());
                    itemRow.Add(dr["EventDate"].ToString());
                    itemRow.Add(dr["EventTime"].ToString());
                    itemRow.Add(dr["Quantity"].ToString());
                    itemRow.Add(dr["Section"].ToString());
                    itemRow.Add(dr["SeatRow"].ToString());
                    itemRow.Add(dr["SeatFrom"].ToString());
                    itemRow.Add(dr["SeatThru"].ToString());
                    itemRow.Add(dr["ConsignorNotes"].ToString());
                    itemRow.Add(dr["Cost"].ToString());
                    exportList.Add(itemRow);
                    cnt++;
                }
            }
            catch (Exception e)
            {
                itemRow = new List<string>();
                itemRow.Add("Error: " + e.Message.ToString());
                exportList.Add(itemRow);
            }
            
            
            return exportList;
        }

        //view meghods
        public Boolean getExportList(int consignorID = 0, Boolean byUser = false)
        {
            return viewExportList(consignorID, byUser);
        }
        protected Boolean viewExportList(int userID = 0, Boolean consignorSpecific = false)
        {
            MySqlCommand cmd;

            if (consignorSpecific)
            {
                cmd = new MySqlCommand("usp_getUserInventoryUploads", mySqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                MySqlParameter consignorID;
                consignorID = new MySqlParameter("?consignorID", MySqlDbType.Int16);
                consignorID.Value = userID;
                consignorID.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(consignorID);
            }
            else
            {
                cmd = new MySqlCommand("usp_getInventoryForExport", mySqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
            }

            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }

                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                
                if (dr.HasRows)
                {

                    DataTable dtSchema = dr.GetSchemaTable();
                    dt = new DataTable();
                    // You can also use an ArrayList instead of List<>
                    List<DataColumn> listCols = new List<DataColumn>();

                    if (dtSchema != null)
                    {
                        foreach (DataRow drow in dtSchema.Rows)
                        {
                            string columnName = System.Convert.ToString(drow["ColumnName"]);
                            DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                            column.Unique = (bool)drow["IsUnique"];
                            column.AllowDBNull = (bool)drow["AllowDBNull"];
                            column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                            listCols.Add(column);
                            dt.Columns.Add(column);
                        }
                    }



                    // Read rows from DataReader and populate the DataTable
                    while (dr.Read())
                    {
                        DataRow dataRow = dt.NewRow();
                        for (int i = 0; i < listCols.Count; i++)
                        {
                            dataRow[((DataColumn)listCols[i])] = dr[i];
                        }
                        dt.Rows.Add(dataRow);
                    }

                    //add dataTable to DataSet
                    ds = new DataSet("exportList");
                    ds.Tables.Add(dt);
                    return true;
                }
                else
                {
                    connErrMsg = "No pending exports.";
                    return false;
                }

            }
            catch (Exception e)
            {
                this.connErrMsg = e.Message.ToString();
                return false;
            }

        }
        #endregion



        #region Mailing List Code
        public Boolean joinMailingList(string emailAddy)
        {
            return addEmailToMailingList(emailAddy);
        }

        protected Boolean isEmailAlreadyRegistered(string theEmailAddy)
        {
            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_isEmailRegistered", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            MySqlParameter pEmail;
            pEmail = new MySqlParameter("?in_emailAddress", MySqlDbType.VarChar);
            pEmail.Value = theEmailAddy;
            pEmail.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pEmail);

            if (!isInitialized())
            {
                cmd.Connection.Open();
            }
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected Boolean addEmailToMailingList(string emailAddress)
        {
            //check to make sure user is not already registered

            if (isEmailAlreadyRegistered(emailAddress))
            {
                connErrMsg = "Email Address is already registered.";
                return false;
            }


            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_joinMailingList", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //set params for stored proc
            MySqlParameter pEmail;
            pEmail = new MySqlParameter("?in_emailAddress", MySqlDbType.VarChar);
            pEmail.Value = emailAddress;
            pEmail.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pEmail);

            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();

                cdontsUtil emailObj = new cdontsUtil();
                emailObj.sendEmail("joinMailingList_success", "Thanks for joining our Mailing List", emailAddress);
                return true;
            }
            catch (Exception ee)
            {
                connErrMsg = ee.Message.ToString();
                return false;
            }

        }



        #endregion
        
        
        #region Admin Tasks Methods

        public Boolean checkForPending_C_Approvals(){
            return viewPendingConsignmentApprovals();
        }
        protected Boolean viewPendingConsignmentApprovals()
        {

            MySqlCommand cmd = new MySqlCommand("usp_getPendingConsignorApprovals", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }

                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                DataTable dtSchema = dr.GetSchemaTable();
                dt = new DataTable();
                // You can also use an ArrayList instead of List<>
                List<DataColumn> listCols = new List<DataColumn>();

                if (dtSchema != null)
                {
                    foreach (DataRow drow in dtSchema.Rows)
                    {
                        string columnName = System.Convert.ToString(drow["ColumnName"]);
                        DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                        column.Unique = (bool)drow["IsUnique"];
                        column.AllowDBNull = (bool)drow["AllowDBNull"];
                        column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                        listCols.Add(column);
                        dt.Columns.Add(column);
                    }
                }

                if (dr.HasRows)
                {
                    // Read rows from DataReader and populate the DataTable
                    while (dr.Read())
                    {
                        DataRow dataRow = dt.NewRow();
                        for (int i = 0; i < listCols.Count; i++)
                        {
                            dataRow[((DataColumn)listCols[i])] = dr[i];
                        }
                        dt.Rows.Add(dataRow);
                    }

                    //add dataTable to DataSet
                    ds = new DataSet("pendingConsignmentApprovals");
                    ds.Tables.Add(dt);

                    return true;
                }
                else
                {
                    this.connErrMsg = "No pending Consignment Approvals.";
                    return false;
                }

            }
            catch (Exception e)
            {
                this.connErrMsg = e.Message.ToString();
                return false;
            }

        }

        public Boolean callApproveConsignor(string cEmail, string cID, string aID)
        {
            return approveConsignor(cEmail, cID, aID);
        }
        protected Boolean approveConsignor(string consignorEmail, string consignorID, string adminID)
        {

            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_approveConsignor", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            MySqlParameter pConsigonorEmail;
            pConsigonorEmail = new MySqlParameter("?consignorEmail", MySqlDbType.VarChar);
            pConsigonorEmail.Value = consignorEmail;
            pConsigonorEmail.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pConsigonorEmail);

            MySqlParameter pConsigonorID;
            pConsigonorID = new MySqlParameter("?consignorID", MySqlDbType.VarChar);
            pConsigonorID.Value = consignorID;
            pConsigonorID.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pConsigonorID);

            MySqlParameter pAdminID;
            pAdminID = new MySqlParameter("?adminID", MySqlDbType.VarChar);
            pAdminID.Value = adminID;
            pAdminID.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pAdminID);

            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return true;
            }
            catch (Exception e)
            {
                connErrMsg = e.Message.ToString();
                return false;
            }
        }
        
        
        
        #endregion


        #region TESTIMONIALS


        public Boolean getTestimonial(int rowID, Boolean selectAll)
        {			
            return call_getTestimonial(rowID, selectAll);
        }
        protected Boolean call_getTestimonial(int custID, Boolean getAll = false){
            
            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_getTestimonial", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //set params for stored proc
            MySqlParameter pCustID;
            pCustID = new MySqlParameter("?customerID", MySqlDbType.Int16);
            pCustID.Value = custID;
            pCustID.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pCustID);

            MySqlParameter pSelectAll;
            pSelectAll = new MySqlParameter("?selectAll", MySqlDbType.Bit);
            pSelectAll.Value = getAll;
            pSelectAll.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pSelectAll);

            List<Dictionary<string, string>> testimonialsList = new List<Dictionary<string, string>>();
            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }

                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {

                    DataTable dtSchema = dr.GetSchemaTable();
                    dt = new DataTable();
                    // You can also use an ArrayList instead of List<>
                    List<DataColumn> listCols = new List<DataColumn>();

                    if (dtSchema != null)
                    {
                        foreach (DataRow drow in dtSchema.Rows)
                        {
                            string columnName = System.Convert.ToString(drow["ColumnName"]);
                            DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                            column.Unique = (bool)drow["IsUnique"];
                            column.AllowDBNull = (bool)drow["AllowDBNull"];
                            column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                            listCols.Add(column);
                            dt.Columns.Add(column);
                        }
                    }


                    // Read rows from DataReader and populate the DataTable
                    while (dr.Read())
                    {
                        DataRow dataRow = dt.NewRow();
                        for (int i = 0; i < listCols.Count; i++)
                        {
                            dataRow[((DataColumn)listCols[i])] = dr[i];
                        }
                        dt.Rows.Add(dataRow);
                    }

                    //add dataTable to DataSet
                    ds = new DataSet("testimonials");
                    ds.Tables.Add(dt);
                    this.deInitialize();
                    return true;
                }
                else
                {
                    connErrMsg = "No testimonials in database.";
                }
            }
            catch (Exception ee)
            {
                connErrMsg = ee.Message.ToString();
                this.deInitialize();
            }

            return false;
        }

        public Boolean saveTestimonial(int rowID, Dictionary<string, string> formData)
        {			
            return call_saveTestimonial(rowID, formData);
        }
        protected Boolean call_saveTestimonial(int custID, Dictionary<string, string> tData){
            
            //create a mySql command object
            MySqlCommand cmd = new MySqlCommand("usp_saveTestimonial", mySqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //set params for stored proc
            MySqlParameter pCustID;
            pCustID = new MySqlParameter("?customerID", MySqlDbType.Int16);
            pCustID.Value = custID;
            pCustID.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pCustID);

            MySqlParameter pCustName;
            pCustName = new MySqlParameter("?customerName", MySqlDbType.VarChar);
            pCustName.Value = tData["CustomerName"];
            pCustName.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pCustName);

            MySqlParameter pCustEvent;
            pCustEvent = new MySqlParameter("?customerEvent", MySqlDbType.VarChar);
            pCustEvent.Value = tData["CustomerEvent"];
            pCustEvent.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pCustEvent);

            MySqlParameter pCustLocation;
            pCustLocation = new MySqlParameter("?customerLocation", MySqlDbType.VarChar);
            pCustLocation.Value = tData["CustomerLocation"];
            pCustLocation.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pCustLocation);

            MySqlParameter pCustBlurb;
            pCustBlurb = new MySqlParameter("?customerBlurb", MySqlDbType.LongText);
            pCustBlurb.Value = tData["CustomerBlurb"];
            pCustBlurb.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pCustBlurb);

            MySqlParameter pInsertQuery;
            pInsertQuery = new MySqlParameter("?insertQuery", MySqlDbType.Bit);
            pInsertQuery.Value = Convert.ToBoolean(tData["InsertQuery"]);
            pInsertQuery.Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(pInsertQuery);

            try
            {
                if (!isInitialized())
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ee)
            {
                connErrMsg = ee.Message.ToString();
            }

            return false;
        }


        #endregion

        

        #region Customer Ticket Requests

        public Boolean sendTicketRequest(Dictionary<string, string> formInfo)
        {
            return sendTicketRequestForm(formInfo);
        }
        protected Boolean sendTicketRequestForm(Dictionary<string, string> formDetails)
        {
            try
            {
                //need to provide an autogenerated password and store it encrypted in the db
                SaltUtility saltTool = new SaltUtility();

                string loginHash = saltTool.randomString(16);
                string loginV = saltTool.randomString(16);

                //food param = plainText password(randomString(16))
                string autoGeneratedPassword = saltTool.randomString(16);
                autoGeneratedPassword = saltTool.seasonIt(autoGeneratedPassword, loginHash, loginV);

                //password stored = seasoned_autoGeneratedPassword
                formDetails.Add("Password", autoGeneratedPassword);
                formDetails.Add("LoginHash", loginHash);
                formDetails.Add("LoginV", loginV);

                //now add misc fields for saveUserInfo
                formDetails.Add("OptIn", "true");
                formDetails.Add("Zip2", "");
                formDetails.Add("ConsignorCode", "");

                Boolean alreadyRegistered = false;

                //this should save user info unless fail
                if (!saveUserInfo(formDetails, true))
                {
                    //need to passThru if user is already registered, it's a fake fail
                    if (connErrMsg == "already registered")
                    {
                        alreadyRegistered = true;
                    }
                    else
                    {
                        return false;
                    }
                }

                //now send emails
                cdontsUtil emailObj = new cdontsUtil();
                emailObj.emailDetails = formDetails;

                //send email to user
                emailObj.sendEmail("userTicketRequest_success", "Ticket Request Submission at RockstarSeating.com", formDetails["Email"]);
                //send email to admin
                if (!alreadyRegistered)
                {
                    emailObj.sendEmail("userTicketRequest_notify", "New Member Ticket Request Submission", formDetails["Email"]);
                }
                else
                {
                    emailObj.sendEmail("userTicketRequest_alreadyRegistered_notify", "Registered Member Ticket Request Submission", formDetails["Email"]);

                }
                return true;
            }
            catch (Exception ee)
            {
                connErrMsg = ee.Message.ToString();
                return false;
            }
        }

        #endregion






    }
}
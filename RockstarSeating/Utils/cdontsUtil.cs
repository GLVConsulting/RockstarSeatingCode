using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Web;


namespace RockstarSeating.Utils
{
    public class cdontsUtil
    {
		public Dictionary<string, string> emailDetails;



        public void sendEmail(string strBody, string strSubject, string strTo, string strFrom = "tickets@rockstarseating.com")
        {
            const string SERVER = "relay-hosting.secureserver.net";
            MailMessage oMail = new System.Net.Mail.MailMessage();
            MailAddress from = new MailAddress(strFrom);
            MailAddress to = new MailAddress(strTo);
            MailMessage message = new MailMessage(from, to);
			message.IsBodyHtml = true;
            message.Subject = strSubject;
            message.Body = getEmailBody(strBody) + getEmailFooter();
            SmtpClient client = new SmtpClient(SERVER);
			client.Credentials = new System.Net.NetworkCredential("tickets@rockstarseating.com", "r0ckst4r");
            client.Send(message);            
        }




        public string getEmailBody(string emailFor)
        {
            string emailBody = string.Empty;

            switch (emailFor)
            {
                case "consignorApp_Verify":
                    emailBody = consignorApplicationReview();
                    break;

                case "consignorApp_Approve":
                    emailBody = consignorApplicationApprove();
                    break;

                case "consignmentUpload_success":
                    emailBody = consignmentUpload();
                    break;

				case "joinMailingList_success":
					emailBody = newsletterJoin();
					break;

				case "userTicketRequest_notify":
					emailBody = userTicketRequestToAdmin(false);
					break;

				case "userTicketRequest_success":
					emailBody = userTicketRequestToUser();
					break;

				case "userTicketRequest_alreadyRegistered_notify":
					emailBody = userTicketRequestToAdmin(true);
					break;

                default:
                    break;
            }

            return emailBody;
        }


		protected string userTicketRequestToAdmin(Boolean alreadyRegistered)
		{
			StringBuilder sb = new StringBuilder();

			string userName = (emailDetails["First Name"] != "")? emailDetails["First Name"] : emailDetails["Email"];
			userName = (emailDetails["Last Name"] != "")? userName + " " + emailDetails["Last Name"] : userName;
			

			if(!alreadyRegistered){
				sb.Append("<p>A new account was created on our site for " + userName + " via our Ticket Request form.</p>");
			}
			else{
				sb.Append("<p>Member: <b>" + userName + "</b> requested some Tickets using our site.</p>");
			}

			sb.Append("<p>Here are the details of the Ticket Request.");
			sb.Append("<p>&nbsp;</p>");
			sb.Append("<p>Event: " + emailDetails["Event"] + "</p>");
			sb.Append("<p>Venue: " + emailDetails["Venue"] + "</p>");
			sb.Append("<p>Date: " + emailDetails["Date"] + "</p>");
			sb.Append("<p>Seating: " + emailDetails["Seats"] + "</p>");
			sb.Append("<p>Price Range: " + emailDetails["Price Range"] + "</p>");
			sb.Append("<p>Description: " + emailDetails["Description"] + "</p>");

			//user details
			sb.Append("<p>&nbsp;</p>");
			sb.Append("<p>Here are the details of the person requesting the Tickets.");
			sb.Append("<p>First Name: " + emailDetails["First Name"] + "</p>");
			sb.Append("<p>Last Name: " + emailDetails["Last Name"] + "</p>");
			sb.Append("<p>Best Time to Call: " + emailDetails["Best Time To Call"] + "</p>");
			sb.Append("<p>Phone: " + emailDetails["Phone Number"] + "</p>");
			sb.Append("<p>Email: " + emailDetails["Email"] + "</p>");
			sb.Append("<p>Street: " + emailDetails["Address1"] + "</p>");
			sb.Append("<p>Street 2: " + emailDetails["Address2"] + "</p>");
			sb.Append("<p>City: " + emailDetails["City"] + "</p>");
			sb.Append("<p>State: " + emailDetails["State"] + "</p>");
			sb.Append("<p>Zip: " + emailDetails["Zip"] + "</p>");

			return sb.ToString();
		}
		protected string userTicketRequestToUser()
		{
			StringBuilder sb = new StringBuilder();

			string dVenue = emailDetails["Venue"];
			dVenue = (dVenue != "")? ", at " + dVenue + ". ": "";


            sb.Append("<p>You are receiving this email because you recently submitted a Ticket Request for " + emailDetails["Event"] + dVenue + "Your Ticket Request will be processed in the next 24 hours and you will be contacted by a Rockstar Seating Representative.");
			sb.Append(" At that time, you will be asked whether or not you would like to reserve the tickets you requested to " + emailDetails["Event"] + ". ");
			sb.Append(" If you choose to take that option, then a 20% deposit fee will be required, so please have a valid Credit Card ready if you are interested in reserving these tickets.</p>");
			sb.Append("<p>Here are the details of your Ticket Request.  Please review them and note any required changes.");
			sb.Append("<p>&nbsp;</p>");
			sb.Append("<p>Event: " + emailDetails["Event"] + "</p>");
			sb.Append("<p>Venue: " + emailDetails["Venue"] + "</p>");
			sb.Append("<p>Date: " + emailDetails["Date"] + "</p>");
			sb.Append("<p>Seating: " + emailDetails["Seats"] + "</p>");
			sb.Append("<p>Price Range: " + emailDetails["Price Range"] + "</p>");
			sb.Append("<p>Description: " + emailDetails["Description"] + "</p>");

			//user details
			sb.Append("<p>&nbsp;</p>");
			sb.Append("<p>Here are the details of your Personal Information.  Please review them and note any required changes.");
			sb.Append("<p>First Name: " + emailDetails["First Name"] + "</p>");
			sb.Append("<p>Last Name: " + emailDetails["Last Name"] + "</p>");
			sb.Append("<p>Best Time to Call: " + emailDetails["Best Time To Call"] + "</p>");
			sb.Append("<p>Phone: " + emailDetails["Phone Number"] + "</p>");
			sb.Append("<p>Email: " + emailDetails["Email"] + "</p>");
			sb.Append("<p>Street: " + emailDetails["Address1"] + "</p>");
			sb.Append("<p>Street 2: " + emailDetails["Address2"] + "</p>");
			sb.Append("<p>City: " + emailDetails["City"] + "</p>");
			sb.Append("<p>State: " + emailDetails["State"] + "</p>");
			sb.Append("<p>Zip: " + emailDetails["Zip"] + "</p>");

			sb.Append("<p>&nbsp;</p>");
			sb.Append("<p>An account at RockstarSeating.com was created for you as a convenient way of storing your user information for future requests and also to 'put you in the loop' of Upcoming Events and/or Sales and Promotions.  If you would like to opt-out of our newsletter, you will be given that option on every Rockstar Seating Newsletter that you receive.</p>");

			sb.Append("<p>&nbsp;</p>");
			sb.Append("<p>Thanks for you RockstarSeating.com!</p>");

			return sb.ToString();
		}




		#region EMAIL TEMPLATES

		protected string consignorApplicationApprove()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<p>A new User has registered online for a Ticket Seller Account on Rockstar Seating using these details below:</p>");
			
			string strDetail = String.Empty;
			string strValue = String.Empty;

			sb.Append("<div style=\"border-top:3px double #ccc;padding:10px;\">");
			foreach(KeyValuePair<string, string> emailDetail in emailDetails){
				strDetail = emailDetail.Key.ToLower();
				strValue = emailDetail.Value;

				if (strDetail != "password" && strDetail != "confirm password" && strDetail != "loginhash" && strDetail != "loginv" && strDetail != "optin")
				{
					if (strValue != "")
					{
						sb.Append("<p><b>" + emailDetail.Key + "</b>:&nbsp;&nbsp;" + emailDetail.Value + "</p>");
					}
				}
			}
			sb.Append("</div>");


            return sb.ToString();
        }
        protected string consignorApplicationReview()
        {
            StringBuilder sb = new StringBuilder();

			sb.Append("<p>You are receiving this email because someone created a Ticket Seller Account on Rockstar Seating using this email address. To activate your account so you can begin to sell tickets we must first verify the contact information supplied when the account was created. *You will also need to provide a Valid Credit Card Number for us to keep on file here at Rockstar Seating.</p>");
			sb.Append("Here are the details you provided.  Please verify them and be ready with any changes to mention upon initial contact with our Account Representative.</p>");

			string strDetail = String.Empty;
			string strValue = String.Empty;

			sb.Append("<div style=\"border-top:3px double #ccc;padding:10px;\">");
			foreach(KeyValuePair<string, string> emailDetail in emailDetails){
				strDetail = emailDetail.Key.ToLower();
				strValue = emailDetail.Value;
				if (strDetail != "password" && strDetail != "confirm password" && strDetail != "loginhash" && strDetail != "loginv" && strDetail != "optin")
				{
					if (strValue != "")
					{
						sb.Append("<p><b>" + emailDetail.Key + "</b>:&nbsp;&nbsp;" + emailDetail.Value + "</p>");
					}
				}
			}
			sb.Append("</div>");

            sb.Append("<p>If you received this email in error, let us know and we will remove you from our database.</p>");
            sb.Append("<p>Thanks again for using RockstarSeating.com! We will be contacting you shortly.</p>");

            return sb.ToString();
		}
        protected string consignmentUpload()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<p>You are receiving this email because you recently uploaded some Event Tickets via your Seller Account on Rockstar Seating using this email address.  Here are the details of your Ticket Inventory Upload:</p>");

			string strDetail = String.Empty;
			sb.Append("<div style=\"border-top:3px double #ccc;padding:10px;\">");
			foreach(KeyValuePair<string, string> emailDetail in emailDetails){
				strDetail = emailDetail.Key.ToLower();

				if (strDetail != "userid")
				{
					sb.Append("<p><b>" + emailDetail.Key + "</b>:&nbsp;&nbsp;" + emailDetail.Value + "</p>");
				}
			}
			sb.Append("</div>");

            sb.Append("<p>If you received this email in error, let us know and we will remove you from our database.</p>");
            sb.Append("<p>Thanks again for using RockstarSeating.com!</p>");

            return sb.ToString();
        }
		protected string newsletterJoin()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<p>You are receiving this email because this email address was recently registered for a newsletter from RockstarSeating.com.  At Rockstar Seating, we bring you the best possible seats for the HOTTEST events in the Greater Seattle area...or wherever you might want to party like a Rockstar.</p>");

			sb.Append("As a member of our mailing list, you'll be get emails with Event Hot Lists, promotional sales info, and updates on Upcoming Events.  Whether, you're on the East Coast, the West Coast, or somewhere in between we've got the scoop on it.</p>");			

            sb.Append("<p>If you received this email in error, let us know and we will remove you from our database.</p>");
            sb.Append("<p>Thanks for using RockstarSeating.com!</p>");

            return sb.ToString();
        }

		protected string getEmailFooter()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<div style=\"margin-top:247px;\">");
			sb.Append("<div><b>Rockstar Seating</b></div>");
			sb.Append("<div>9746 Rainier Ave S</div>");
			sb.Append("<div>Seattle, WA 98118</div>");
			sb.Append("<div><b>Phone: </b>(206) 268-0450</div>");
			sb.Append("<div><b>Fax: </b>(206) 577-5399</div>");
			sb.Append("<div><b>Email: </b>tickets@rockstarseating.com</div>");
			sb.Append("</div>");
			return sb.ToString();
		}


		#endregion

	}
}

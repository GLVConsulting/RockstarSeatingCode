using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RockstarSeating.dataFiles;

namespace RockstarSeating.Admin
{
	public partial class Testimonials : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			//TODO: add https check.  Only admins should see the admin panel here
			//TODO: add admin panel for this page.

			String action = Request.QueryString["action"];

			if (IsPostBack)
			{
				saveTestimonial();
			}
			else
			{
				if (!String.IsNullOrEmpty(action))
				{
					if (action.ToLower() == "view")
					{
						adminGetAllTestimonials();
					}
				}
			}
		}

		protected void saveTestimonial()
		{
			TestimonialsObj tObj = new TestimonialsObj();
			tObj.Single_Testimonial.Add("CustomerName", this.CustomerName.Text);
			tObj.Single_Testimonial.Add("CustomerLocation", this.CustomerLocation.Text);
			tObj.Single_Testimonial.Add("CustomerBlurb", this.CustomerBlurb.Text);
			tObj.Single_Testimonial.Add("CustomerEvent", this.CustomerEvent.Text);
			tObj.Single_Testimonial.Add("InsertQuery", "true");


			if (tObj.saveFormData(0))
			{
				this.statusMsg.Visible = true;
				this.statusMsg.Text = "Testimonial was successfully saved.";
				tObj = null;
				Response.Redirect("Testimonials.aspx?action=view");

				//TODO: ENHANCE SUCESS MESSAGING
			}
			else
			{
				this.errMsg.Visible = true;
				this.errMsg.Text = tObj.errMsg;
			}		
		}




		protected void adminGetAllTestimonials()
		{
			TestimonialsObj tObj = new TestimonialsObj();

			try
			{
				if (tObj.getTestimonials(0, true))
				{
					//bind data
						BoundField custName = new BoundField();
						custName.ReadOnly = true;
						custName.HeaderText = "Customer Name";
						custName.DataField = "cust_Name";
						this.gvTestimonials.Columns.Add(custName);

						BoundField custLoc = new BoundField();
						custLoc.ReadOnly = true;
						custLoc.HeaderText = "Customer Location";
						custLoc.DataField = "cust_Location";
						this.gvTestimonials.Columns.Add(custLoc);

						BoundField custBlurb = new BoundField();
						custBlurb.ReadOnly = true;
						custBlurb.HeaderText = "Customer Testimonial";
						custBlurb.DataField = "testimonial";
						this.gvTestimonials.Columns.Add(custBlurb);

						BoundField custEvent = new BoundField();
						custEvent.ReadOnly = true;
						custEvent.HeaderText = "Event";
						custEvent.DataField = "cust_Event";
						this.gvTestimonials.Columns.Add(custEvent);

						this.gvTestimonials.DataSource = null;
						this.gvTestimonials.Dispose();
						this.gvTestimonials.DataSource = tObj.ds;
						this.gvTestimonials.DataBind();
			
						this.formPanel.Visible = false;
						this.viewPanel.Visible = true;
					}
				else
				{
					this.errMsg.Text = tObj.errMsg;
					this.errMsg.Visible = true;
				}
			}
			catch (Exception ee)
			{
				this.errMsg.Visible = true;
				this.errMsg.Text = ee.Message.ToString();
			}
			tObj = null;
		}

	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace RockstarSeating.dataFiles
{
    public class TestimonialsObj
    {

        public List<Dictionary<string, string>> Testimonial_Data;
        public Dictionary<string, string> Single_Testimonial = new Dictionary<string, string>();
        public mySqlConnector mySqlObj = new mySqlConnector();
        public String errMsg = String.Empty;

        public DataTable dt;
        public DataSet ds;


        //need to determine what type of action we are doing
        public TestimonialsObj()
        {
        }


        public Boolean saveFormData(int tID)
        {				
            return saveTestimonial(tID);			
        }
        protected Boolean saveTestimonial(int custID)
        {
            try
            {
                if (mySqlObj.isInitialized())
                {
                    if (mySqlObj.saveTestimonial(custID, Single_Testimonial))
                    {
                        mySqlObj.deInitialize();
                        mySqlObj = null;
                        return true;
                    }
                    else
                    {
                        this.errMsg = mySqlObj.connErrMsg;
                    }
                }
            }
            catch (Exception e)
            {
                this.errMsg = e.Message.ToString();
            }


            try
            {
                mySqlObj.deInitialize();
                mySqlObj = null;
            }
            catch(Exception e){
                //do nothing. 
            }
            return false;
        }



        public Boolean getTestimonials(int rowID, Boolean selectAll)
        {
            return getTestimonial(rowID, selectAll);
        }
        protected Boolean getTestimonial(int custID, Boolean getAll)
        {
            if (mySqlObj.isInitialized())
            {
                if(mySqlObj.getTestimonial(custID, getAll)){
                    //pass data from sqlQuery
                    this.ds = mySqlObj.ds;
                    
                    mySqlObj.deInitialize();
                    mySqlObj = null;
                    return true;
                }
            }
            return false;
        }
    }

}
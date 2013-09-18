using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RockstarSeating.dataFiles;

namespace RockstarSeating.baseClasses
{
    public class BaseMasterPage : System.Web.UI.MasterPage
    {
            
		//used for GLOBAL getter/setters 
		//can also use Session variables for the same stuff
		//use with caution in here
		//they should be static properties/variables.

		static string _strTest;


		public static string strTest{			
            get
            {
				DateTime dt = DateTime.Now;
                return _strTest + "_" + dt;
            }
            set
            {
                _strTest = value;
            }
		}










    }
}
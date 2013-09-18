using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockstarSeating.Utils.TNWebSvcs
{
	public class GetHighSalesPerformers
	{
		string _numReturned;
		string _parentCategoryID;
		string _childCategoryID;
		string _grandchildCategoryID;




        public string numReturned
        {
            get
            {
                return _numReturned;
            }
            set
            {
                _numReturned = value;
            }
        }


        public string parentCategoryID
        {
            get
            {
                return _parentCategoryID;
            }
            set
            {
               _parentCategoryID = value;
            }
        }

        public string childCategoryID
        {
            get
            {
                return _childCategoryID;
            }
            set
            {
               _childCategoryID = value;
            }
        }
        public string grandchildCategoryID
        {
            get
            {
                return _grandchildCategoryID;
            }
            set
            {
               _grandchildCategoryID = value;
            }
        }




	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

using RockstarSeating.TNWebSvc_StringInputs;

namespace RockstarSeating.Utils.TNWebSvcs
{
	public class GetWebService
	{
		protected const string websiteConfigID = "11500";
		public ArrayList returnArrayList;

		protected Dictionary<string, string> webSvcInputs;


        #region constructorMethod
        public GetWebService()
        {

        }
        #endregion



		public Boolean callTNWebService(string serviceName, Dictionary<string, string> serviceInputs){
			this.webSvcInputs = serviceInputs;

			switch (serviceName)
			{
				case "getEvent":
					Event[] eventList = this.getEvent();

					if(eventList.Length > 0)
					{
						returnArrayList = ArrayList.Adapter(eventList);
						return true;
					}
					break;

				
				case "getHighSalesPerformers":
					//this.getHighSalesPerformers();
					break;


				default:
					break;


			}
			return false;
		}





		protected Event[] getEvent()
		{
			GetEventObj eventObj = new GetEventObj();
			Event[] eventData = eventObj.getData(websiteConfigID, this.webSvcInputs);
			return eventData;
		}



		protected Boolean getHighSalesPerformers()
		{

			return false;
		}



	}
}
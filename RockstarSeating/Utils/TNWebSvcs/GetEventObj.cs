using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RockstarSeating.TNWebSvc_StringInputs;
namespace RockstarSeating.Utils.TNWebSvcs
{
	public class GetEventObj
	{

		public GetEventObj()
		{
		}

		string errMsg = String.Empty;

		//24 properties
		string _numberOfEvents = null;
		string _eventID = null;
		string _eventName = null;
		string _eventDate = null;
		string _beginDate = null;
		string _endDate = null;
		string _venueID = null;
		string _venueName = null;
		string _stateProvDesc = null;
		string _stateID = null;
		string _cityZip = null;
		string _nearZip = null;
		string _parentCategoryID = null;
		string _childCategoryID = null;
		string _grandChildCategoryID = null;
		string _performerID = null;
		string _performerName = null;
		string _noPerformers = null;
		string _lowPrice = null;
		string _highPrice = null;
		string _modificationDate = null;
		string _onlyMine = null;
		string _whereClause = null;
		string _orderByClause = null;

		//24 methods
		string numberOfEvents
		{
			get
			{
				return _numberOfEvents;
			}
			set
			{
				_numberOfEvents = value;
			}
		}
		string eventID
		{
			get
			{
				return _eventID;
			}
			set
			{
				_eventID = value;
			}
		}
		string eventName
		{
			get
			{
				return _eventName;
			}
			set
			{
				_eventName = value;
			}
		}
		string eventDate
		{
			get
			{
				return _eventDate;
			}
			set
			{
				_eventDate = value;
			}
		}
		string beginDate
		{
			get
			{
				return _beginDate;
			}
			set
			{
				_beginDate = value;
			}
		}
		string endDate
		{
			get
			{
				return _endDate;
			}
			set
			{
				_endDate = value;
			}
		}
		string venueID
		{
			get
			{
				return _venueID;
			}
			set
			{
				_venueID = value;
			}
		}
		string venueName
		{
			get
			{
				return _venueName;
			}
			set
			{
				_venueName = value;
			}
		}
		string stateProvDesc
		{
			get
			{
				return _stateProvDesc;
			}
			set
			{
				_stateProvDesc = value;
			}
		}
		string stateID
		{
			get
			{
				return _stateID;
			}
			set
			{
				_stateID = value;
			}
		}
		string cityZip
		{
			get
			{
				return _cityZip;
			}
			set
			{
				_cityZip = value;
			}
		}
		string nearZip
		{
			get
			{
				return _nearZip;
			}
			set
			{
				_nearZip = value;
			}
		}
		string parentCategoryID
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
		string childCategoryID
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
		string grandChildCategoryID
		{
			get
			{
				return _grandChildCategoryID;
			}
			set
			{
				_grandChildCategoryID = value;
			}
		}
		string performerID
		{
			get
			{
				return _performerID;
			}
			set
			{
				_performerID = value;
			}
		}
		string performerName
		{
			get
			{
				return _performerName;
			}
			set
			{
				_performerName = value;
			}
		}
		string noPerformers
		{
			get
			{
				return _noPerformers;
			}
			set
			{
				_noPerformers = value;
			}
		}
		string lowPrice
		{
			get
			{
				return _lowPrice;
			}
			set
			{
				_lowPrice = value;
			}
		}
		string highPrice
		{
			get
			{
				return _highPrice;
			}
			set
			{
				_highPrice = value;
			}
		}
		string modificationDate
		{
			get
			{
				return _modificationDate;
			}
			set
			{
				_modificationDate = value;
			}
		}
		string onlyMine
		{
			get
			{
				return _onlyMine;
			}
			set
			{
				_onlyMine = value;
			}
		}
		string whereClause
		{
			get
			{
				return _whereClause;
			}
			set
			{
				_whereClause = value;
			}
		}
		string orderByClause
		{
			get
			{
				return _orderByClause;
			}
			set
			{
				_orderByClause = value;
			}
		}



		public Event[] getData(string configID, Dictionary<string, string> inputParams){

			Event[] eventArray = new Event[1];


			foreach (KeyValuePair<String, String> svcParam in inputParams)
			{
				switch (svcParam.Key)
				{
					case "numberOfEvents":
						numberOfEvents = svcParam.Value;
						break;
					case "eventID":
						eventID = svcParam.Value;
						break;
					case "eventName":
						eventName = svcParam.Value;
						break;
					case "eventDate":
						eventDate = svcParam.Value;
						break;
					case "beginDate":
						beginDate = svcParam.Value;
						break;
					case "endDate":
						endDate = svcParam.Value;
						break;
					case "venueID":
						venueID = svcParam.Value;
						break;
					case "venueName":
						venueName = svcParam.Value;
						break;
					case "stateProvDesc":
						stateProvDesc = svcParam.Value;
						break;
					case "stateID":
						stateID = svcParam.Value;
						break;
					case "cityZip":
						cityZip = svcParam.Value;
						break;
					case "nearZip":
						nearZip = svcParam.Value;
						break;
					case "parentCategoryID":
						parentCategoryID = svcParam.Value;
						break;
					case "childCategoryID":
						childCategoryID = svcParam.Value;
						break;
					case "grandChildCategoryID":
						grandChildCategoryID = svcParam.Value;
						break;
					case "performerID":
						performerID = svcParam.Value;
						break;
					case "performerName":
						performerName = svcParam.Value;
						break;
					case "noPerformers":
						noPerformers = svcParam.Value;
						break;
					case "lowPrice":
						lowPrice = svcParam.Value;
						break;
					case "highPrice":
						highPrice = svcParam.Value;
						break;
					case "modificationDate":
						modificationDate = svcParam.Value;
						break;
					case "onlyMine":
						onlyMine = svcParam.Value;
						break;
					case "whereClause":
						whereClause = svcParam.Value;
						break;
					case "orderByClause":
						orderByClause = svcParam.Value;
						break;
					default:
						break;
				}
			}



			try
			{
				//now call web service using GetEventObj property value
				TNWebServiceStringInputsSoapClient service = new TNWebServiceStringInputsSoapClient("TNWebServiceStringInputsSoap");

				eventArray = service.GetEvents(
						configID,
						numberOfEvents,
						eventID,
						eventName,
						eventDate,
						beginDate,
						endDate,
						venueID,
						venueName,
						stateProvDesc,
						stateID,
						cityZip,
						nearZip,
						parentCategoryID,
						childCategoryID,
						grandChildCategoryID,
						performerID,
						performerName,
						noPerformers,
						lowPrice,
						highPrice,
						modificationDate,
						onlyMine,
						whereClause,
						orderByClause
						);
			}
			catch (Exception e)
			{
				errMsg = e.Message.ToString();
			}
				
			return eventArray;
		}
	}
}
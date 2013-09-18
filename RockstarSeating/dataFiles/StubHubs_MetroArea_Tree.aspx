<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="StubHubs_MetroArea_Tree.aspx.cs" Inherits="RockstarSeating.dataFiles.StubHubs_MetroArea_Tree" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<script>




		var geoTree = { country: 
			[{ name: "USA", 
				state: [{ 
							name: "Alabama", 
							id: "AL", 
							metro: [{ name: "Birmingham", id: "4945"}] 
						}, 
						{	name: "Arizona", 
							id: "AZ", 
							metro: [{ name: "Phoenix", id: "226"}] 
						}, 
						{ 
							name: "Arkansas", 
							id: "AR", 
							metro: [{ name: "Little Rock", id: "3864"}] 
						}, 
						{
							name: "California", 
							id: "CA", 
							metro: [
								{ name: "Los Angeles", id: "10" }, 
								{ name: "San Diego", id: "81689" }, 
								{ name: "Sacramento", id: "81690" }, 
								{ name: "SF Bay Area", id: "81"}] }, 
						{	
							name: "Colorado", 
							id: "CO", 
							metro: [{ name: "Denver", id: "678"}] }, 

						{ 
							name: "Connecticut", 
							id: "CT", 
							metro: [{ name: "Hartford", id: "1869"}] },							


{ name: "Dist. of Columbia", id: "DC", metro: [{ name: "Washington D.C.", id: "525"}] }, { name: "Florida", id: "FL", metro: [{ name: "Jacksonville", id: "708" }, { name: "Tallahassee", id: "6750" }, { name: "Miami/S. Florida", id: "669" }, { name: "Tampa", id: "404" }, { name: "Orlando", id: "663"}] }, { name: "Georgia", id: "GA", metro: [{ name: "Atlanta", id: "670"}] }, { name: "Idaho", id: "ID", metro: [{ name: "Boise", id: "4921"}] }, { name: "Illinois", id: "IL", metro: [{ name: "Chicago", id: "666"}] }, { name: "Indiana", id: "IN", metro: [{ name: "Indianapolis", id: "697"}] }, { name: "Iowa",
	id: "IA", metro: [{ name: "Des Moines", id: "5637"}]
}, { name: "Kentucky", id: "KY", metro: [{ name: "Louisville", id: "4421"}] }, { name: "Louisiana", id: "LA", metro: [{ name: "New Orleans", id: "242"}] }, { name: "Maryland", id: "MD", metro: [{ name: "Baltimore", id: "81691"}] }, { name: "Massachusetts", id: "MA", metro: [{ name: "Boston", id: "674"}] }, { name: "Michigan", id: "MI", metro: [{ name: "Detroit", id: "676" }, { name: "Grand Rapids", id: "4204"}] }, { name: "Minnesota", id: "MN", metro: [{ name: "Minneapolis", id: "680"}] }, { name: "Mississippi", id: "MS", metro: [{ name: "Jackson",
	id: "5543"
}]
}, { name: "Missouri", id: "MO", metro: [{ name: "Kansas City", id: "702" }, { name: "St. Louis", id: "683"}] }, {

	name: "Montana",
	id: "MT",
	metro: [{ name: "Missoula", id: "5924"}]
},
{ 
	name: "Nebraska", id: "NE", metro: [{ name: "Lincoln", id: "5530"}] }, { name: "Nevada", id: "NV", metro: [{ name: "Las Vegas", id: "689" }, { name: "Reno", id: "5627"}] }, { name: "New Jersey", id: "NJ", metro: [{ name: "Atlantic City", id: "78083"}] }, { name: "New Mexico", id: "NM", metro: [{ name: "Albuquerque", id: "5647"}] }, { name: "New York", id: "NY", metro: [{ name: "Albany", id: "1868" },
{ name: "Syracuse", id: "6472" }, { name: "Buffalo", id: "695" }, { name: "New York Metro", id: "664"}]
}, { name: "North Carolina", id: "NC", metro: [{ name: "Charlotte", id: "684" }, { name: "Raleigh-Durham", id: "685"}] }, { name: "North Dakota", id: "ND", metro: [{ name: "Fargo", id: "4423"}] }, { name: "Ohio", id: "OH", metro: [{ name: "Cincinnati", id: "11863" }, { name: "Cleveland", id: "3261" }, { name: "Columbus", id: "11883"}] }, { name: "Oklahoma", id: "OK", metro: [{ name: "Oklahoma City", id: "3863"}] }, { name: "Oregon", id: "OR", metro: [{ name: "Portland", id: "704"}] }, { name: "Pennsylvania",
	id: "PA", metro: [{ name: "Philadelphia", id: "522" }, { name: "Pittsburgh", id: "681"}]
}, { name: "South Carolina", id: "SC", metro: [{ name: "Charleston", id: "4481" }, { name: "Columbia", id: "5630"}] }, { name: "South Dakota", id: "SD", metro: [{ name: "Sioux Falls", id: "6743"}] }, { name: "Tennessee", id: "TN", metro: [{ name: "Knoxville", id: "5528" }, { name: "Memphis", id: "701" }, { name: "Nashville", id: "700"}] }, { name: "Texas", id: "TX", metro: [{ name: "Dallas", id: "672" }, { name: "El Paso", id: "4426" }, { name: "Houston", id: "694" }, { name: "Lubbock", id: "3861" }, { name: "Austin/San Antonio",
	id: "707"
}]
}, { name: "Utah", id: "UT", metro: [{ name: "Salt Lake City", id: "706"}] }, { name: "Virginia", id: "VA", metro: [{ name: "Richmond", id: "4425"}] }, { name: "Washington", id: "WA", metro: [{ name: "Seattle", id: "693"}] }, { name: "West Virginia", id: "WV", metro: [{ name: "Charleston, WV", id: "4541"}] }, { name: "Wisconsin", id: "WI", metro: [{ name: "Green Bay", id: "4422" }, { name: "Milwaukee", id: "691"}] }, { name: "Wyoming", id: "WY", metro: [{ name: "Casper", id: "9465"}]}]
		}, { name: "Canada", state: [{ name: "AB", id: "AB", metro: [{ name: "Calgary", id: "5878" }, { name: "Edmonton",
			id: "5877"
		}]
		}, { name: "NB", id: "NB", metro: [{ name: "Fredericton", id: "7126"}] }, { name: "NS", id: "NS", metro: [{ name: "Halifax", id: "7124"}] }, { name: "QC", id: "QC", metro: [{ name: "Montreal", id: "5879"}] }, { name: "ON", id: "ON", metro: [{ name: "Ottawa", id: "5874" }, { name: "Toronto", id: "5869"}] }, { name: "SK", id: "SK", metro: [{ name: "Saskatoon", id: "7604"}] }, { name: "BC", id: "BC", metro: [{ name: "Vancouver", id: "5871"}] }, { name: "MB", id: "MB", metro: [{ name: "Winnipeg", id: "6204"}]}]
		}]
		};



	</script>
</asp:Content>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockstarSeating.dataFiles
{
    using System;

    public class UserObj
    {
        string _Message;

        string _UserPass;
        string _LoginHash;
        string _LoginV;

        string _FirstName;
        string _LastName;
        string _Email;
        string _Address1;
        string _Address2;
        string _City;
        string _State;
        string _Zip;
        string _Zip2;
        string _Phone;
        bool _mailingList;



        Boolean _isConsignor;
        Boolean _isAdmin;

        int _userId;
        string _consignorCode;


        public UserObj()
        {
        }


        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }






        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        public string Address1
        {
            get
            {
                return _Address1;
            }
            set
            {
                _Address1 = value;
            }
        }
        public string Address2
        {
            get
            {
                return _Address2;
            }
            set
            {
                _Address2 = value;
            }
        }
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }
        public string Zip
        {
            get
            {
                return _Zip;
            }
            set
            {
                _Zip = value;
            }
        }
        public string Zip2
        {
            get
            {
                return _Zip2;
            }
            set
            {
                _Zip2 = value;
            }
        }
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }
        
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public string UserPass
        {
            get
            {
                return _UserPass;
            }
            set
            {
                _UserPass = value;
            }
        }
        public string LoginHash
        {
            get
            {
                return _LoginHash;
            }
            set
            {
                _LoginHash = value;
            }
        }
        public string LoginV
        {
            get
            {
                return _LoginV;
            }
            set
            {
                _LoginV = value;
            }
        }





        public Boolean isConsignor
        {
            get
            {
                return _isConsignor;
            }
            set
            {
                _isConsignor = value;
            }
        }

        public Boolean isAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                _isAdmin = value;
            }
        }


        public Boolean mailingList
        {
            get
            {
                return _mailingList;
            }
            set
            {
                _mailingList = value;
            }
        }

        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }


        }

        public string consignorCode
        {
            get
            {
                return _consignorCode;
            }
            set
            {
                _consignorCode = value;
            }
        }
    }
}
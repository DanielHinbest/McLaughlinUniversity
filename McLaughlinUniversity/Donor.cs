using System;
using System.Collections.Generic;
using System.Text;

namespace McLaughlinUniversity
{
    class Donor
    {

        private string donorFirstName = String.Empty;
        private string donorLastName = String.Empty;
        private string donorPhoneNo = String.Empty;
        private string donorEmailAddress = String.Empty;
        private string donorCorporationName = String.Empty;
        private string donorFoundationName = String.Empty;
        private int donorTypeID = 0;

        public Donor(string firstNameValue, string lastNameValue, string emailAddressValue, string phoneNoValue, string corporationNameValue, int donorTypeIdValue)
        {
            this.donorFirstName = firstNameValue;
            this.donorLastName = lastNameValue;
            this.donorEmailAddress = emailAddressValue;
            this.donorPhoneNo = phoneNoValue;
            this.donorCorporationName = corporationNameValue;
            this.DonorTypeID = donorTypeIdValue;

            DataAccess.InsertNewDonor(this);
        }

        //public Donor(string firstNameValue, string lastNameValue, string emailAddressValue, string phoneNoValue, string foundationNameValue, int donorTypeIdValue)
        //{
        //    this.donorFirstName = firstNameValue;
        //    this.donorLastName = lastNameValue;
        //    this.donorEmailAddress = emailAddressValue;
        //    this.donorPhoneNo = phoneNoValue;
        //    this.donorFoundationName = foundationNameValue;
        //    this.donorTypeID = donorTypeIdValue;

        //    DataAccess.InsertNewDonor(this);
        //}

        public Donor(string firstNameValue, string lastNameValue, string emailAddressValue, string phoneNoValue, int donorTypeIdValue)
        {
            this.FirstName = firstNameValue;
            this.LastName = lastNameValue;
            this.EmailAddress = emailAddressValue;
            this.PhoneNo = phoneNoValue;
            this.donorTypeID = donorTypeIdValue;

            DataAccess.InsertNewDonor(this);
        }

        public Donor()
        {

        }

        public string FirstName
        {
            get
            {
                return donorFirstName;
            }
            set 
            {
                donorFirstName = value;

                if (donorFirstName == "")
                {
                    throw new ArgumentException("Please enter donor'r first name", "FIrst name error");
                }
                else if (donorFirstName.Length > 30)
                {
                    throw new ArgumentException("Donor first name contains more than 30 letter.", "FIrst name error");
                }
            }
        }

        public string LastName
        {

            get
            {
                return donorLastName;
            }
            set
            {
                donorLastName = value;

                if (donorLastName == "")
                {
                    throw new ArgumentException("Please enter donor'r last name", "Last name error");
                }
                else if (donorLastName.Length > 50)
                {
                    throw new ArgumentException("Donor last name contains more than 30 letter.", "Last name error");
                }
            }
        }

        public string EmailAddress
        {
            get
            {
                return donorEmailAddress;
            }
            set
            {
                donorEmailAddress = value;

                if (donorEmailAddress == "")
                {
                    throw new ArgumentException("Please enter donor's email address.", "Email address error");
                }
                else if (donorEmailAddress.Length > 50)
                {
                    throw new ArgumentException("Donor's email contains more than 50 characters", "Email address error");
                }
            }
        }

        public string PhoneNo
        {
            get
            {
                return donorPhoneNo;
            }
            set
            {
                donorPhoneNo = value;

                if (donorPhoneNo == "")
                {
                    throw new ArgumentException("Please enter donor's phone number.", "Phone number error");
                }
                else if (donorPhoneNo.ToString().Length > 10)
                {
                    throw new ArgumentException("Phone no must be 10 digit long.", "Phone number error");
                }
            }
        }

        public string CorporationName
        {
            get
            {
                return donorCorporationName;
            }
            set
            {
                donorCorporationName = value;

                if (donorCorporationName.Length > 30)
                {
                    throw new ArgumentException("Corporation name is out of range.", "Corporation name error");
                }
            }
        }

        public string FoundationName
        {
            get
            {
                return donorFoundationName;
            }
            set
            {
                donorFoundationName = value;

                if (donorFoundationName.Length > 30)
                {
                    throw new ArgumentException("Foundation name is out of range.", "Foundation name error");
                }
            }
        }

        public int DonorTypeID
        {
            get
            {
                return donorTypeID;
            }
            set
            {
                donorTypeID = value;
            }
        }


        public string Show()
        {
            string s = "Donor Name: " + this.donorFirstName + " " + this.donorLastName + "\n" +
                "Email Address: " + this.donorEmailAddress + "\n" +
                "Phone No: " + this.donorPhoneNo + "\n" +
                "Foudnation Name: " + this.donorFoundationName + "\n" +
                "Corporation Name: " + this.donorCorporationName + "\n" +
            "Donor Type ID: " + this.donorTypeID + "\n";
            return s;
        }
    }
}

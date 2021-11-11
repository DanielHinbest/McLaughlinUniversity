using System;
using System.Collections.Generic;
using System.Text;

namespace McLaughlinUniversity
{
    class User
    {
        private string userID;
        private string password;

        public User()
        {

        }

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}

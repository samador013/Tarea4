using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Model
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }

        public bool Validate() {
            return (UserName.Equals("test") && Pwd.Equals("test")) ? true : false;
           
        }
    }
}

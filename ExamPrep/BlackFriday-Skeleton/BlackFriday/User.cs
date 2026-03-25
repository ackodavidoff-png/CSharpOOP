using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday
{
    public abstract class User : IUser
    {
        protected User(string userName, string email)
        {
            this.UserName = userName;
            this.Email = email;
        }
        private string username;
        private string email;
        public string UserName
        {
            get
            {
                return username; 
            }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.UserNameRequired);
                }
                username = value; 
            }
        }

        public virtual bool HasDataAccess  { get; }

        public string Email
        {
            get
            {
                if(this.HasDataAccess)
                {
                    return "hidden";
                }
                return email; 
            }
            private set
            {
                if (!this.HasDataAccess && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmailRequired);
                }
                email = value;
            }
        }
        public override string ToString()
        {
            string status = HasDataAccess ? "Admin" : "Client";
            return $"{this.UserName} - Status: {status}, Contact Info: {this.Email}";
        }
    }
}

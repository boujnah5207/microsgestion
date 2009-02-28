using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Services;

namespace Blackspot.Microgestion.Backend.Entities
{
    public partial class User : IPersistible
    {
        partial void OnCreated()
        {
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }

        public override bool Equals(object obj)
        {
            User user = obj as User;
            if (user == null)
                return base.Equals(obj);
            else
                return user.ID.Equals(this.ID)
                    && user.Username.Equals(this.Username)
                    && user.Password.Equals(this.Password)
                    && user.Name.Equals(this.Name)
                    && user.LastName.Equals(this.LastName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool IsNullUser()
        {
            return this.Equals(UserService.NullUser);
        }

        public string GetUserInfo()
        {
            if (this.IsNullUser())
                return "Anónimo";
            else
                return String.Format("{0} {1} ({2})", this.Name, this.LastName, this.Username);
        }

        public bool IsValid()
        {
            return
                !String.IsNullOrEmpty(this._Name) &&
                !String.IsNullOrEmpty(this._Username) &&
                !String.IsNullOrEmpty(this._LastName);
        }
    }
}

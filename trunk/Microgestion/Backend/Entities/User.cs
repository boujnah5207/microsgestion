using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Services;

namespace Blackspot.Microgestion.Backend.Entities
{
    public partial class User : IIdentificableEntity
    {
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
            return this.Equals(UserService.CreateNullUser());
        }

        public string GetUserInfo()
        {
            if (this.IsNullUser())
                return "Anónimo";
            else
                return this.Username;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysQ.Microgestion.Backend.Entities
{
    public partial class UserRoles : IPersistible
    {
        #region IPersistible Members


        public bool IsValid()
        {
            return
                this.UserID != Guid.Empty &&
                this.RoleID != Guid.Empty;
        }

        #endregion
    }
}

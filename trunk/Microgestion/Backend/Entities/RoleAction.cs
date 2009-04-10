using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Enumerations;

namespace SysQ.Microgestion.Backend.Entities
{
    public partial class RoleAction : IPersistible
    {
        public SystemAction Action
        {
            get
            {
                return (SystemAction)Enum.Parse(typeof(SystemAction), this.ActionID.ToString());
            }
            set
            {
                this.ActionID = (int)value;
            }
        }

        #region IPersistible Members


        public bool IsValid()
        {
            return
                this.RoleID != Guid.Empty;
        }

        #endregion
    }
}

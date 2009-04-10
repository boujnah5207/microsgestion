using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Backend.Enumerations;

namespace SysQ.Microgestion.Backend.Entities
{
    public partial class Role : IPersistible
    {
        public void AddAction(SystemAction action)
        {
            if (this.Actions.Any (a => a.Action.Equals(action)))
                return;

            RoleAction ra = new RoleAction { Action = action, RoleID = this.ID };
            RoleActionService.Save(ra);
            this.Actions.Add(ra);
        }

        public void RemoveAction(SystemAction action)
        {
            RoleAction actionToRemove = this.Actions.Where(a => a.Action.Equals(action)).SingleOrDefault();

            if (actionToRemove == null)
                return;

            RoleActionService.Delete(actionToRemove);
            this.Actions.Remove(actionToRemove);
        }

        public override string ToString()
        {
            return this.Name;
        }

        public bool IsValid()
        {
            return
                !String.IsNullOrEmpty(this.Name);
        }
    }
}

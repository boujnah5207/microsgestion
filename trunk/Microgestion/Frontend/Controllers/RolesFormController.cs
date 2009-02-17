using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;
using System.ComponentModel;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Enumerations;
using System.Windows.Forms;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class RolesFormController : ControllerBase<RolesForm>
    {
        public RolesFormController(RolesForm form)
            : base(form) { }

        internal BindingList<Role> Roles { get; set; }

        internal override void InitializeForm()
        {
            Roles = new BindingList<Role>(RoleService.GetAll());
            base.InitializeForm();
        }

        public bool AllowAdd { get { return UserService.CanPerform(SystemAction.AddRole); } set { } }
        public bool AllowDelete { get { return UserService.CanPerform(SystemAction.DeleteRole); } set { } }
        public bool AllowModify
        {
            get
            {
                return !(UserService.CanPerform(SystemAction.EditRole) &&
                         UserService.CanPerform(SystemAction.AddRole));
            }
            set { }
        }
        
        internal void AddNew()
        {
            Role newRole = Roles.AddNew();
            RoleService.Save(newRole);

            Form.Grid.CurrentCell = Form.Grid.Rows[Form.Grid.Rows.Count - 1].Cells[1];
        }

        internal void Delete()
        {
            foreach (DataGridViewRow row in Form.Grid.SelectedRows)
            {
                Role role = (Role)row.DataBoundItem;
                RoleService.Delete(role);
                Roles.Remove(role);
            }
        }
    }
}

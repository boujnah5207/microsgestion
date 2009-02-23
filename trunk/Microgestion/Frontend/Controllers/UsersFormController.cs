using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Services;
using System.Windows.Forms;
using System.ComponentModel;
using Blackspot.Microgestion.Backend.Enumerations;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class UsersFormController : ControllerBase<UsersForm>
    {
        public UsersFormController(UsersForm form)
            : base(form) { }


        internal BindingList<User> Users { get; set; }

        internal override void InitializeForm()
        {
            Users = new BindingList<User>(UserService.GetAll());

            base.InitializeForm();
        }

        public bool AllowAdd { get { return UserService.CanPerform(SystemAction.UserAdd); } set { } }
        public bool AllowDelete { get { return UserService.CanPerform(SystemAction.UserDelete); } set { } }
        public bool AllowModify
        {
            get
            {
                return UserService.CanPerform(SystemAction.UserEdit) ||
                       UserService.CanPerform(SystemAction.UserAdd);
            }
            set { }
        }


        internal void AddNew()
        {
            User newUser = Users.AddNew();
            UserService.Save(newUser);

            Form.Grid.CurrentCell = Form.Grid.Rows[Form.Grid.Rows.Count - 1].Cells[1];
            Form.TxtName.Focus();
        }

        internal void Delete()
        {
            foreach (DataGridViewRow row in Form.Grid.SelectedRows)
            {
                User user = (User)row.DataBoundItem;
                UserService.Delete(user);
                Users.Remove(user);
            }
        }

    }
}

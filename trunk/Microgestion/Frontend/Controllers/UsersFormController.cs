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
        public bool AllowEdit
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
            User newUser = new User();

            UserEditor editor = new UserEditor(newUser);

            var result = editor.ShowDialog();
            if (result == DialogResult.Cancel)
                return;

            Users.Add(newUser);
            Form.Grid.CurrentCell = Form.Grid.Rows[Form.Grid.Rows.Count - 1].Cells[1];
            UserService.Save(newUser);
        }

        internal void Delete()
        {
            if (Form.Grid.SelectedRows.Count != 1)
                return;

            if (UserAccepts(
                "¿Desea eliminar el usuario seleccionado?",
                "Eliminar usuario"))
            {
                User user = Form.Grid.SelectedRows[0].DataBoundItem as User;
                UserService.Delete(user);
                Users.Remove(user);
            }
        }


        internal void Edit()
        {
            if (Form.Grid.SelectedRows.Count != 1)
                return;

            User user = Form.Grid.SelectedRows[0].DataBoundItem as User;

            string userName = user.Name;
            string userLastName = user.LastName;
            string userUsername = user.Username;

            UserEditor editor = new UserEditor(user);

            var result = editor.ShowDialog(Form);
            if (result == DialogResult.Cancel)
            {
                user.Name = userName;
                user.LastName = userLastName;
                user.Username = userUsername;
            }
            else
            {
                UserService.Update(user);
            }
        }
    }
}

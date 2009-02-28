using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Services;
using System.Windows.Forms;
using System.ComponentModel;
using Blackspot.Microgestion.Backend.Enumerations;
using Blackspot.Microgestion.Frontend.Forms;
using Blackspot.Microgestion.Frontend.Extensions;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class UsersFormController : ControllerBase<UsersForm>
    {
        public UsersFormController(UsersForm form)
            : base(form) { }


        internal BindingList<User> Users { get; set; }

        internal override void InitializeForm()
        {
            try
            {
                Users = new BindingList<User>(UserService.GetAll());

                base.InitializeForm();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
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
            try
            {
                User newUser = new User();

                using (UserEditor editor = new UserEditor(newUser))
                {
                    var result = editor.ShowDialog();
                    if (result == DialogResult.Cancel)
                        return;

                    UserService.Save(newUser, editor.Roles);
                    Users.Add(newUser);
                    Form.Grid.CurrentCell = Form.Grid.Rows[Form.Grid.Rows.Count - 1].Cells[1];
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        internal void Delete()
        {
            try
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
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }


        internal void Edit()
        {
            try
            {
                if (Form.Grid.SelectedRows.Count != 1)
                    return;

                User user = Form.Grid.SelectedRows[0].DataBoundItem as User;

                string userName = user.Name;
                string userLastName = user.LastName;
                string userUsername = user.Username;
                string userPassword = user.Password;

                using (UserEditor editor = new UserEditor(user))
                {
                    var result = editor.ShowDialog(Form);
                    if (result == DialogResult.Cancel)
                    {
                        user.Name = userName;
                        user.LastName = userLastName;
                        user.Username = userUsername;
                        user.Password = userPassword;
                    }
                    else
                    {
                        UserService.Update(user, editor.Roles);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }
    }
}

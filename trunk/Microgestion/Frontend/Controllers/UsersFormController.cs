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

        internal IList<User> Users
        {
            get
            {
                return UserService.GetAll<User>();
            }
        }

        internal override void InitializeForm()
        {
            base.InitializeForm();
        }

        public bool EnableAddButton { get { return UserService.CanPerform(SystemAction.AddUser); } set { } }
        public bool EnableDeleteButton { get { return UserService.CanPerform(SystemAction.DeleteUser); } set { } }
        public bool EnableModifyButton { get { return UserService.CanPerform(SystemAction.ModifyUser); } set { } }

        public bool IsEditing { get; set; }

    }
}

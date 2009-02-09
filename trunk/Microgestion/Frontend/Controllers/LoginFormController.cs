using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Services;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class LoginFormController : ControllerBase<LoginForm>
    {
        public LoginFormController(LoginForm form)
            :base(form){}

        internal void InitializeForm()
        {
            Form.Username = UserService.LoggedInUser.Name;
            Form.Password = UserService.LoggedInUser.Password;

        }
    }
}

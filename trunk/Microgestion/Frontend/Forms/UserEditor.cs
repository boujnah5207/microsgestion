using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Frontend.Extensions;

namespace Blackspot.Microgestion.Frontend.Forms
{
    public partial class UserEditor : Form
    {
        public User User { get; set; }
        public BindingList<Role> Roles { get; set; }

        private UserEditor() { }

        public UserEditor(User user)
        {
            try
            {
                InitializeComponent();

                this.User = user;
                this.Roles = new BindingList<Role>(UserService.GetRoles(user));

                this.txtName.DataBindings.Add(new Binding("Text", User, "Name"));
                this.txtLastName.DataBindings.Add(new Binding("Text", User, "LastName"));
                this.txtUsername.DataBindings.Add(new Binding("Text", User, "Username"));

                this.lstRoles.DataSource = Roles;

                this.btnRemoveRole.Click += (s, e) =>
                {
                    if (lstRoles.SelectedItem == null)
                        return;

                    Roles.Remove((Role)lstRoles.SelectedItem);
                };

                this.btnAddRole.Click += (s, e) =>
                {
                    using (LookupForm<Role> lookup = new LookupForm<Role>())
                    {
                        lookup.Filter = Roles;
                        var dr = lookup.ShowDialog();
                        if (dr != DialogResult.OK)
                            return;

                        Role role = lookup.SelectedItem;
                        if (role != null)
                            Roles.Add(role);
                    }
                };

            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }
    }
}

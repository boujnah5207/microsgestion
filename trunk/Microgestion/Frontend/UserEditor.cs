using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Frontend
{
    public partial class UserEditor : Form
    {
        public User User { get; set; }

        private UserEditor() { }

        public UserEditor(User user)
        {
            InitializeComponent();

            this.User = user;

            this.txtName.DataBindings.Add(new Binding("Text", User, "Name"));
            this.txtLastName.DataBindings.Add(new Binding("Text", User, "LastName"));
            this.txtUsername.DataBindings.Add(new Binding("Text", User, "Username"));
        }
    }
}

﻿using System;
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
    public partial class RoleEditor : Form
    {
        private RoleEditor(){}

        public RoleEditor(Role role)
        {
            try
            {
                InitializeComponent();
                
                this.Role = role;

                this.txtName.DataBindings.Add(new Binding("Text", Role, "Name"));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Role Role { get; set; }
        
    }

}
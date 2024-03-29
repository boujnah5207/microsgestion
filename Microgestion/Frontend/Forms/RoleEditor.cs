﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Frontend.Extensions;

namespace SysQ.Microgestion.Frontend.Forms
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
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        public Role Role { get; set; }
        
    }

}

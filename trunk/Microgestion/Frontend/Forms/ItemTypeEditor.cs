using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Frontend.Extensions;

namespace Blackspot.Microgestion.Frontend.Forms
{
    public partial class ItemTypeEditor : Form
    {

        private ItemTypeEditor() { }

        public ItemTypeEditor(ItemType itemType)
        {
            try
            {
                InitializeComponent();

                this.ItemType = itemType;

                this.txtName.DataBindings.Add(new Binding("Text", ItemType, "Name"));
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        public ItemType ItemType { get; set; }
    }
}

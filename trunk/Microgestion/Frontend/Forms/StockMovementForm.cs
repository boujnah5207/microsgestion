using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Controllers;
using Blackspot.Microgestion.Frontend.Extensions;

namespace Blackspot.Microgestion.Frontend.Forms
{
    public partial class StockMovementForm : Form
    {
        StockMovementController Controller { get; set; }
        
        public StockMovementForm()
        {
            InitializeComponent();

            Controller = new StockMovementController(this);

            InitializeBindings();
            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            try
            {
                this.FormClosing += (s, e) =>
                {
                    ((Form)s).Hide();
                    ((FormClosingEventArgs)e).Cancel = true;
                };
                this.btnClose.Click += (s, e) => this.Close();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private void InitializeBindings()
        {
            try
            {
                this.lblDate.DataBindings.Add(new Binding("Text", Controller, "Date"));
                this.txtComments.DataBindings.Add(new Binding("Text", Controller, "Comments"));

                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", Visible = false });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "InternalID", Visible = false });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", Visible = false });
                this.Grid.Columns.Add(new DataGridViewComboBoxColumn { DataPropertyName = "ItemID", DataSource = Controller.Items, DisplayMember = "Name", ValueMember = "ID", HeaderText = "Artículo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "Cantidad", Visible = false });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StockMovementID", Visible = false });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StockDetailID", Visible = false });


                this.Grid.DataSource = Controller.Details;
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

    }
}

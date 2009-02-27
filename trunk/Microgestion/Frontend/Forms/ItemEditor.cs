using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Frontend.Forms
{
    public partial class ItemEditor : Form
    {

        private ItemEditor() { }

        public ItemEditor(Item item)
        {
            try
            {
                InitializeComponent();

                this.Item = item;

                InitializeBindings();

                InitializeHandlers();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void InitializeHandlers()
        {
            this.btnLookupMeasurement.Click += (s, e) =>
            {
                using (LookupForm<Measurement> lookup = new LookupForm<Measurement>())
                {
                    var dr = lookup.ShowDialog();
                    if (dr != DialogResult.OK)
                        return;

                    Measurement measurement = lookup.SelectedItem;
                    if (measurement != null)
                        Item.BaseMeasurement = measurement;
                }
            };

        }

        private void InitializeBindings()
        {
            this.txtName.DataBindings.Add(new Binding("Text", Item, "Name"));
            this.txtInternalCode.DataBindings.Add(new Binding("Text", Item, "InternalCode"));
            this.txtExternalCode.DataBindings.Add(new Binding("Text", Item, "ExternalCode"));
            this.txtBaseMeasurement.DataBindings.Add(new Binding("Text", Item, "BaseMeasurement"));
            this.txtDefaultSalesAmount.DataBindings.Add(new Binding("Text", Item, "DefaultSalesAmount"));
            this.chkMovesStock.DataBindings.Add(new Binding("Checked", Item, "MovesStock"));
            this.lblActualStock.DataBindings.Add(new Binding("Text", Item, "ActualStock"));
            this.lblMinimumStock.DataBindings.Add(new Binding("Text", Item, "MinimumStock"));
        }

        public Item Item { get; set; }

    }
}

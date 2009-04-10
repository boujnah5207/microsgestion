using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Frontend.Extensions;
using SysQ.Microgestion.Backend.Services;

namespace SysQ.Microgestion.Frontend.Forms
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
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private void InitializeHandlers()
        {
            // Select Measurement
            this.btnLookupMeasurement.Click += (s, e) =>
            {
                try
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

                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox();
                }
            };

            // Select ItemType
            this.btnLookupItemType.Click += (s, e) =>
            {
                try
                {
                    using (LookupForm<ItemType> lookup = new LookupForm<ItemType>())
                    {
                        var dr = lookup.ShowDialog();
                        if (dr != DialogResult.OK)
                            return;

                        ItemType itemType = lookup.SelectedItem;
                        if (itemType != null)
                            Item.ItemType = itemType;
                    }

                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox();
                }
            };

            // Manage Prices
            this.btnPrices.Click += (s, e) =>
            {
                try
                {
                    Double current = this.Item.CurrentPrice == null ? 0 : this.Item.CurrentPrice.Value;
                    using (PriceEditor editor = new PriceEditor(current))
                    {
                        var dr = editor.ShowDialog();
                        if (dr != DialogResult.OK)
                            return;

                        if (editor.NewValue != editor.CurrentValue)
                        {
                            Price newPrice = new Price
                            {
                                Date = DateTime.Now,
                                Value = editor.NewValue
                            };
                            Item.CurrentPrice = newPrice;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox();
                }
            };
        }

        private void InitializeBindings()
        {
            try
            {
                this.txtName.DataBindings.Add(new Binding("Text", Item, "Name"));
                this.txtInternalCode.DataBindings.Add(new Binding("Text", Item, "InternalCode"));
                this.txtExternalCode.DataBindings.Add(new Binding("Text", Item, "ExternalCode"));
                this.txtBaseMeasurement.DataBindings.Add(new Binding("Text", Item, "BaseMeasurement"));
                this.txtItemType.DataBindings.Add(new Binding("Text", Item, "ItemType"));
                this.txtPrice.DataBindings.Add(new Binding("Text", Item, "CurrentPrice"));
                this.chkMovesStock.DataBindings.Add(new Binding("Checked", Item, "MovesStock"));
                this.txtMinimumStock.DataBindings.Add(new Binding("Text", Item, "MinimumStock"));

            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        public Item Item { get; set; }

    }
}

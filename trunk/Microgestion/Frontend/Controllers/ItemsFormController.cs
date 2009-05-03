using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Frontend.Forms;
using SysQ.Microgestion.Backend.Entities;
using System.ComponentModel;
using SysQ.Microgestion.Backend.Enumerations;
using SysQ.Microgestion.Backend.Services;
using System.Windows.Forms;
using SysQ.Microgestion.Frontend.Extensions;

namespace SysQ.Microgestion.Frontend.Controllers
{
    internal class ItemsFormController : ControllerBase<ItemsForm>
    {
        private ItemsFormController() { }

        public ItemsFormController(ItemsForm form)
            : base(form) { }

        internal BindingList<Item> Items { get; set; }

        internal override void InitializeForm()
        {
            try
            {
                Items = new BindingList<Item>(ItemService.GetAll(i => i.Name));

                base.InitializeForm();

            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        public bool AllowAdd { get { return UserService.CanPerform(SystemAction.ItemAdd); } set { } }
        public bool AllowDelete { get { return UserService.CanPerform(SystemAction.ItemDelete); } set { } }
        public bool AllowEdit
        {
            get
            {
                return (UserService.CanPerform(SystemAction.ItemEdit) ||
                        UserService.CanPerform(SystemAction.ItemAdd));
            }
            set { }
        }

        internal void AddNew()
        {
            try
            {
                Item newItem = new Item();

                ItemEditor editor = new ItemEditor(newItem);

                var result = editor.ShowDialog();
                if (result == DialogResult.Cancel)
                    return;

                ItemService.Save(newItem);
                Items.Add(newItem);
                Form.Grid.CurrentCell = Form.Grid.Rows[Form.Grid.Rows.Count - 1].Cells["Name"];

            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        internal void Delete()
        {
            try
            {
                if (Form.Grid.SelectedRows.Count != 1)
                    return;

                if (UserAccepts(
                    "¿Desea eliminar el artículo seleccionado?",
                    "Eliminar Item"))
                {
                    Item item = Form.Grid.SelectedRows[0].DataBoundItem as Item;
                    ItemService.Delete(item);
                    Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        internal void Edit()
        {
            try
            {
                if (Form.Grid.SelectedRows.Count != 1)
                    return;

                Item item = Form.Grid.SelectedRows[0].DataBoundItem as Item;

                string itemName = item.Name;
                Measurement itemBaseMeasurement = item.BaseMeasurement;
                Price itemCurrentPrice = item.CurrentPrice;
                string itemExternalCode = item.ExternalCode;
                string itemInternalCode = item.InternalCode;
                double itemMinimumStock = item.MinimumStock;
                bool itemMovesStock = item.MovesStock;
                ItemType itemType = item.ItemType;

                ItemEditor editor = new ItemEditor(item);

                var result = editor.ShowDialog(Form);
                if (result == DialogResult.Cancel)
                {
                    item.Name = itemName;
                    item.BaseMeasurement = itemBaseMeasurement;
                    item.CurrentPrice = itemCurrentPrice;
                    item.ExternalCode = itemExternalCode;
                    item.InternalCode = itemInternalCode;
                    item.MinimumStock = item.MinimumStock;
                    item.MovesStock = itemMovesStock;
                    item.ItemType = itemType;
                }
                else
                {
                    ItemService.Update(item);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }
    }
}

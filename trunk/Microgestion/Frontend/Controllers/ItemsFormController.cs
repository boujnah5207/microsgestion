using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Frontend.Forms;
using Blackspot.Microgestion.Backend.Entities;
using System.ComponentModel;
using Blackspot.Microgestion.Backend.Enumerations;
using Blackspot.Microgestion.Backend.Services;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Extensions;

namespace Blackspot.Microgestion.Frontend.Controllers
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
                Items = new BindingList<Item>(ItemService.GetAll());

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
                Form.Grid.CurrentCell = Form.Grid.Rows[Form.Grid.Rows.Count - 1].Cells[1];

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

                string measurementName = item.Name;
                //string measurementAbbreviation = item.Abbreviation;

                ItemEditor editor = new ItemEditor(item);

                var result = editor.ShowDialog(Form);
                if (result == DialogResult.Cancel)
                {
                    item.Name = measurementName;
                    //item.Abbreviation = measurementAbbreviation;
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

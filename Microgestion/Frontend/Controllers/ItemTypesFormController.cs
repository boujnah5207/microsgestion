using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Forms;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Extensions;
using Blackspot.Microgestion.Backend.Enumerations;
using Blackspot.Microgestion.Frontend.Extensions;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class ItemTypesFormController : ControllerBase<ItemTypesForm>
    {

        public ItemTypesFormController(ItemTypesForm form)
            : base(form) { }

        internal BindingList<ItemType> ItemTypes { get; set; }

        internal override void InitializeForm()
        {
            try
            {
                ItemTypes = new BindingList<ItemType>(ItemTypeService.GetAll());

                base.InitializeForm();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        public bool AllowAdd { get { return UserService.CanPerform(SystemAction.ItemTypeAdd); } set { } }
        public bool AllowDelete { get { return UserService.CanPerform(SystemAction.ItemTypeDelete); } set { } }
        public bool AllowEdit
        {
            get
            {
                return (UserService.CanPerform(SystemAction.ItemTypeEdit) ||
                        UserService.CanPerform(SystemAction.ItemTypeAdd));
            }
            set { }
        }

        internal void AddNew()
        {
            try
            {
                ItemType newItemType = new ItemType();

                ItemTypeEditor editor = new ItemTypeEditor(newItemType);

                var result = editor.ShowDialog();
                if (result == DialogResult.Cancel)
                    return;

                ItemTypeService.Save(newItemType);
                ItemTypes.Add(newItemType);
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
                    "¿Desea eliminar la rubro seleccionada?",
                    "Eliminar Rubro"))
                {
                    ItemType itemType = Form.Grid.SelectedRows[0].DataBoundItem as ItemType;
                    ItemTypeService.Delete(itemType);
                    ItemTypes.Remove(itemType);
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

                ItemType itemType = Form.Grid.SelectedRows[0].DataBoundItem as ItemType;

                string name = itemType.Name;

                ItemTypeEditor editor = new ItemTypeEditor(itemType);

                var result = editor.ShowDialog(Form);
                if (result == DialogResult.Cancel)
                {
                    itemType.Name = name;
                }
                else
                {
                    ItemTypeService.Update(itemType);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }
    }
}

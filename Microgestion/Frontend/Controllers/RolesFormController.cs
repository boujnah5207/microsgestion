using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Entities;
using System.ComponentModel;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Backend.Enumerations;
using SysQ.Microgestion.Backend.Extensions;
using SysQ.Microgestion.Frontend.Forms;
using SysQ.Microgestion.Frontend.Extensions;
using System.Windows.Forms;
using System.Data.Linq;

namespace SysQ.Microgestion.Frontend.Controllers
{
    internal class RolesFormController : ControllerBase<RolesForm>
    {
        public RolesFormController(RolesForm form)
            : base(form) { }

        internal BindingList<Role> Roles { get; set; }

        internal override void InitializeForm()
        {
            try
            {
                Roles = new BindingList<Role>(RoleService.GetAll());

                object[] items = (from a in EnumerationExtensions.GetSystemActions()
                                  select new SystemActionListBoxItem { Action = a }).ToArray();
                Form.Actions.Items.AddRange(items);

                Form.Grid.SelectionChanged += OnGridSelectionChanged;
                Form.Actions.ItemCheck += OnActionsItemCheck;

                base.InitializeForm();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        void OnActionsItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if ((e.CurrentValue == e.NewValue) ||
            (Form.Grid.SelectedRows.Count != 1))
                    return;

                Role role = Form.Grid.SelectedRows[0].DataBoundItem as Role;
                SystemAction action = ((SystemActionListBoxItem)Form.Actions.Items[e.Index]).Action;

                if (e.NewValue == CheckState.Checked)
                {
                    role.AddAction(action);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    role.RemoveAction(action);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        void OnGridSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Form.Grid.SelectedRows.Count != 1)
                    return;

                Role role = Form.Grid.SelectedRows[0].DataBoundItem as Role;
                for (int i = 0; i < Form.Actions.Items.Count; i++)
                {
                    var item = ((SystemActionListBoxItem)Form.Actions.Items[i]);
                    Form.Actions.SetItemChecked(
                        Form.Actions.Items.IndexOf(item),
                        role.Actions.Any(a => a.Action.Equals(item.Action)));
                }

            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        public bool AllowAdd { get { return UserService.CanPerform(SystemAction.RoleAdd); } set { } }
        public bool AllowDelete { get { return UserService.CanPerform(SystemAction.RoleDelete); } set { } }
        public bool AllowEdit
        {
            get
            {
                return (UserService.CanPerform(SystemAction.RoleEdit) ||
                        UserService.CanPerform(SystemAction.RoleAdd));
            }
            set { }
        }

        internal void AddNew()
        {
            try
            {
                Role newRole = new Role();

                RoleEditor editor = new RoleEditor(newRole);

                var result = editor.ShowDialog();
                if (result == DialogResult.Cancel)
                    return;

                RoleService.Save(newRole);
                Roles.Add(newRole);
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
                    "¿Desea eliminar el perfil seleccionado?",
                    "Eliminar perfil"))
                {
                    Role role = Form.Grid.SelectedRows[0].DataBoundItem as Role;
                    RoleService.Delete(role);
                    Roles.Remove(role);
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

                Role role = Form.Grid.SelectedRows[0].DataBoundItem as Role;

                string roleName = role.Name;

                RoleEditor editor = new RoleEditor(role);

                var result = editor.ShowDialog(Form);
                if (result == DialogResult.Cancel)
                {
                    role.Name = roleName;
                }
                else
                {
                    RoleService.Update(role);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        internal void SelectAllActions(bool checkedState)
        {
            for (int i = 0; i < Form.Actions.Items.Count; i++)
                Form.Actions.SetItemChecked(i, checkedState);
        }
    }

    internal class SystemActionListBoxItem
    {
        public SystemAction Action { get; set; }

        public override string ToString()
        {
            return this.Action.GetDescription();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;
using System.ComponentModel;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Enumerations;
using Blackspot.Microgestion.Backend.Extensions;
using System.Windows.Forms;
using System.Data.Linq;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class RolesFormController : ControllerBase<RolesForm>
    {
        public RolesFormController(RolesForm form)
            : base(form) { }

        internal BindingList<Role> Roles { get; set; }

        internal override void InitializeForm()
        {
            Roles = new BindingList<Role>(RoleService.GetAll());

            object[] items = (from a in EnumerationExtensions.GetSystemActions()
                              select new SystemActionListBoxItem { Action = a }).ToArray();
            Form.Actions.Items.AddRange(items);

            Form.Grid.SelectionChanged += OnGridSelectionChanged;
            Form.Actions.ItemCheck += OnActionsItemCheck;

            base.InitializeForm();

        }

        void OnActionsItemCheck(object sender, ItemCheckEventArgs e)
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

        void OnGridSelectionChanged(object sender, EventArgs e)
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
            Role newRole = new Role();

            RoleEditor editor = new RoleEditor(newRole);

            var result = editor.ShowDialog();
            if (result == DialogResult.Cancel)
                return;

            Roles.Add(newRole);
            Form.Grid.CurrentCell = Form.Grid.Rows[Form.Grid.Rows.Count - 1].Cells[1];
            RoleService.Save(newRole);
        }

        internal void Delete()
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

        internal void Edit()
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

        //internal void SaveActions()
        //{
        //    IEnumerable<SystemAction> checkedActions =
        //        Form.Actions.CheckedItems
        //        .Cast<SystemActionListBoxItem>()
        //        .Select(item => item.Action)
        //        .ToList();

        //    //Actions to remove
        //    IEnumerable<RoleAction> actionsToRemove =
        //        role.Actions
        //        .Where(ra => !checkedActions.Any(i => i.Equals(ra.Action)))
        //        .ToList();

        //    //Actions to add
        //    IEnumerable<RoleAction> actionsToAdd =
        //        checkedActions
        //        .Where(a => !role.Actions.Any(ra => ra.Action.Equals(a)))
        //        .Select(a => new RoleAction { Action = a, RoleID = role.ID })
        //        .ToList();

        //    RoleActionService.DeleteAll(actionsToRemove);
        //    RoleActionService.SaveAll(actionsToAdd);

        //    RoleService.Refresh(role, RefreshMode.OverwriteCurrentValues);

        //}
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

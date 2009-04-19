using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Backend.Enumerations;

namespace SysQ.Microgestion.Frontend.Extensions
{
    public static class MenuOptionExtensions
    {
        public static List<ToolStripMenuItem> CreateMenuItems(this IEnumerable<MenuOption> options)
        {
            User user = UserService.LoggedInUser;

            var items = 
                (
                    from opt in options
                    where UserService.CanPerform(user, opt.Action)
                    select opt.CreateMenuItem()
                ).ToList();

            return items;
        }

        public static ToolStripMenuItem CreateMenuItem(this MenuOption option)
        {
            User user = UserService.LoggedInUser;

            ToolStripMenuItem item = new ToolStripMenuItem { Text = option.Text, Tag = option.Action };

            if (option.Order == -1)
            {
                item.Visible = false;

                if (option.Action == SystemAction.ResetDB)
                    item.ShortcutKeys = Keys.Control | Keys.Alt | Keys.Shift | Keys.R;
            }

            if (option.Action != SystemAction.Null)
            {
                item.Click += (s, e) => MenuDispatcher.Dispatch((ToolStripMenuItem)s);
            }

            item.DropDownItems.AddRange
            (
                (from opt in option.Childs
                where UserService.CanPerform(user, opt.Action)
                orderby opt.Order ascending
                select opt.CreateMenuItem()).ToArray()
            );

            return item;
        }

    }
}

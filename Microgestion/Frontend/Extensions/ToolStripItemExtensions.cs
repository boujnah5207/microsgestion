using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SysQ.Microgestion.Backend.Enumerations;

namespace SysQ.Microgestion.Frontend.Extensions
{
    public static class ToolStripItemExtensions
    {
        public static void RemoveEmptyItems(this List<ToolStripMenuItem> items)
        {
            List<ToolStripMenuItem> itemsToRemove = new List<ToolStripMenuItem>();
            foreach (var item in items)
            {
                SystemAction action = (SystemAction)item.Tag;

                if (action == SystemAction.Null && !item.HasDropDownItems)
                    itemsToRemove.Add(item);

                item.DropDownItems.RemoveEmptyItems();
            }

            items.RemoveAll(i => itemsToRemove.Contains(i));
        }

        public static void RemoveEmptyItems(this ToolStripItemCollection items)
        {
            List<ToolStripMenuItem> itemsToRemove = new List<ToolStripMenuItem>();
            foreach (var item in items)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)item;
                SystemAction action = (SystemAction)menuItem.Tag;

                if (action == SystemAction.Null && !menuItem.HasDropDownItems)
                    itemsToRemove.Add(menuItem);
            }

            foreach (var item in itemsToRemove)
                items.Remove(item);
        }
    }
}

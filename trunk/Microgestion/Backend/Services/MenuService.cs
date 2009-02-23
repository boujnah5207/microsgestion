using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Enumerations;

namespace Blackspot.Microgestion.Backend.Services
{
    public class MenuService : ServiceBase<MenuOption>
    {

        internal static void CreateMenu()
        {
            List<MenuOption> options = new List<MenuOption>();

            // Archivo
            options.Add(new MenuOption
            {
                ID = Guid.NewGuid(), Action = SystemAction.Null, Text = "&Archivo", Order = 1,
                Childs = 
                {
                    new MenuOption {ID = Guid.NewGuid(), Action = SystemAction.Exit, Text = "&Salir", Order = 1 }
                }
            });

            // Administration
            options.Add(new MenuOption
            {
                ID = Guid.NewGuid(), Action = SystemAction.Null, Text = "A&dministración", Order = 2,
                Childs =
                {
                    new MenuOption { ID = Guid.NewGuid(), Action = SystemAction.ResetDB, Text = "&Resest DB", Order = 1 },
                    new MenuOption { ID = Guid.NewGuid(), Action = SystemAction.UsersAdmin, Text = "&Usuarios", Order = 2 },
                    new MenuOption { ID = Guid.NewGuid(), Action = SystemAction.RolesAdmin, Text = "&Perfiles", Order = 3 }
                }
            });

            SaveAll(options);
        }

        public static List<MenuOption> GetRoots()
        {
            return (from m in DB.MenuOptions
                    where m.Parent == null
                    orderby m.Order ascending
                    select m).ToList();
        }

    }
}

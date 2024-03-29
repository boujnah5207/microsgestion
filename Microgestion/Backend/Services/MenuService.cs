﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Backend.Enumerations;

namespace SysQ.Microgestion.Backend.Services
{
    //public class MenuService : ServiceBase<MenuOption>
    public class MenuService
    {

        public static List<MenuOption> GetMenuOptions()
        {
            List<MenuOption> options = new List<MenuOption>();

            // Archivo
            options.Add(new MenuOption
            {
                ID = Guid.NewGuid(), Action = SystemAction.Null, Text = "&Archivo", Order = 1,
                Childs = 
                {
                    new MenuOption {ID = Guid.NewGuid(), Action = SystemAction.LogInOut, Text = SystemAction.LogInOut.GetDescription(), Order = 1 },
                    new MenuOption {ID = Guid.NewGuid(), Action = SystemAction.Exit, Text = "&Salir", Order = 1 }
                }
            });

            // Administration
            options.Add(new MenuOption
            {
                ID = Guid.NewGuid(), Action = SystemAction.Null, Text = "A&dministración", Order = 2,
                Childs =
                {
                    new MenuOption { ID = Guid.NewGuid(), Action = SystemAction.ResetDB, Text = "&Resest DB", Order = -1 },
                    new MenuOption { ID = Guid.NewGuid(), Action = SystemAction.UsersAdmin, Text = "&Usuarios", Order = 2 },
                    new MenuOption { ID = Guid.NewGuid(), Action = SystemAction.RolesAdmin, Text = "&Perfiles", Order = 3 },
                    new MenuOption { ID = Guid.NewGuid(), Action = SystemAction.MeasurementsAdmin, Text = "U&nidades de Medida", Order = 4 },
                    new MenuOption { ID = Guid.NewGuid(), Action = SystemAction.ItemTypesAdmin, Text = "&Rubros", Order = 5 },
                    new MenuOption { ID = Guid.NewGuid(), Action = SystemAction.ItemsAdmin, Text = "&Artículos", Order = 6 }
                }
            });

            return options;
        }

    }
}

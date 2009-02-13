using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Enumerations;

namespace Blackspot.Microgestion.Backend.Services
{
    public class MenuService : ServiceBase
    {

        static Guid menuFile = Guid.NewGuid();
        static Guid menuExit = Guid.NewGuid();
        static Guid menuResetDB = Guid.NewGuid();

        internal static void CreateMenu()
        {
            List<MenuOption> options = new List<MenuOption>();

            options.Add(new MenuOption
            {
                ID = menuFile, Action = SystemAction.Null, Text = "&Archivo", 
                Childs = 
                {
                    new MenuOption {ID = menuExit, Action = SystemAction.Exit, ParentID = menuFile, Text = "&Salir" }
                }
            });

            options.Add(new MenuOption
            {
                ID = menuResetDB,
                Action = SystemAction.ResetDB,
                Text = "&Resest DB"
            });

            SaveAll(options);
        }

        public static List<MenuOption> GetRoots()
        {
            return DB.MenuOptions
                     .Where(m => m.Parent == null)
                     .ToList();
        }

    }
}

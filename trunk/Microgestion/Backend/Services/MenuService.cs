using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Backend.Services
{
    public class MenuService : ServiceBase
    {

        private const Guid menuFileID = Guid.NewGuid();

        internal static void CreateMenu()
        {
            List<MenuOption> options = new List<MenuOption>()
            {
                new MenuOption { ID = menuFileID }
            };

            SaveAll(options);
        }
    }
}

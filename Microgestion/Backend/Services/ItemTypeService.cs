using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Entities;

namespace SysQ.Microgestion.Backend.Services
{
    public class ItemTypeService : ServiceBase<ItemType>
    {
        private ItemTypeService() { }

        public static ItemType GetByName(string itemTypeName)
        {
            var itemType = from i in DB.ItemTypes
                           where i.Name == itemTypeName
                           select i;

            return itemType.SingleOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Extensions;

namespace Blackspot.Microgestion.Backend.Services
{
    public class ItemService : ServiceBase<Item>
    {
        private ItemService() { }

        public static IList<Item> SearchItems(string text, int maxResults)
        {
            return DB.Items
                .FindElementByRelevance(text)
                .Take(maxResults)
                .ToList();
        }
    }
}

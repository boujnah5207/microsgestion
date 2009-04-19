using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Backend.Extensions;

namespace SysQ.Microgestion.Backend.Services
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

        public static IList<ItemRecord> SearchItemRecords(Guid itemTypeFilter, Guid itemFilter)
        {
            var query = from s in DB.StockMovementDetails
                        where (s.ID == itemFilter || itemFilter == Guid.Empty) &&
                              (s.Item.ItemTypeID == itemTypeFilter || itemTypeFilter == Guid.Empty)
                        group s by s.ItemID into g
                        orderby g.Key
                        select new ItemRecord
                        {
                            Item = g.First().Item.Name,
                            ItemType = g.First().Item.ItemType.Name,
                            MinimumStock = g.First().Item.MinimumStock,
                            ActualStock = g.Sum(s => s.Amount)
                        };

            return query.ToList();
        }
    }

    public class ItemRecord
    {
        public string Item { get; set; }
        public string ItemType { get; set; }
        public double MinimumStock { get; set; }
        public double ActualStock { get; set; }
        public double MissingStock
        {
            get
            {
                if (ActualStock < MinimumStock)
                    return (MinimumStock - ActualStock);

                return 0;
            }
        }
    }
}

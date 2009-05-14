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
        public static IEnumerable<ItemRecord> SearchItemRecords(string keyword)
        {
            var items = DB.Items
                          .FindElementByRelevance(keyword)
                          .Select(i => new ItemRecord
                          {
                              ItemId = i.ID,
                              Item = i.Name,
                              ItemType = i.ItemType.Name,
                              MinimumStock = i.MinimumStock,
                              InternalCode = i.InternalCode,
                              ExternalCode = i.ExternalCode,
                              Price = i.CurrentPrice.Value
                          });

            return items.ToList();
        }

        public static IList<ItemRecord> SearchItemRecords(Guid itemTypeFilter, Guid itemFilter, bool onlyMissingStock)
        {
            var query = from i in DB.Items
                        from s in i.StockMovementDetails
                        where (i.ID == itemFilter || itemFilter == Guid.Empty) &&
                              (i.ItemTypeID == itemTypeFilter || itemTypeFilter == Guid.Empty)
                        group s by s.ItemID into g
                        orderby g.Key
                        select new
                        {
                            ItemID = g.Key,
                            ActualStock = g.Sum(s => s.Amount)
                        };

            var records = from e in query
                          from i in DB.Items
                          where e.ItemID == i.ID
                          select new ItemRecord
                          {
                              Item = i.Name,
                              ItemType = i.ItemType.Name,
                              MinimumStock = i.MinimumStock,
                              InternalCode = i.InternalCode,
                              ExternalCode = i.ExternalCode,
                              Price = i.CurrentPrice.Value,
                              ActualStock = e.ActualStock
                          };

            IList<ItemRecord> allRecords = records.ToList();

            if (onlyMissingStock)
                return allRecords.Where(i => i.MissingStock > 0 || !onlyMissingStock).ToList();

            return allRecords;
        }

        public static IList<Item> GetAll(bool includeItemsWithoutStock)
        {
            var items = from i in DB.Items
                        where (i.MovesStock || includeItemsWithoutStock)
                        orderby i.Name
                        select i;

            return items.ToList();
        }

        public static Item GetByName(string name)
        {
            var item = from i in DB.Items
                       where i.Name == name
                       select i;

            return item.SingleOrDefault();
        }
    }

    public class ItemRecord
    {
        public Guid ItemId { get; set; } 
        public string Item { get; set; }
        public string ItemType { get; set; }
        public string InternalCode { get; set; }
        public string ExternalCode { get; set; }
        public double Price { get; set; }
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

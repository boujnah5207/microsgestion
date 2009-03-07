using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Extensions;

namespace Blackspot.Microgestion.Backend.Entities
{
    partial class Item : IPersistible, ISearchable
    {
        #region IPersistible Members


        public bool IsValid()
        {
            return
                this.BaseMeasurement != null &&
                this.Name != null;
        }

        #endregion

        public Price CurrentPrice
        {
            get
            {
                var price = (from p in this.Prices
                             orderby p.Date descending
                             select p).FirstOrDefault();
                return price;
            }
            set
            {
                var unsavedPrices = this.Prices.Where(p => p.ID == Guid.Empty).ToArray();
                foreach (var p in unsavedPrices)
                    this.Prices.Remove(p);

                value.Item = this;
                this.Prices.Add(value);

                PropertyChanged(this, new PropertyChangedEventArgs("CurrentPrice"));
            }
        }


        public string SearchString
        {
            get { return this.InternalCode + "|" + this.ExternalCode + "|" + this.Name; }
        }

    }
}

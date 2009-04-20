using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Backend.Extensions;

namespace SysQ.Microgestion.Backend.Entities
{
    partial class Item : IPersistible, ISearchable
    {
        #region IPersistible Members


        public bool IsValid()
        {
            return
                this.BaseMeasurementID != null &&
                this.ItemTypeID != null &&
                this.CurrentPrice != null &&
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

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentPrice"));
            }
        }


        public string SearchString
        {
            get { return this.InternalCode + "|" + this.ExternalCode + "|" + this.Name; }
        }

        public override string ToString()
        {
            return this.Name;
        }

    }
}

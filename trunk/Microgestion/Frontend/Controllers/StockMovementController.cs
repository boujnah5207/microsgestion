using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;
using System.ComponentModel;
using Blackspot.Microgestion.Frontend.Forms;
using Blackspot.Microgestion.Backend.Services;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class StockMovementController : ControllerBase<StockMovementForm>
    {
        private StockMovementController() { }

        public StockMovementController(StockMovementForm form)
            : base(form)
        {
            this.Date = DateTime.Now;
            this.Comments = string.Empty;

            this.Items = new BindingList<Item>(ServiceBase<Item>.GetAll());
        }


        public DateTime Date { get; set; }
        public String Comments { get; set; }

        public BindingList<StockMovementDetail> Details { get; set; }
        public BindingList<Item> Items { get; set; }
    }
}

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

            Details = new BindingList<StockMovementDetail>(new List<StockMovementDetail>());
            ResetAll();
        }

        private void ResetAll()
        {
            this.Comments = String.Empty;
            this.Date = DateTime.Now;
            this.Items = new BindingList<Item>(ServiceBase<Item>.GetAll());
            Form.Grid.Rows.Clear();
        }

        public DateTime Date { get; set; }
        public String Comments { get; set; }

        public BindingList<StockMovementDetail> Details { get; set; }
        public BindingList<Item> Items { get; set; }

        internal void CloseButtonPressed()
        {
            ResetAll();
        }
        internal void SaveButtonPressed()
        {
            StockMovement mov = new StockMovement
            {
                UserID = UserService.LoggedInUser.ID,
                Date = this.Date,
                Comment = this.Comments
            };

            mov.Details.AddRange(Details);

            StockMovementService.Save(mov);

            ResetAll();
        }
    }
}

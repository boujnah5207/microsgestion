using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Frontend.Extensions;

namespace Blackspot.Microgestion.Frontend.Forms
{
    public partial class LookupForm<T> : Form
        where T : class, IPersistible
    {
        public LookupForm()
        {
            InitializeComponent();

            this.Filter = new List<T>();

            this.Load += (s, e) =>
            {
                try
                {
                    this.lstItems.DataSource =
                        ServiceBase<T>
                        .GetAll()
                        .Where(i => !Filter.Contains(i))
                        .ToList();

                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox();
                }
            };
        }

        public T SelectedItem
        {
            get 
            { 
                return lstItems.SelectedItem as T;
            }
        }

        public IEnumerable<T> Filter { private get;  set; }
    }
}

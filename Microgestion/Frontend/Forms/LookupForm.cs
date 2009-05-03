using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Frontend.Extensions;

namespace SysQ.Microgestion.Frontend.Forms
{
    public partial class LookupForm<T> : Form
        where T : class, IPersistible
    {
        public LookupForm()
        {
            InitializeComponent();

            //this.Filter = new List<T>();

            //this.Load += (s, e) =>
            //{
            //    try
            //    {
            //        this.lstItems.DataSource =
            //            ServiceBase<T>
            //            .GetAll()
            //            .Where(i => !Filter.Contains(i))
            //            .ToList();

            //    }
            //    catch (Exception ex)
            //    {
            //        ex.ShowMessageBox();
            //    }
            //};
        }

        public T SelectedItem
        {
            get 
            { 
                return lstItems.SelectedItem as T;
            }
        }

        public object DataSource
        {
            get
            {
                return this.lstItems.DataSource;
            }
            set
            {
                this.lstItems.DataSource = value;
            }
        }

        //public IEnumerable<T> Filter { private get;  set; }
    }
}

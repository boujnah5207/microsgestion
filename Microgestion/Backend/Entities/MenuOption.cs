using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Enumerations;

namespace Blackspot.Microgestion.Backend.Entities
{
    public class MenuOption
    {
        private List<MenuOption> childs = new List<MenuOption>();

        public Guid ID { get; set; }
        public SystemAction Action { get; set; }
        public List<MenuOption> Childs 
        {
            get { return this.childs; }
        }
        public String Text { get; set; }
        public Int32 Order { get; set; }
    }
}

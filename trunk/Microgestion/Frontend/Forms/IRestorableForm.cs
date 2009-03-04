using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackspot.Microgestion.Frontend.Forms
{
    internal interface IRestorableForm
    {
        string LocationSetting { get; }
        string SizeSetting { get; }
        string WindowStateSetting { get; }
    }
}

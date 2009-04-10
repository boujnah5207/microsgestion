using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysQ.Microgestion.Frontend.Forms
{
    public interface IRestorableForm
    {
        string LocationSetting { get; }
        string SizeSetting { get; }
        string WindowStateSetting { get; }
    }
}

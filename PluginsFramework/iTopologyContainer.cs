using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FickleStripper.PluginsFramework
{
    public interface iTopologyContainer
    {
        event EventHandler Changed;

        void AddLightString(uint output, uint ledCount);

        Dictionary<uint, uint> LightStrings
        {
            get;
        }

        void ClearAll();

        bool PauseUpdate
        {
            set;
        }
    }
}

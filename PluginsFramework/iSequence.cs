using System.Windows.Forms;
using System;

namespace FickleStripper.PluginsFramework
{
    public interface iSequence
    {
        void Configure(Panel panel, PluginsFramework.iTopologyContainer topology);

        string SequenceName
        {
            get;
        }
    }
}

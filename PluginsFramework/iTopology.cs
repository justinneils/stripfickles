using System.Windows.Forms;
using System.Drawing;

namespace FickleStripper.PluginsFramework
{
    public interface iTopology
    {
        Size Configure(Panel panel, iTopologyContainer container);

        string TopologyName
        {
            get;
        }
    }
}

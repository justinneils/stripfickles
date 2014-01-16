using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FickleStripper
{
    public partial class TopologyForm : Form
    {
        private PluginsFramework.iTopology topologyObject = null;
        private PluginsFramework.iTopologyContainer topologyContainer = null;

        public TopologyForm(PluginsFramework.iTopologyContainer topologyContainer)
        {
            InitializeComponent();

            this.topologyContainer = topologyContainer;

            this.DoubleBuffered = true;
        }

        public PluginsFramework.iTopology Topology
        {
            get
            {
                return this.topologyObject;
            }

            set
            {
                if (null == this.topologyObject || value.TopologyName != this.topologyObject.TopologyName)
                {
                    this.topologyObject = value;
                    this.pnlMain.Controls.Clear();
                    this.MinimumSize = this.topologyObject.Configure(this.pnlMain, this.topologyContainer);
                }
            }
        }
    }
}

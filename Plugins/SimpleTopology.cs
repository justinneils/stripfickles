using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FickleStripper.Plugins
{
    class SimpleTopology : PluginsFramework.iTopology
    {
        private PluginsFramework.iTopologyContainer container = null;
        private TextBox entries = null;
        private Panel panel = null;

        public SimpleTopology()
        {
            this.panel = new Panel();
            this.panel.Dock = DockStyle.Fill;

            this.entries = new TextBox();
            this.entries.Multiline = true;
            this.entries.Dock = DockStyle.Fill;
            this.entries.Font = new Font(FontFamily.GenericMonospace, 16);
            this.panel.Controls.Add(this.entries);
            this.entries.Text = "0,20" + Environment.NewLine + "1,25";

            Button button = new Button();
            button.Dock = DockStyle.Bottom;
            button.Text = "Parse";
            button.Click += OnClick;
            button.AutoSize = true;
            panel.Controls.Add(button);
        }

        public Size Configure(Panel panel, PluginsFramework.iTopologyContainer container)
        {
            this.container = container;

            panel.Controls.Add(this.panel);
            return new System.Drawing.Size(200, 200);
        }

        void OnClick(object sender, EventArgs e)
        {
            this.container.ClearAll();

            foreach (var line in this.entries.Lines)
            {
                var tokens = line.Split(new char[] { ',' });
                if (tokens.Length == 2)
                {
                    try
                    {
                        this.container.AddLightString(Convert.ToUInt32(tokens[0]), Convert.ToUInt32(tokens[1]));
                    }
                    catch (FormatException)
                    {
                    }
                }
            }
        }

        public string TopologyName
        {
            get { return "Simple"; }
        }
    }
}

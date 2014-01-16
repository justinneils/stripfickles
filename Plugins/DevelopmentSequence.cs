using System.Windows.Forms;
using System;
using FickleStripper;
using System.Drawing;

namespace FickleStripper.Plugins
{
    class DevelopmentSequence : PluginsFramework.iSequence
    {
        private ComboBox output = new ComboBox();
        private ComboBox start = new ComboBox();
        private ComboBox end = new ComboBox();
        private PluginsFramework.iTopologyContainer topology;

        private void UpdateItems()
        {
            foreach (var item in this.topology.LightStrings)
            {
                if (!this.output.Items.Contains(item.Key.ToString()))
                {
                    Console.WriteLine("output:" + item.Key.ToString() + " ledCount:" + item.Value.ToString());

                    this.output.Items.Add(item.Key.ToString());
                }
            }
        }

        public DevelopmentSequence()
        {
            this.output.Margin = new Padding(0, 3, 0, 3);
            this.start.Margin = new Padding(0, 3, 0, 3);
            this.end.Margin = new Padding(0, 3, 0, 3);
            Console.WriteLine("DevSequence constructed");
        }

        public string SequenceName
        {
            get { return "DevSequence"; }
        }

        public void Configure(Panel panel, PluginsFramework.iTopologyContainer topology)
        {
            //panel.SuspendLayout();

            //var layout = new TableLayoutPanel();
            //layout.SuspendLayout();
            //layout.ColumnCount = 6;
            //layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));  // select output
            //layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));  // dropdown
            //layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));  // led range
            //layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));  // dropdown
            //layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));  // to
            //layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));  // dropdown
            //layout.RowCount = 1;
            //layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            //panel.Controls.Add(layout);
            //layout.Dock = DockStyle.Fill;

            //var outputLabel = new Label();
            //layout.Controls.Add(outputLabel, 0, 0);
            //outputLabel.Margin = new Padding(0, 3, 0, 3);
            //outputLabel.Text = "Select output:";
            //outputLabel.AutoSize = true;
            //outputLabel.TextAlign = ContentAlignment.MiddleRight;
            //outputLabel.BorderStyle = BorderStyle.FixedSingle;

            //layout.Controls.Add(this.output, 1, 0);

            //var startLabel = new Label();
            //layout.Controls.Add(startLabel, 2, 0);
            //startLabel.Margin = new Padding(20, 3, 0, 3);
            //startLabel.Text = "LED Range";
            //startLabel.AutoSize = true;
            //startLabel.TextAlign = ContentAlignment.MiddleRight;
            //startLabel.BorderStyle = BorderStyle.FixedSingle;

            //layout.ResumeLayout(true);
            //panel.ResumeLayout(true);

            this.topology = topology;
            this.UpdateItems();
            this.topology.Changed += OnTopologyChange;
        }

        public void OnTopologyChange(object sender, EventArgs e)
        {
            this.UpdateItems();
        }
    }
}

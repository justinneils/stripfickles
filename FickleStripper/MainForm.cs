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
    public partial class MainForm : Form
    {
        private List<SequenceDefinition> sequences = new List<SequenceDefinition>();
        
        private TopologyForm topologyForm;
        private TopologyContainer topologyContainer;

        public MainForm()
        {
            this.topologyContainer = new TopologyContainer();
            this.topologyForm = new TopologyForm(this.topologyContainer);

            InitializeComponent();

            // find all object that inherit from iSequence to get all the available sequences
            foreach (Type type in AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(PluginsFramework.iSequence).IsAssignableFrom(p) && p.IsClass))
            {
                var newSequence = new SequenceDefinition(type, this.tcMain, this.topologyContainer);
                this.sequences.Add(newSequence);

                this.addSequenceToolStripMenuItem.DropDownItems.Add(newSequence.Menu);
            }

            // find all objects that inherit from iTopology to get all the available topologies
            foreach (Type type in AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(PluginsFramework.iTopology).IsAssignableFrom(p) && p.IsClass))
            {
                var newTopology = new TopologyDefinition(type, this.topologyForm);
                this.topologyToolStripMenuItem.DropDownItems.Add(newTopology.Menu);
            }

            this.DoubleBuffered = true;
            this.topologyForm.Show();
            this.BringToFront();
        }

        protected override void OnResize(EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                    this.topologyForm.Show();
                    this.BringToFront();
                    break;
                case FormWindowState.Minimized:
                    this.topologyForm.Owner = this;
                    this.topologyForm.Hide();
                    break;
            }

            base.OnResize(e);
        }

        protected override void OnActivated(EventArgs e)
        {
            this.topologyForm.Owner = null;
            this.BringToFront();
            base.OnActivated(e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.topologyForm.Owner = this;
        }
    }

    internal class TopologyDefinition
    {
        private PluginsFramework.iTopology topology;
        private ToolStripMenuItem menu;
        private TopologyForm form;

        public ToolStripMenuItem Menu
        {
            get
            {
                return this.menu;
            }
        }

        public TopologyDefinition(Type type, TopologyForm form)
        {
            this.topology = (PluginsFramework.iTopology)Activator.CreateInstance(type);

            this.menu = new ToolStripMenuItem(this.topology.TopologyName);
            this.menu.Click += new EventHandler(this.OnMenuClick);

            this.form = form;
        }

        private void OnMenuClick(object sender, EventArgs e)
        {
            this.form.Topology = this.topology;
        }
    }

    internal class SequenceDefinition
    {
        private Type sequenceType;
        private ToolStripMenuItem menu;
        private TabControl control;
        private TopologyContainer topologyContainer;
        private List<SequenceObject> attachedSequences;

        public ToolStripMenuItem Menu
        {
            get
            {
                return this.menu;
            }
        }

        public SequenceDefinition(Type type, TabControl control, TopologyContainer container)
        {
            this.sequenceType = type;

            this.menu = new ToolStripMenuItem(this.sequenceType.Name);
            this.menu.Click += new EventHandler(this.OnMenuClick);

            this.control = control;
            this.topologyContainer = container;
            this.attachedSequences = new List<SequenceObject>();
        }

        private void OnMenuClick(object sender, EventArgs e)
        {
            var sequence = (PluginsFramework.iSequence)Activator.CreateInstance(this.sequenceType);

            var page = new TabPage();
            this.control.TabPages.Add(page);
            page.Text = this.control.TabPages.Count.ToString() + " : " + sequence.SequenceName;
            page.UseVisualStyleBackColor = true;

            this.attachedSequences.Add(new SequenceObject(
                page,
                sequence,
                this.topologyContainer));
        }
    }

    internal class SequenceObject
    {
        private TabPage page;
        private PluginsFramework.iSequence sequence;
        private PluginsFramework.iTopologyContainer container;
        private ComboBox outputList = new ComboBox()
        {
            Width = 40,
            DropDownStyle = ComboBoxStyle.DropDownList,
        };
        private ComboBox start = new ComboBox()
        {
            Width = 40,
            DropDownStyle = ComboBoxStyle.DropDownList,
        };
        private ComboBox end = new ComboBox()
        {
            Width = 40,
            DropDownStyle = ComboBoxStyle.DropDownList,
        };

        public SequenceObject(TabPage page, PluginsFramework.iSequence sequence, PluginsFramework.iTopologyContainer container)
        {
            this.page = page;
            this.sequence = sequence;
            this.container = container;
            this.container.Changed += OnTopologyChange;
            this.outputList.TextChanged += OnOutputChange;

            var pageTable = new TableLayoutPanel();
            page.Controls.Add(pageTable);
            pageTable.Dock = DockStyle.Fill;
            pageTable.Margin = new Padding(0);

            pageTable.Controls.Add(new Label()
            {
                Text = "Output #",
                TextAlign = ContentAlignment.MiddleRight,
                //BorderStyle = BorderStyle.FixedSingle,
            }, 0, 0);
            pageTable.Controls.Add(this.outputList, 1, 0);
            pageTable.Controls.Add(new Label()
            {
                Text = "From",
                TextAlign = ContentAlignment.MiddleRight,
                //BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(30, 0, 0, 0),
            }, 2, 0);
            pageTable.Controls.Add(this.start, 3, 0);
            pageTable.Controls.Add(new Label()
            {
                Text = "to",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 30,
                //BorderStyle = BorderStyle.FixedSingle,
            }, 4, 0);
            pageTable.Controls.Add(this.end, 5, 0);

            this.UpdateItems();

            var sequencePanel = new Panel();
            pageTable.Controls.Add(sequencePanel, 0, 1);
            pageTable.SetColumnSpan(sequencePanel, 10);

            sequencePanel.BorderStyle = BorderStyle.FixedSingle;
            sequencePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sequencePanel.Margin = new Padding(0);

            sequence.Configure(sequencePanel, this.container);
        }

        private void OnOutputChange(object sender, EventArgs e)
        {
            int currentOutput = Convert.ToInt32(((ComboBox)sender).Text);
            foreach (var item in this.container.LightStrings)
            {
                if (item.Key == currentOutput)
                {
                    this.start.Items.Clear();
                    this.end.Items.Clear();
                    for (uint count = 1; count <= item.Value; ++count)
                    {
                        this.start.Items.Add(count);
                        this.end.Items.Add(count);
                    }
                    this.start.SelectedIndex = 0;
                    this.end.SelectedIndex = 0;
                }
            }
        }

        private void UpdateItems()
        {
            this.outputList.Items.Clear();
            foreach (var item in this.container.LightStrings)
            {
                this.outputList.Items.Add(item.Key.ToString());
            }
            this.outputList.SelectedIndex = 0;
        }

        private void OnTopologyChange(object sender, EventArgs e)
        {
            this.UpdateItems();
        }
    }
}

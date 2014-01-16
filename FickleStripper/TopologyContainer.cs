using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FickleStripper
{
    class TopologyContainer : PluginsFramework.iTopologyContainer
    {
        private Dictionary<uint, uint> lightStrings = null;

        private bool paused = false;
        private bool eventSent = true;

        public event EventHandler Changed;

        public TopologyContainer()
        {
            this.lightStrings = new Dictionary<uint, uint>();
        }

        public void AddLightString(uint output, uint ledCount)
        {
            this.lightStrings[output] = ledCount;
            this.eventSent = false;

            if (!this.paused && this.Changed != null)
            {
                this.eventSent = true;
                this.Changed(this, EventArgs.Empty);
            }
        }

        public Dictionary<uint, uint> LightStrings
        {
            get
            {
                return new Dictionary<uint, uint>(this.lightStrings);
            }
        }

        public void ClearAll()
        {
            this.lightStrings.Clear();
            this.eventSent = false;

            if (!this.paused && this.Changed != null)
            {
                this.eventSent = true;
                Changed(this, EventArgs.Empty);
            }
        }

        public bool PauseUpdate
        {
            set
            {
                this.paused = value;
                if (!this.eventSent)
                {
                    this.eventSent = true;
                    Changed(this, EventArgs.Empty);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Styx;
using Styx.Plugins;
using Styx.Common;
using Styx.WoWInternals;

using System.Windows.Media;

namespace ZapRecorder2
{
    public class ZapPlugin : HBPlugin
    {
        public override string Author { get { return "BadWolf (originally by Zapman)"; } }
        public override Version Version { get { return new Version(1, 2, 2); } }
        public static string SubVersion { get { return "$Revision$"; } }
        public override string Name { get { return "ZapRecorder2"; } }
        public override bool WantButton { get { return true; } }
        public override string ButtonText { get { return "Show Recorder"; } }

        public bool hasBeenInitialized = false;
        public bool mainFormLoaded = false;
        public ZapMainForm mainForm;
        public static bool isHidden = false;


        public override void Initialize()
        {
            Logging.Write(Colors.Teal, "Loaded ZapRecorder2 by BadWolf v" + Version.ToString());
            Logging.Write(Colors.CornflowerBlue, "Attached hotkey to ZapRecorder2");
       } 

        public override void Pulse()
        {

        }


        public override void Dispose()
        {
            base.Dispose();
        }

        public override void OnButtonPress()
        {
            if (!ZapPlugin.isHidden)
            {
                // First time button press, create form.
                if (!mainFormLoaded)
                {
                    //We need to create a new form
                    mainForm = new ZapMainForm();
                    mainForm.Show();
                    mainFormLoaded = true;

                    
                }
            }
            else
            {
                // Reload existing form
                mainForm.Show();
            }
        }
    }
}

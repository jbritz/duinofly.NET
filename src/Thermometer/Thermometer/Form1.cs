using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Juliet;

namespace Thermometer
{
    public partial class Thermometer : Form
    {
        public Thermometer()
        {
            InitializeComponent();

            var listener = new CommandListener("192.168.10.74", 8001);
            listener.OnNewCommandRecieved += listener_OnNewCommandRecieved;
        }

        void listener_OnNewCommandRecieved(string command)
        {
            if (command.StartsWith("TEMP"))
            {
                string[] values = command.Split('|');
                SetControlPropertyThreadSafe(guageThermometer, "Value", (float)Convert.ToDouble(values[1]));
            }
            else if (command.StartsWith("NOISE"))
            {
                string[] values = command.Split('|');
                SetControlPropertyThreadSafe(guageNoiseLevel, "Value", (float)Convert.ToDouble(values[1]));
            }
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

    }
}

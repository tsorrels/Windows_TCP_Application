using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace WindowsFormsApplication1
{
    public class NetInfoRetriever
    {
        private static System.Windows.Forms.Timer queryTimer = null;
        private IPGlobalProperties currentProperties = null;
        private static int timerCounter = 0;
        private Form1 formReference = null;
        public List<NetworkDataEntry> dataEntries = new List<NetworkDataEntry>();

        public NetInfoRetriever()
        {
            queryTimer = new System.Windows.Forms.Timer();
            queryTimer.Interval = 2000;
        }

        private void quiryOS(Object myObject, EventArgs myEventArgs)
        {
            IPGlobalProperties newProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] activeTCPConnections = newProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation currentConnection in activeTCPConnections)
            {
                dataEntries.Add(new NetworkDataEntry(currentConnection.LocalEndPoint.Port, 
                                                 currentConnection.LocalEndPoint.Address.ToString()));

            }

            //System.Console.WriteLine(activeTCPConnections.Length.ToString());
            //formReference.updateUI(activeTCPConnections);

            //System.Windows.Forms.MessageBox.Show("Ran " + timerCounter.ToString());
        }

        public void start(Form1 formReference)
        {
            this.formReference = formReference;
            queryTimer.Tick += new EventHandler(quiryOS);
            queryTimer.Start();
        }

    }
}

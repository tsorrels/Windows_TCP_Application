using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public struct NetworkDataEntry
    {
        public int port;
        public string ipAddress;
        public string ipResolver;

        public NetworkDataEntry(int newPort, string newIPAddress)
        {
            this.port = newPort;
            this.ipAddress = newIPAddress;
            this.ipResolver = "";
        }

    }
}

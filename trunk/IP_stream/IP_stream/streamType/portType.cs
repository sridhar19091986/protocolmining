using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace IP_stream
{
    class portType : streamType
    {
        public Dictionary<string, string> dPort;
        public portType()
        {
            dPort = new Dictionary<string, string>();
            foreach (var q1 in dataConfig.Elements("TcpPortType").Elements("ports"))
                foreach (var q2 in q1.Elements("port"))
                    dPort.Add(q2.Value, q1.Attribute("name").Value);
        }
        public string ConvertPort2trType(string port)
        {
            string trtype = null;
            foreach (var k in dPort)
                if (port.IndexOf(k.Key) != -1)
                    trtype = k.Value;
            return trtype;
        }
    }
}

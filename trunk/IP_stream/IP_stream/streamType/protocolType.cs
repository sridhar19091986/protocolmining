using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace IP_stream
{
    class protocolType : streamType
    {
        public Dictionary<string, string> d;

        public protocolType()
        {
            d = new Dictionary<string, string>();
            foreach (var q1 in dataConfig.Elements("ProtocolType").Elements("Protocols"))
                foreach (var q2 in q1.Elements("Protocol"))
                    d.Add(q2.Value, q1.Attribute("name").Value);
        }
        public string ConvertProtocol2trType(string response)
        {
            string trtype = null;
            foreach (var k in d)
                if (response.IndexOf(k.Key) != -1)
                    trtype = k.Value;
            return trtype;
        }
    }
}

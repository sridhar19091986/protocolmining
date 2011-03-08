using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace IP_stream
{
    class responseType : streamType
    {
        public Dictionary<string, string> d;

        public responseType()
        {
            d = new Dictionary<string, string>();
            foreach (var q1 in dataConfig.Elements("ResponseType").Elements("Responses"))
                foreach (var q2 in q1.Elements("Response"))
                    d.Add(q2.Value, q1.Attribute("name").Value);
            //dict = XDOC
            //.Load(Application.StartupPath + "\\Test.xml")
            //.Descendants("Child")
            //.Select((x, i) => new { data = x, index = i })
            //.ToDictionary(x => x.index, x => x.data.Attribute("Value").Value);
        }
        public string ConvertResponse2trType(string response)
        {
            string trtype = null;
            foreach (var k in d)
                if (response.IndexOf(k.Key) != -1)
                    trtype = k.Value;
            return trtype;
        }
    }
}

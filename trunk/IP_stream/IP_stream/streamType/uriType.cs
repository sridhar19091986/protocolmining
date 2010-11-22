using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace IP_stream
{
    class uriType : streamType
    {
        public Dictionary<string, string> d;
        private ILookup<string, mUri> _mUriCollection;
        public ILookup<string, mUri> mUriCollection
        {
            get
            {
                if (_mUriCollection == null)
                    _mUriCollection = GetmUriCollection().ToLookup(e => e.fileNum + "-" + e.tlli + "-" + e.sport + "-" + e.dport);
                return _mUriCollection;
            }
            set
            {
                _mUriCollection = value;
            }
        }
        public uriType()
        {
            d = new Dictionary<string, string>();
            foreach (var q1 in dataConfig.Elements("HttpWspUriType").Elements("uris"))
                foreach (var q2 in q1.Elements("url"))
                    d.Add(q2.Value, q1.Attribute("name").Value);
        }
        private IEnumerable<mUri> GetmUriCollection()
        {
            #region
            //远程取上下行的URI关联
            #endregion
            using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.RemoteConnString))
            {
                var m = mess.IP_stream.Where(e => e.http_uri != null || e.wsp_uri != null).Where(e => e.tcp_d != null);
                foreach (var ms in m)
                {
                    mUri a = new mUri();
                    a.fileNum = ms.FileNum;
                    a.tlli = ms.tlli;
                    a.sport = ms.tcp_s;
                    a.dport = ms.tcp_d;
                    //a.tcp_seq = ms.tcp_seq;
                    //a.tcp_ack = ms.tcp_ack;
                    a.uri = ms.http_uri == null ? "-" : ms.http_uri;
                    a.uri += ms.wsp_uri == null ? "-" : ms.wsp_uri;
                    a.uri += ms.http_x_online == null ? "-" : ms.http_x_online;
                    a.uri += ms.http_host == null ? "-" : ms.http_host;
                    a.uriStreamType = ConvertUri2trType(a.uri);
                    yield return a;
                }
            }
        }
        public class mUri
        {
            public int? fileNum;
            public string tlli;
            public string sport;
            public string dport;
            public string uri;
            //public string tcp_seq;
            //public string tcp_ack;
            public string uriStreamType;
        }

        public string ConvertUri2trType(string uri)
        {
            //当uri不是空时，默认是浏览类
            string trtype = "BrowseCategory";
            string[] ar = new string[2];
            foreach (var k in d)
            {
                if (k.Key.IndexOf("*") != -1)
                {
                    ar = k.Key.Split('*');
                    if (uri.IndexOf(ar[0]) != -1 && uri.IndexOf(ar[1]) != -1)
                        trtype = k.Value;
                }
                else
                {
                    if (uri.IndexOf(k.Key) != -1)
                        trtype = k.Value;
                }
            }
            return trtype;
        }
    }
}


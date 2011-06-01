using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IP_stream.Linq;

namespace IP_stream
{
    class ipType
    {
        private Dictionary<string, string> dIP;
        private DataClasses1DataContext localdb = new DataClasses1DataContext(streamType.LocalConnString);
        portType _portType = new portType();
        public ipType()
        {
            dIP = new Dictionary<string, string>();
            dIP = _portType.dPort;
            portTypeReverseIpType();
            //dIP = dIP.Where(e => e.Key.StartsWith("10.") == false)
            //.ToDictionary(e => e.Key, e => e.Value);
        }
        private void portTypeReverseIpType()
        {
            localdb = new DataClasses1DataContext(streamType.LocalConnString);
            //{
            //端口取下行包  ip_s
            var port_s = from p in localdb.IP_stream select new { p.tcp_s, p.ip_s };
            var portL = port_s.Where(e => e.tcp_s != null).ToLookup(e => e.tcp_s);
            foreach (var t in portL)
                foreach (var t1 in t)
                    if (_portType.dPort.ContainsKey(t.Key))
                        if (!dIP.ContainsKey(t1.ip_s))
                            dIP.Add(t1.ip_s, _portType.ConvertPort2trType(t.Key));
            //}
        }
        public string ConvertIP2trType(string ip)
        {
            string trtype = null;
            if (ip == null) return trtype;
            foreach (var k in dIP)
                if (ip.IndexOf(k.Key) != -1)
                    trtype = k.Value;
            return trtype;
        }
        private void protocolTypeReverseIpType()
        {
            localdb = new DataClasses1DataContext(streamType.LocalConnString);
            //using (DataClasses1DataContext localdb = new DataClasses1DataContext(streamType.LocalConnString))
            //{
            protocolType _protocolType = new protocolType();
            //协议取下行包  ip_s
            var protocol = from p in localdb.IP_stream
                           select new
                           {
                               cpro = p.mmse != null ? "MMSE" : null +
                                   p.rtsp_type != null ? "rtsp" : null +
                                   p.smtp_type != null ? "smtp" : null +
                                   p.bittorrent != null ? "BitTorrent" : null +
                                   p.edonkey != null ? "eDonkey" : null +
                                   p.oicqVersion != null ? "oicq" : null,
                               p.ip_s
                           };
            var protocolL = protocol.Where(e => e.cpro != null).ToLookup(e => e.cpro);
            foreach (var t in protocolL)
                foreach (var t1 in t)
                    if (_protocolType.d.ContainsKey(t.Key))
                        if (!dIP.ContainsKey(t1.ip_s))
                            dIP.Add(t1.ip_s, _protocolType.ConvertProtocol2trType(t.Key));
            //}
        }
        private void uriTypeReverseIpType()
        {
            localdb = new DataClasses1DataContext(streamType.LocalConnString);
            //using (DataClasses1DataContext localdb = new DataClasses1DataContext(streamType.LocalConnString))
            //{
            uriType _uriType = new uriType();
            //http取上行包  ip_d
            var uri = from p in localdb.IP_stream
                      select new
                      {
                          curi = p.http_uri != null ? p.http_uri : null +
                                 p.wsp_uri != null ? p.wsp_uri : null +
                                 p.http_x_online != null ? p.http_x_online : null +
                                 p.http_host != null ? p.http_host : null,
                          p.ip_d
                      };
            var uriL = uri.Where(e => e.curi != null).ToLookup(e => e.curi);
            foreach (var t in uriL)
                foreach (var t1 in t)
                    if (_uriType.d.ContainsKey(t.Key))
                        if (!dIP.ContainsKey(t1.ip_d))
                            dIP.Add(t1.ip_d, _uriType.ConvertUri2trType(t.Key));
            //}
        }
        private void responseTypeReverseIpType()
        {
            localdb = new DataClasses1DataContext(streamType.LocalConnString);
            //using (DataClasses1DataContext localdb = new DataClasses1DataContext(streamType.LocalConnString))
            //{
            responseType _responseType = new responseType();
            //response取下行包  ip_s
            var response = from p in localdb.IP_stream select new { cres = p.http_type, p.ip_s };
            var responseL = response.Where(e => e.cres != null).ToLookup(e => e.cres);
            foreach (var t in responseL)
                foreach (var t1 in t)
                    if (_responseType.d.ContainsKey(t.Key))
                        if (!dIP.ContainsKey(t1.ip_s))
                            dIP.Add(t1.ip_s, _responseType.ConvertResponse2trType(t.Key));
            //}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using IP_stream.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IP_stream
{

    public class OutPdchModel
    {
        private DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString);
        private double mTime { get; set; }
        private int minFileNum { get; set; }
        private int maxFileNum { get; set; }

        //private static decimal outputtableid = 0;

        //private decimal _outputtableid = 0;
        //private decimal outputtableid { get { return _outputtableid; } set { _outputtableid = value; } }

        public OutPdchModel()
        {
            mess.CommandTimeout = 0;
            Init();
            handleTable.CreateTable(typeof(OpCiPDCH));
            //Thread.Sleep(1); GC.Collect(); GC.Collect(); Application.DoEvents();
            //for (int i = minFileNum; i < maxFileNum; i++)
            //    SendOrders(i);
            Parallel.For(minFileNum, maxFileNum, i => { SendOrders(i); });
        }
        private void Init()
        {
            var readip = mess.IP_stream.Select(e => e.PacketTime);
            TimeSpan timer = readip.Max(e => e.Value) - readip.Min(e => e.Value);
            mTime = timer.TotalSeconds;
            var readpg = mess.IP_stream.Select(e => e.FileNum);
            minFileNum = readpg.Min(e => e.Value);
            maxFileNum = readpg.Max(e => e.Value)+1;
        }
        private IEnumerable<OpCiPDCH> OutCiUsePDCH(int? filenum)
        {
            mess = new DataClasses1DataContext(streamType.LocalConnString);
            mess.CommandTimeout = 0;

            var temp = mess.mLocatingType.Where(e => e.fileNum == filenum)
                .Select(e => new { e.lacCI, e.ciCoverUsePDCH, e.trafficType, e.mLen });

            var itemp = temp.ToLookup(e => e.lacCI);

            foreach (var tt in itemp.Where(e=>e.Key !=null)) //删除空的部分
            {
                OpCiPDCH ci = new OpCiPDCH();

                //outputtableid = outputtableid + 1;
                //ci.OpCiPDCH_id = outputtableid;

                ci.LacCi = tt.Key;
                ci.CiKbps = tt.Sum(e => e.mLen.ByteToKbps()) / mTime;
                ci.CiPDCH = tt.Max(e => e.ciCoverUsePDCH.StringToDouble());
                ci.StreamingMedia = tt.Where(e => e.trafficType == "StreamingMedia").Sum(e => e.mLen.ByteToKbps()) / mTime;
                ci.StockCategory = tt.Where(e => e.trafficType == "StockCategory").Sum(e => e.mLen.ByteToKbps()) / mTime;
                ci.OtherCategory = tt.Where(e => e.trafficType == "OtherCategory").Sum(e => e.mLen.ByteToKbps()) / mTime;
                ci.MMS = tt.Where(e => e.trafficType == "MMS").Sum(e => e.mLen.ByteToKbps()) / mTime;
                ci.IM = tt.Where(e => e.trafficType == "IM").Sum(e => e.mLen.ByteToKbps()) / mTime;
                ci.GeneralDownloads = tt.Where(e => e.trafficType == "GeneralDownloads").Sum(e => e.mLen.ByteToKbps()) / mTime;
                ci.GameCategory = tt.Where(e => e.trafficType == "GameCategory").Sum(e => e.mLen.ByteToKbps()) / mTime;
                ci.BrowseCategory = tt.Where(e => e.trafficType == "BrowseCategory").Sum(e => e.mLen.ByteToKbps()) / mTime;
                ci.P2P = tt.Where(e => e.trafficType == "P2P").Sum(e => e.mLen.ByteToKbps()) / mTime;

                yield return ci;
            }
        }
        private void SendOrders(int filenum)
        {
            using (SqlConnection con = new SqlConnection(streamType.LocalConnString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    var newOrders = OutCiUsePDCH(filenum);
                    SqlBulkCopy bc = new SqlBulkCopy(con,
                      //SqlBulkCopyOptions.CheckConstraints |
                      //SqlBulkCopyOptions.FireTriggers |
                      SqlBulkCopyOptions.KeepNulls, tran);
                    bc.BulkCopyTimeout = 36000;
                    bc.BatchSize = 1000;
                    bc.DestinationTableName = "OpCiPDCH";
                    bc.WriteToServer(newOrders.AsDataReader());
                    tran.Commit();
                }
                con.Close();
            }
            //Thread.Sleep(1); GC.Collect(); GC.Collect(); Application.DoEvents();
        }
    }
    public static class EMClass
    {
        public static double StringToDouble(this string s)
        {
            if (s == null) return 0.0;
            double dd = Convert.ToDouble(s);
            return dd;
        }
        public static double ByteToKbps(this int? intnull)
        {
            if (intnull == null) return 0.0;
            double dd = (double)intnull;
            return 8 * dd / 1024;
        }
        public static double IntNToDouble(this int? intnull)
        {
            if (intnull == null) return 0.0;
            double dd = (double)intnull;
            return dd;
        }
    }
}

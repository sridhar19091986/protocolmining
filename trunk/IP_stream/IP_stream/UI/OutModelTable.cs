using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IP_stream.Linq;
using System.Data.SqlClient;
using System.Threading;

namespace IP_stream
{
    class OutModelTable
    {
        private DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString);
        private ILookup<string, OpCiPDCH> itemp_pdch;
        public OutModelTable()
        {
            mess.CommandTimeout = 0;
            itemp_pdch = mess.OpCiPDCH.ToLookup(e => e.LacCi);
            handleTable.CreateTable(typeof(OpCiPDCH));
            handleTable.CreateTable(typeof(OpPaingTime));
            handleTable.CreateTable(typeof(OpPdchModel));
            Thread.Sleep(1); GC.Collect(); GC.Collect();
            SendOpPaingTime();
            SendOpCiPDCH();
            SendOpPdchModel();
        }
        private IEnumerable<OpPaingTime> MakeOpPaingTime()
        {
            var temp = mess.Gb_Paging_PS
                .Select(e => new { e.CI, e.LAC, e.Paging_Type_PS, e.Any_Uplink_PDU, e.Any_Uplink_PDU_delayFirst });

            var itemp_paging = temp.ToLookup(e => e.LAC + "-" + e.CI);

            foreach (var tt in itemp_paging)
            {
                OpPaingTime pg = new OpPaingTime();
                pg.LacCi = tt.Key;
                pg.mMessage = tt.Sum(e => e.Paging_Type_PS.IntNToDouble());
                pg.mResponeSucc = (tt.Sum(e => e.Any_Uplink_PDU).IntNToDouble()) / tt.Sum(e => e.Paging_Type_PS.IntNToDouble());
                pg.mDelay = tt.Average(e => e.Any_Uplink_PDU_delayFirst.IntNToDouble()) / 1000;
                yield return pg;
            }
        }
        private void SendOpPaingTime()
        {
            using (SqlConnection con = new SqlConnection(streamType.LocalConnString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    var newOrders = MakeOpPaingTime();
                    SqlBulkCopy bc = new SqlBulkCopy(con,
                      //SqlBulkCopyOptions.CheckConstraints |
                      //SqlBulkCopyOptions.FireTriggers |
                      SqlBulkCopyOptions.KeepNulls, tran);
                    bc.BulkCopyTimeout = 36000;
                    bc.BatchSize = 10000;
                    bc.DestinationTableName = "OpPaingTime";
                    bc.WriteToServer(newOrders.AsDataReader());
                    tran.Commit();
                }
                con.Close();
            }
        }
        private IEnumerable<OpCiPDCH> MakeOpCiPDCH()
        {
            foreach (var tt in itemp_pdch)
            {
                OpCiPDCH ci = new OpCiPDCH();
                ci.LacCi = tt.Key;
                ci.CiKbps = tt.Sum(e => e.CiKbps);
                ci.CiPDCH = tt.Max(e => e.CiPDCH);
                ci.StreamingMedia = tt.Sum(e => e.StreamingMedia);
                ci.StockCategory = tt.Sum(e => e.StockCategory);
                ci.OtherCategory = tt.Sum(e => e.OtherCategory);
                ci.MMS = tt.Sum(e => e.MMS);
                ci.IM = tt.Sum(e => e.IM);
                ci.GeneralDownloads = tt.Sum(e => e.GeneralDownloads);
                ci.GameCategory = tt.Sum(e => e.GameCategory);
                ci.BrowseCategory = tt.Sum(e => e.BrowseCategory);
                ci.P2P = tt.Sum(e => e.P2P);
                yield return ci;
            }
        }
        private void SendOpCiPDCH()
        {
            using (SqlConnection con = new SqlConnection(streamType.LocalConnString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    var newOrders = MakeOpCiPDCH();
                    SqlBulkCopy bc = new SqlBulkCopy(con,
                      //SqlBulkCopyOptions.CheckConstraints |
                      //SqlBulkCopyOptions.FireTriggers |
                      SqlBulkCopyOptions.KeepNulls, tran);
                    bc.BulkCopyTimeout = 36000;
                    bc.BatchSize = 10000;
                    bc.DestinationTableName = "OpCiPDCH";
                    bc.WriteToServer(newOrders.AsDataReader());
                    tran.Commit();
                }
                con.Close();
            }
        }
        private IEnumerable<OpPdchModel> MakeOpPdchModel()
        {
            var d = from pp in mess.OpCiPDCH
                    join qq in mess.OpPaingTime on pp.LacCi equals qq.LacCi
                    select new
                    {
                        小区号Ci = pp.LacCi,
                        小区总速率 = pp.CiKbps,
                        统计值_使用PDCH = pp.CiPDCH,
                        模型计算需求数ComputePDCH = 0,
                        模型计算增加或减少数NeedPDCH = 0,

                        业务速率IM = pp.IM,
                        业务速率GeneralDownloads_StreamingMedia_P2P_GameCategory = pp.GeneralDownloads + pp.StreamingMedia + pp.P2P + pp.GameCategory,
                        业务速率BrowseCategory_StockCategory = pp.BrowseCategory + pp.StockCategory,
                        业务速率MMS = pp.MMS,
                        业务速率OtherCategory = pp.OtherCategory,
                       
                        PS寻呼次数 = qq.mMessage,
                        PS寻呼成功率 = qq.mResponeSucc,
                        PS寻呼时延 = qq.mDelay
                    };

            var dd = d.OrderBy(e => e.PS寻呼时延).ToList();

            foreach (var ddd in dd)
            {
                OpPdchModel op = new OpPdchModel();
                op.小区号Ci = ddd.小区号Ci;
                op.小区总速率 = ddd.小区总速率;
                op.统计值_使用PDCH = ddd.统计值_使用PDCH;
                op.模型计算增加或减少数NeedPDCH = ddd.模型计算增加或减少数NeedPDCH;
                op.偏移量Offset = 1;

                op.业务速率IM= ddd.业务速率IM;
                op.业务速率GeneralDownloads_StreamingMedia_P2P_GameCategory = ddd.业务速率GeneralDownloads_StreamingMedia_P2P_GameCategory;
                op.业务速率BrowseCategory_StockCategory = ddd.业务速率BrowseCategory_StockCategory;
                op.业务速率MMS = ddd.业务速率MMS;
                op.业务速率OtherCategory = ddd.业务速率OtherCategory;

                op.PS寻呼次数 = ddd.PS寻呼次数;
                op.PS寻呼成功率 = ddd.PS寻呼成功率;
                op.PS寻呼时延 = ddd.PS寻呼时延;
                yield return op;
            }
        }
        private void SendOpPdchModel()
        {
            using (SqlConnection con = new SqlConnection(streamType.LocalConnString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    var newOrders = MakeOpPdchModel();
                    SqlBulkCopy bc = new SqlBulkCopy(con,
                      //SqlBulkCopyOptions.CheckConstraints |
                      //SqlBulkCopyOptions.FireTriggers |
                      SqlBulkCopyOptions.KeepNulls, tran);
                    bc.BulkCopyTimeout = 36000;
                    bc.BatchSize = 10000;
                    bc.DestinationTableName = "OpPdchModel";
                    bc.WriteToServer(newOrders.AsDataReader());
                    tran.Commit();
                }
                con.Close();
            }
        }
    }
}

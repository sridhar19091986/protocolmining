using System;
using System.Collections.Generic;
using System.Linq;
using IP_stream.Linq;

namespace IP_stream
{
    public class OutPutCiPDCH
    {
        //list=p.GetPersonnelInfo(sql);// List<> dataGridView1.DataSource=list; 
        //list为某对象范型集合 
        //运行后datagridView显示不出数据求解 ...
        //给Personnel类里要显示的字段设成属性,比如要显示的是id和name,把它们get和set的.
        public string LacCi { get; set; }
        public double? CiKbps { get; set; }
        public double? CiPDCH { get; set; }
        public double? X0_Coefficient { get; set; }
        public double? StreamingMedia { get; set; }
        public double? StockCategory { get; set; }
        public double? OtherCategory { get; set; }
        public double? MMS { get; set; }
        public double? IM { get; set; }
        public double? GeneralDownloads { get; set; }
        public double? GameCategory { get; set; }
        public double? BrowseCategory { get; set; }
        public double? P2P { get; set; }
    }
    public class OutPutPaingTime
    {
        //list=p.GetPersonnelInfo(sql);// List<> dataGridView1.DataSource=list; 
        //list为某对象范型集合 
        //运行后datagridView显示不出数据求解 ...
        //给Personnel类里要显示的字段设成属性,比如要显示的是id和name,把它们get和set的.
        public string LacCi { get; set; }
        public double? mMessage { get; set; }
        public double? mResponeSucc { get; set; }
        public double? mDelay { get; set; }
    }
    public class OutPutPDCH
    {
        public string 小区号Ci { get; set; }
        public double? 小区总速率 { get; set; }
        public double? 模型计算需求数ComputePDCH { get; set; }
        public double? 模型计算增加或减少数NeedPDCH { get; set; }
        public double? 统计值_使用PDCH { get; set; }
        public double? 偏移量Offset { get; set; }
        public double? 业务速率StreamingMedia_P2P { get; set; }
        public double? 业务速率OtherCategory_StockCategory_MMS_GameCategory { get; set; }
        public double? 业务速率IM { get; set; }
        public double? 业务速率GeneralDownloads { get; set; }
        public double? 业务速率BrowseCategory { get; set; }
        public double? PS寻呼次数 { get; set; }
        public double? PS寻呼成功率 { get; set; }
        public double? PS寻呼时延 { get; set; }
    }
    public class OutPutTable
    {
        DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString);
        private double mTime;
        private IList<OutPutCiPDCH> CiPDCH = new List<OutPutCiPDCH>();
        private IList<OutPutPaingTime> PagingTime = new List<OutPutPaingTime>();
        public IList<OutPutPDCH> PDCH = new List<OutPutPDCH>();
        public OutPutTable()
        {
            mess.CommandTimeout = 0;//sql连接超时的问题
            OutGatherTime();
            OutCiUsePDCH();
            OutCiPagingTime();
            OutCiPdchModel();
        }
        void OutGatherTime()
        {
            var readGb = mess.IP_stream;
            TimeSpan timer = readGb.Max(e => e.PacketTime).Value - readGb.Min(e => e.PacketTime).Value;
            mTime = timer.TotalSeconds;
        }
        void OutCiUsePDCH()
        {
            var b = from p in mess.mLocatingType
                    group p by p.lacCI into tt
                    // let allLen = a.Sum(e => e.MLen)
                    select new
                    {
                        LacCi = tt.Key,
                        CiKbps = ToPercent(tt.Sum(e => e.mLen) * 1.0 / mTime),
                        CiPDCH = tt.Average(e => (e.ciCoverUsePDCH == null ? 0 : Convert.ToDouble(e.ciCoverUsePDCH))),
                        StreamingMedia = ToPercent(tt.Where(e => e.trafficType == "StreamingMedia").Sum(e => e.mLen) * 1.0 / mTime),
                        StockCategory = ToPercent(tt.Where(e => e.trafficType == "StockCategory").Sum(e => e.mLen) * 1.0 / mTime),
                        OtherCategory = ToPercent(tt.Where(e => e.trafficType == "OtherCategory").Sum(e => e.mLen) * 1.0 / mTime),
                        MMS = ToPercent(tt.Where(e => e.trafficType == "MMS").Sum(e => e.mLen) * 1.0 / mTime),
                        IM = ToPercent(tt.Where(e => e.trafficType == "IM").Sum(e => e.mLen) * 1.0 / mTime),
                        GeneralDownloads = ToPercent(tt.Where(e => e.trafficType == "GeneralDownloads").Sum(e => e.mLen) * 1.0 / mTime),
                        GameCategory = ToPercent(tt.Where(e => e.trafficType == "GameCategory").Sum(e => e.mLen) * 1.0 / mTime),
                        BrowseCategory = ToPercent(tt.Where(e => e.trafficType == "BrowseCategory").Sum(e => e.mLen) * 1.0 / mTime),
                        P2P = ToPercent(tt.Where(e => e.trafficType == "P2P").Sum(e => e.mLen) * 1.0 / mTime),
                    };
            foreach (var bbb in b)
            {
                OutPutCiPDCH ci = new OutPutCiPDCH();
                ci.LacCi = bbb.LacCi;
                ci.CiKbps = bbb.CiKbps;
                ci.CiPDCH = bbb.CiPDCH;
                ci.StreamingMedia = bbb.StreamingMedia;
                ci.StockCategory = bbb.StockCategory;
                ci.OtherCategory = bbb.OtherCategory;
                ci.MMS = bbb.MMS;
                ci.IM = bbb.IM;
                ci.GeneralDownloads = bbb.GeneralDownloads;
                ci.GameCategory = bbb.GameCategory;
                ci.BrowseCategory = bbb.BrowseCategory;
                ci.P2P = bbb.P2P;
                CiPDCH.Add(ci);
            }
            //return b.Cast<OutPutCiPDCH>();
        }
        void OutCiPagingTime()
        {
            var c = from p in mess.Gb_Paging_PS
                    //where p.Any_Uplink_PDU != null
                    //where p.PS_Paging_Repeat ==null
                    group p by p.CI into psbyfilenum
                    orderby psbyfilenum.Key
                    select new
                    {
                        LacCi = psbyfilenum.Select(e => e.LAC).FirstOrDefault() + "-" + psbyfilenum.Key,
                        mMessage = psbyfilenum.Sum(e => e.Paging_Type_PS),
                        mResponeSucc = (psbyfilenum.Sum(e => e.Any_Uplink_PDU) + 0.0) / psbyfilenum.Sum(e => e.Paging_Type_PS),
                        mDelay = psbyfilenum.Average(e => e.Any_Uplink_PDU_delayFirst) / 1000
                    };
            foreach (var ccc in c)
            {
                OutPutPaingTime pg = new OutPutPaingTime();
                pg.LacCi = ccc.LacCi;
                pg.mMessage = ccc.mMessage;
                pg.mResponeSucc = ccc.mResponeSucc;
                pg.mDelay = ccc.mDelay;
                PagingTime.Add(pg);
            }
        }
        void OutCiPdchModel()
        {
            var d = from pp in CiPDCH
                    join qq in PagingTime on pp.LacCi equals qq.LacCi
                    select new
                    {
                        小区号Ci = pp.LacCi,
                        小区总速率 = pp.CiKbps,
                        统计值_使用PDCH = pp.CiPDCH,
                        模型计算需求数ComputePDCH = 0,
                        模型计算增加或减少数NeedPDCH = 0,
                        业务速率StreamingMedia_P2P = pp.StreamingMedia + pp.P2P,
                        业务速率OtherCategory_StockCategory_MMS_GameCategory = pp.OtherCategory + pp.MMS + pp.StockCategory + pp.GameCategory,
                        业务速率IM = pp.IM,
                        业务速率GeneralDownloads = pp.GeneralDownloads,
                        业务速率BrowseCategory = pp.BrowseCategory,
                        PS寻呼次数 = qq.mMessage,
                        PS寻呼成功率 = qq.mResponeSucc,
                        PS寻呼时延 = qq.mDelay
                    };

            var dd = d.OrderBy(e => e.PS寻呼时延).ToList();
            foreach (var ddd in dd)
            {
                OutPutPDCH op = new OutPutPDCH();
                op.小区号Ci = ddd.小区号Ci;
                op.小区总速率 = ddd.小区总速率;
                op.统计值_使用PDCH = ddd.统计值_使用PDCH;
                op.模型计算增加或减少数NeedPDCH = ddd.模型计算增加或减少数NeedPDCH;
                op.偏移量Offset = 1;
                op.业务速率StreamingMedia_P2P = ddd.业务速率StreamingMedia_P2P;
                op.业务速率OtherCategory_StockCategory_MMS_GameCategory = ddd.业务速率OtherCategory_StockCategory_MMS_GameCategory;
                op.业务速率IM = ddd.业务速率IM;
                op.业务速率GeneralDownloads = ddd.业务速率GeneralDownloads;
                op.业务速率BrowseCategory = ddd.业务速率BrowseCategory;
                op.PS寻呼次数 = ddd.PS寻呼次数;
                op.PS寻呼成功率 = ddd.PS寻呼成功率;
                op.PS寻呼时延 = ddd.PS寻呼时延;
                PDCH.Add(op);
            }
            // return d.OrderBy(e => e.PS寻呼时延).Cast<OutPutPDCH>();
        }


        //	from c in db.Customers
        //	join o in db.Orders on c.CustomerID
        //	equals o.CustomerID into orders 
        //  Define other methods and classes here
        double ToPercent(double? d)
        {
            if (d == null) return 0;
            double dd = (double)d;
            return 8 * dd / 1024;
            //return dd.ToString("F2");
            //return double.Parse(dd.ToString("P02"));
        }

        double ToPointOne(double? d)
        {
            if (d == null) return 0;
            int i = (int)(d * 10);
            double dd = (double)(i * 1.0) / 10;
            return dd;
        }

    }
}

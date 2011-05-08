using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace IP_stream
{
    public class OutPutCiPDCH
    {
        //list=p.GetPersonnelInfo(sql);// List<> dataGridView1.DataSource=list; 
        //list为某对象范型集合 
        //运行后datagridView显示不出数据求解 ...
        //给Personnel类里要显示的字段设成属性,比如要显示的是id和name,把它们get和set的.
        public string PaingTimer{get;set;}
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
    public class OutPutTable
    {
        public IList<OutPutCiPDCH> CiPDCH = new List<OutPutCiPDCH>();
        public OutPutTable()
        { 
            OutPutciCoverType();
        }
        private void OutPutciCoverType()
        {
            DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString);
            mess.CommandTimeout = 0;//sql连接超时的问题
            var readGb = mess.IP_stream;
            TimeSpan timer = readGb.Max(e => e.PacketTime).Value - readGb.Min(e => e.PacketTime).Value;
            var mTime = timer.TotalSeconds;
            var a = from p in mess.mLocatingType
                    select p;
            var b = from p in a
                    group p by p.lacCI into tt
                    let allLen = a.Sum(e => e.mLen)
                    select new
                    {
                        mKey = tt.Key,
                        CiIpByte = tt.Sum(e => e.mLen) * 1.0 / mTime,

                        //a.ciAllocPDCH => e.ciAllocPDCH
                        //a.ciUsePDCH => e.ciUsePDCH
                        CiPDCH =tt.Select(e => e.ciCoverUsePDCH).FirstOrDefault()==null?0
                        :Convert.ToDouble( tt.Select(e => e.ciCoverUsePDCH).FirstOrDefault()), //此处修改 2011.4.12

                        StreamingMedia = tt.Where(e => e.trafficType == "StreamingMedia").Sum(e => e.mLen) * 1.0 / mTime,
                        StockCategory = tt.Where(e => e.trafficType == "StockCategory").Sum(e => e.mLen) * 1.0 / mTime,
                        OtherCategory = tt.Where(e => e.trafficType == "OtherCategory").Sum(e => e.mLen) * 1.0 / mTime,
                        MMS = tt.Where(e => e.trafficType == "MMS").Sum(e => e.mLen) * 1.0 / mTime,
                        IM = tt.Where(e => e.trafficType == "IM").Sum(e => e.mLen) * 1.0 / mTime,
                        GeneralDownloads = tt.Where(e => e.trafficType == "GeneralDownloads").Sum(e => e.mLen) * 1.0 / mTime,
                        GameCategory = tt.Where(e => e.trafficType == "GameCategory").Sum(e => e.mLen) * 1.0 / mTime,
                        BrowseCategory = tt.Where(e => e.trafficType == "BrowseCategory").Sum(e => e.mLen) * 1.0 / mTime,
                        P2P = tt.Where(e => e.trafficType == "P2P").Sum(e => e.mLen) * 1.0 / mTime,
                    };
            var c = from p in mess.Gb_Paging_PS
                    where p.Any_Uplink_PDU != null
                    where p.PS_Paging_Repeat == null
                    group p by p.CI into psbyfilenum
                    orderby psbyfilenum.Key
                    select new
                    {
                        mKey = psbyfilenum.Select(e => e.LAC).FirstOrDefault() + "-" + psbyfilenum.Key,
                        mMessage = psbyfilenum.Sum(e => e.Paging_Type_PS),
                        mResponeSucc = (psbyfilenum.Sum(e => e.Any_Uplink_PDU) + 0.0) / psbyfilenum.Sum(e => e.Paging_Type_PS),
                        //mDelay = psbyfilenum.Average(e => e.Any_Uplink_PDU_delayFirst) / 1000
                        mDelay = Convert.ToInt32(psbyfilenum.Average(e => e.Any_Uplink_PDU_delayFirst) / 50)//此处修改 2011.4.12
                    };
           //MessageBox.Show("212");
            var d = from pp in b
                    join qq in c on pp.mKey equals qq.mKey
                    select new
                    {
                        pp.mKey,
                        pp.CiIpByte,
                        pp.CiPDCH,
                        pp.StreamingMedia,
                        pp.StockCategory,
                        pp.OtherCategory,
                        pp.MMS,
                        pp.IM,
                        pp.GeneralDownloads,
                        pp.GameCategory,
                        pp.BrowseCategory,
                        pp.P2P,
                        qq.mMessage,
                        qq.mResponeSucc,
                        qq.mDelay
                    };
            var ee = from p in d
                     group p by p.mDelay into ttt
                     select new
                     {
                         PaingTimer = (Convert.ToString(ttt.Key * 0.05)).Substring(0,5),
                         //CiPDCH = ttt.Sum(e => e.CiIpByte),//此处修改成PDCH占用总数
                         CiPDCH = ttt.Sum(e => e.CiPDCH),//此处修改 2011.4.12
                         X0_Coefficient = 1,
                         StreamingMedia = ttt.Sum(e => e.StreamingMedia) / ttt.Key,
                         StockCategory = ttt.Sum(e => e.StockCategory) / ttt.Key,
                         OtherCategory = ttt.Sum(e => e.OtherCategory) / ttt.Key,
                         MMS = ttt.Sum(e => e.MMS) / ttt.Key,
                         IM = ttt.Sum(e => e.IM) / ttt.Key,
                         GeneralDownloads = ttt.Sum(e => e.GeneralDownloads) / ttt.Key,
                         GameCategory = ttt.Sum(e => e.GameCategory) / ttt.Key,
                         BrowseCategory = ttt.Sum(e => e.BrowseCategory) / ttt.Key,
                         P2P = ttt.Sum(e => e.P2P) / ttt.Key,
                     };
            var abcd = ee.ToDictionary(e => e.PaingTimer).OrderBy(e => e.Key);
            MessageBox.Show(abcd.Count().ToString());
            foreach (var e in abcd)
            {
                OutPutCiPDCH f = new OutPutCiPDCH();
                f.BrowseCategory = e.Value.BrowseCategory;
                f.CiPDCH = e.Value.CiPDCH;
                f.GameCategory = e.Value.GameCategory;
                f.GeneralDownloads = e.Value.GeneralDownloads;
                f.IM = e.Value.IM;
                f.MMS = e.Value.MMS;
                f.OtherCategory = e.Value.OtherCategory;
                f.P2P = e.Value.P2P;
                f.PaingTimer = e.Value.PaingTimer;
                f.StockCategory = e.Value.StockCategory;
                f.StreamingMedia = e.Value.StreamingMedia;
                f.X0_Coefficient = e.Value.X0_Coefficient;
                //MessageBox.Show(e.Key.ToString());
                //yield return f;
                CiPDCH.Add(f);
            }
            //ee.OrderBy (e=>e.PaingTimer).Dump ();


        }
        //	from c in db.Customers
        //	join o in db.Orders on c.CustomerID
        //	equals o.CustomerID into orders 
        //  Define other methods and classes here
        //private static double ToPercent(double? d)
        //{
        //    if (d == null) return 0.0001;
        //    double dd = (double)d;
        //    return 8 * dd / 1024;
        //    //return dd.ToString("F2");
        //    //return double.Parse(dd.ToString("P02"));
        //}

        //private  double ToPointOne(double? d)
        //{
        //    if (d == null) return 0;
        //    int i = (int)(d * 10);
        //    double dd = (double)(i * 1.0) / 10;
        //    return dd;
        //}
        //private double string2double(string str)
        //{
        //    if (str == null) return 0;
        //    if (str == "") return 0;
        //    if (str.Length == 0) return 0;
        //    return Convert.ToDouble(str);
        //}

    }
}

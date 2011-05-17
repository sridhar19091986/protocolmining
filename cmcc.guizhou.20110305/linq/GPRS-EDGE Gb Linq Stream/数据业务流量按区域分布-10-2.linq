<Query Kind="Program">
  <Connection>
    <ID>4bf09d82-2274-4382-a6e9-bea773c75ba2</ID>
    <Server>localhost</Server>
    <Persist>true</Persist>
    <Database>mytest</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
    var readGb=IP_streams;
    TimeSpan timer=readGb.Max(e=>e.PacketTime).Value- readGb.Min(e=>e.PacketTime).Value;
    var mTime=timer.TotalSeconds;
	var a=from p in MLocatingTypes  
		 select p; 
	var b=from p in a
	      group p by p.LacCI  into tt
		  	  let allLen= a.Sum (e=>e.MLen )
		  select new
		  {
		        mKey=tt.Key ,
				CiIpByte=ToPercent(tt.Sum(e=>e.MLen)*1.0/mTime),
				CiPDCH=tt.Average(e=>(e.CiCoverUsePDCH==null?0:Convert.ToDouble(e.CiCoverUsePDCH))),
	       	    StreamingMedia=ToPercent(tt.Where (e=>e.TrafficType =="StreamingMedia").Sum (e=>e.MLen )*1.0/(mTime)),
		        StockCategory=ToPercent(tt.Where (e=>e.TrafficType =="StockCategory").Sum (e=>e.MLen )*1.0/(mTime)),
			    OtherCategory=ToPercent(tt.Where (e=>e.TrafficType=="OtherCategory").Sum (e=>e.MLen )*1.0/(mTime)),
			    MMS=ToPercent(tt.Where (e=>e.TrafficType =="MMS").Sum (e=>e.MLen )*1.0/(mTime)),
		 	    IM=ToPercent(tt.Where (e=>e.TrafficType =="IM").Sum (e=>e.MLen )*1.0/(mTime)),
				GeneralDownloads=ToPercent(tt.Where (e=>e.TrafficType=="GeneralDownloads").Sum (e=>e.MLen )*1.0/(mTime)),
				GameCategory=ToPercent(tt.Where (e=>e.TrafficType =="GameCategory").Sum (e=>e.MLen )*1.0/(mTime)),
				BrowseCategory=ToPercent(tt.Where (e=>e.TrafficType =="BrowseCategory").Sum (e=>e.MLen )*1.0/(mTime)),
				P2P=ToPercent(tt.Where (e=>e.TrafficType =="P2P").Sum (e=>e.MLen )*1.0/(mTime)),
		  };		
    var c= from p in Gb_Paging_PS
	where p.Any_Uplink_PDU !=null
	//where p.PS_Paging_Repeat ==null
	group p by p.CI into psbyfilenum
	orderby psbyfilenum.Key 
	select new 
	{
	    mKey=psbyfilenum.Select(e=>e.LAC).FirstOrDefault()+"-"+psbyfilenum.Key ,
 	    mMessage= psbyfilenum.Sum (e=>e.Paging_Type_PS),   
	    mResponeSucc= (psbyfilenum.Sum (e=>e.Any_Uplink_PDU )+0.0)/psbyfilenum.Sum (e=>e.Paging_Type_PS),
	    mDelay=psbyfilenum.Average (e =>e.Any_Uplink_PDU_delayFirst)/100
	};
	var d=from pp in b.ToList()
	      join qq in c on  pp.mKey equals qq.mKey 
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
	var ee=from p in d.ToList()
	      group p by ToPointOne(p.mDelay) into ttt
		  select new 
		  {
		     寻呼时延PaingTimer=ttt.Key,
			 //CiIpByte=ttt.Average(e=>e.CiIpByte),
		     PDCH配置数CiPDCH=ttt.Sum(e=>e.CiPDCH),//此处修改成PDCH占用总数
             系数X0_Coefficient=1,
//		     业务速率StreamingMedia=ttt.Sum(e=>e.StreamingMedia),
//			 业务速率StockCategory=ttt.Sum(e=>e.StockCategory),
//		     业务速率OtherCategory=ttt.Sum(e=>e.OtherCategory),
//		     业务速率MMS=ttt.Sum(e=>e.MMS),
//		     业务速率IM=ttt.Sum(e=>e.IM),
//		     业务速率GeneralDownloads=ttt.Sum(e=>e.GeneralDownloads),
//		     业务速率GameCategory=ttt.Sum(e=>e.GameCategory),
//		     业务速率BrowseCategory=ttt.Sum(e=>e.BrowseCategory),
//		     业务速率P2P=ttt.Sum(e=>e.P2P),
			 业务速率StreamingMedia_P2P=ttt.Sum(pp=>pp.StreamingMedia+pp.P2P),
		     业务速率OtherCategory_StockCategory_MMS_GameCategory=ttt.Sum(pp=>pp.OtherCategory+pp.MMS+pp.StockCategory+pp.GameCategory),
		     业务速率IM=ttt.Sum(pp=>pp.IM),
		     业务速率GeneralDownloads=ttt.Sum(pp=>pp.GeneralDownloads),
		     业务速率BrowseCategory=ttt.Sum(pp=>pp.BrowseCategory),
		};
	   ee.OrderBy (e=>e.寻呼时延PaingTimer).Dump ();
}

//	from c in db.Customers
//	join o in db.Orders on c.CustomerID
//	equals o.CustomerID into orders 
//  Define other methods and classes here
	double ToPercent(double? d)
	{
	    if (d==null) return 0.01;
	    double dd=(double)d;
		return 8*dd/1024;
		//return dd.ToString("F2");
		//return double.Parse(dd.ToString("P02"));
	}
	
	double ToPointOne(double?  d)
	{
		if (d==null) return 0;
		int i =(int)(d * 10);
		double dd = (double)(i*1.0)/100;
		return dd;
	}
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
	where p.PS_Paging_Repeat ==null
	group p by p.CI into psbyfilenum
	orderby psbyfilenum.Key 
	select new 
	{
	    mKey=psbyfilenum.Select(e=>e.LAC).FirstOrDefault()+"-"+psbyfilenum.Key ,
 	    mMessage= psbyfilenum.Sum (e=>e.Paging_Type_PS),   
	    mResponeSucc= (psbyfilenum.Sum (e=>e.Any_Uplink_PDU )+0.0)/psbyfilenum.Sum (e=>e.Paging_Type_PS),
	    mDelay=psbyfilenum.Average (e =>e.Any_Uplink_PDU_delayFirst)/1000
	};
	var d=from pp in b.ToList()
	      join qq in c on  pp.mKey equals qq.mKey 
		  select new 
		  {
		     小区号Ci=pp.mKey,
		     小区总速率=pp.CiIpByte,
		     统计值_使用PDCH=pp.CiPDCH,
			 模型计算需求数ComputePDCH=0,
			 模型计算增加或减少数NeedPDCH=0,
		     业务速率StreamingMedia=pp.StreamingMedia,
			 业务速率StockCategory=pp.StockCategory,
		     业务速率OtherCategory=pp.OtherCategory,
		     业务速率MMS=pp.MMS,
		     业务速率IM=pp.IM,
		     业务速率GeneralDownloads=pp.GeneralDownloads,
		     业务速率GameCategory=pp.GameCategory,
		     业务速率BrowseCategory=pp.BrowseCategory,
		     业务速率P2P=pp.P2P,
		     PS寻呼=qq.mMessage,
		     PS寻呼成功率=qq.mResponeSucc,
		     PS寻呼时延=qq.mDelay
		  };
	
	 d.OrderBy(e=>e.PS寻呼时延).Dump();
}


//	from c in db.Customers
//	join o in db.Orders on c.CustomerID
//	equals o.CustomerID into orders 
//  Define other methods and classes here
	double ToPercent(double? d)
	{
	    if (d==null) return 0.00001;
	    double dd=(double)d;
		return 8*dd/1024;
		//return dd.ToString("F2");
		//return double.Parse(dd.ToString("P02"));
	}
	
	double ToPointOne(double?  d)
	{
		if (d==null) return 0;
		int i =(int)(d * 10);
		double dd = (double)(i*1.0)/10;
		return dd;
	}
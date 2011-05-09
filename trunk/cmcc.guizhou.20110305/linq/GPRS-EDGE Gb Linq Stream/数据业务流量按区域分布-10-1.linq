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
				CiPDCH=tt.Select(e=>e.CiCoverUsePDCH).FirstOrDefault(),
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
		     Ci=pp.mKey,
		     pp.CiIpByte,
		     pp.CiPDCH,
			 ComputePDCH=0,
			 NeedPDCH=0,
		     StreamingMedia=pp.StreamingMedia/qq.mDelay,
			 StockCategory=pp.StockCategory/qq.mDelay,
		     OtherCategory=pp.OtherCategory/qq.mDelay,
		     MMS=pp.MMS/qq.mDelay,
		     IM=pp.IM/qq.mDelay,
		     GeneralDownloads=pp.GeneralDownloads/qq.mDelay,
		     GameCategory=pp.GameCategory/qq.mDelay,
		     BrowseCategory=pp.BrowseCategory/qq.mDelay,
		     P2P=pp.P2P/qq.mDelay,
		     qq.mMessage,
		     qq.mResponeSucc,
		     qq.mDelay
		  };
	
	 d.OrderBy(e=>e.mDelay).Dump();
}


//	from c in db.Customers
//	join o in db.Orders on c.CustomerID
//	equals o.CustomerID into orders 
//  Define other methods and classes here
	double ToPercent(double? d)
	{
	    if (d==null) return 0.0001;
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
<Query Kind="Program">
  <Connection>
    <ID>a227fb82-8e77-4297-a037-c08cd4b366e6</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>23A</Database>
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
				CiPDCH=tt.Select(e=>e.CiConverType).FirstOrDefault(),
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
		  
//    var c= from p in Gb_Authentications
//	       //where p.Authentication_Req_Repeat ==null
//	       group p by p.CI into psbyfilenum
//	       orderby psbyfilenum.Key 
//	       select new 
//		 {
//	           mKey=psbyfilenum.Select(e=>e.LAC).FirstOrDefault()+"-"+psbyfilenum.Key ,
//	           //mTime=psbyfilenum.Where (e=>e.FileNum ==psbyfilenum.Key).Select(e=>e.PacketTime.Value.AddHours(8)).Min (),
//	           mTime=psbyfilenum.Min(e=>e.PacketTime.Value.AddHours(-8)),
//	           mName="Authentication_and_Ciphering",
//	           mMessage= psbyfilenum.Where (e=>e.Authentication_and_Ciphering_Resp!=null).Sum(e=>e.Authentication_and_Ciphering_Resp),
//	           mSuccess= (psbyfilenum.Where (e=>e.Authentication_and_Ciphering_Resp!=null).Sum(e=>e.Authentication_and_Ciphering_Resp)+0.0)/psbyfilenum.Sum(e=>e.Authentication_and_Ciphering_Req),
//	           mDelay= psbyfilenum.Where (e=>e.Authentication_and_Ciphering_Resp!=null).Average(e =>e.Authentication_and_Ciphering_Resp_delayFirst)/1000
//	           //mStatus=Gb_LLC_Discardeds.Where(e=>e.BVCI==psbyfilenum.Key).Count()
//       	};
		
    var c= from p in Gb_Paging_PS
	where p.Any_Uplink_PDU !=null
	where p.PS_Paging_Repeat ==null
	group p by p.CI into psbyfilenum
	orderby psbyfilenum.Key 
	select new 
	{
	    mKey=psbyfilenum.Select(e=>e.LAC).FirstOrDefault()+"-"+psbyfilenum.Key ,
//		mFile=psbyfilenum.Key ,
//	    mLac=psbyfilenum.Select(e=>e.LAC).FirstOrDefault(),
		//mTime=psbyfilenum.Select(e=>e.PacketTime.Value.AddHours(8)).Min (),
//		mTime=psbyfilenum.Min (e=>e.PacketTime.Value.AddHours(-8)),
		//mName="Paging_TypePS_AnyUplinkPDU",
 	    mMessage= psbyfilenum.Sum (e=>e.Paging_Type_PS),   
//	    mRepeat= psbyfilenum.Sum (e=>e.PS_Paging_Repeat),
//	    mRespone= psbyfilenum.Sum (e=>e.Any_Uplink_PDU ),
//	    mRepeatSucc= (psbyfilenum.Sum (e=>e.PS_Paging_Repeat)+0.0)/psbyfilenum.Sum (e=>e.Any_Uplink_PDU ),
	    mResponeSucc= (psbyfilenum.Sum (e=>e.Any_Uplink_PDU )+0.0)/psbyfilenum.Sum (e=>e.Paging_Type_PS),
	    mDelay=psbyfilenum.Average (e =>e.Any_Uplink_PDU_delayFirst)/1000
	};
//	ps.Dump ();
	
	var d=from pp in b.ToList()
	      join qq in c on  pp.mKey equals qq.mKey 
//		  into aa
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
	
	 d.Dump();
		
    //d.OrderByDescending (e=>e.mDelay).Dump ();
	
	var ee=from p in d.ToList()
	      group p by ToPointOne(p.mDelay) into ttt
		  select new 
		  {
		     mKey=ttt.Key,
		     CiIpByte=ttt.Sum(e=>e.CiIpByte),
//		     pp.CiPDCH,
		     StreamingMedia=ttt.Sum(e=>e.StreamingMedia),
			 StockCategory=ttt.Sum(e=>e.StockCategory),
		     OtherCategory=ttt.Sum(e=>e.OtherCategory),
		     MMS=ttt.Sum(e=>e.MMS),
		     IM=ttt.Sum(e=>e.IM),
		     GeneralDownloads=ttt.Sum(e=>e.GeneralDownloads),
		     GameCategory=ttt.Sum(e=>e.GameCategory),
		     BrowseCategory=ttt.Sum(e=>e.BrowseCategory),
		     P2P=ttt.Sum(e=>e.P2P),
//		     tt.Sum(qq=>qq.mMessage),
//		     tt.Sum(qq=>qq.mResponeSucc),
//		     tt.Sum(qq=>qq.mDelay)
		};
		
		//ee.Dump();
		  
	   ee.OrderByDescending (e=>e.mKey).Dump ();
}

//	from c in db.Customers
//	join o in db.Orders on c.CustomerID
//	equals o.CustomerID into orders 
//  Define other methods and classes here
	double ToPercent(double? d)
	{
	    if (d==null) return 0;
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
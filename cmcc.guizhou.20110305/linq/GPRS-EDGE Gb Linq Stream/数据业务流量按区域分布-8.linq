<Query Kind="Program">
  <Connection>
    <ID>337b631f-296e-4a3b-aa36-09f23a9a9a38</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
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
	       	    StreamingMedia=ToPercent(tt.Where (e=>e.TrafficType =="StreamingMedia").Sum (e=>e.MLen )*1.0/(mTime*tt.Where (e=>e.TrafficType =="StreamingMedia").Select(e=>e.Imsi).Distinct().Count())),
		        StockCategory=ToPercent(tt.Where (e=>e.TrafficType =="StockCategory").Sum (e=>e.MLen )*1.0/(mTime*tt.Where (e=>e.TrafficType =="StockCategory").Select(e=>e.Imsi).Distinct().Count())),
			    OtherCategory=ToPercent(tt.Where (e=>e.TrafficType=="OtherCategory").Sum (e=>e.MLen )*1.0/(mTime*tt.Where (e=>e.TrafficType =="OtherCategory").Select(e=>e.Imsi).Distinct().Count())),
			    MMS=ToPercent(tt.Where (e=>e.TrafficType =="MMS").Sum (e=>e.MLen )*1.0/(mTime*tt.Where (e=>e.TrafficType =="MMS").Select(e=>e.Imsi).Distinct().Count())),
		 	    IM=ToPercent(tt.Where (e=>e.TrafficType =="IM").Sum (e=>e.MLen )*1.0/(mTime*tt.Where (e=>e.TrafficType =="IM").Select(e=>e.Imsi).Distinct().Count())),
				GeneralDownloads=ToPercent(tt.Where (e=>e.TrafficType=="GeneralDownloads").Sum (e=>e.MLen )*1.0/(mTime*tt.Where (e=>e.TrafficType =="GeneralDownloads").Select(e=>e.Imsi).Distinct().Count())),
				GameCategory=ToPercent(tt.Where (e=>e.TrafficType =="GameCategory").Sum (e=>e.MLen )*1.0/(mTime*tt.Where (e=>e.TrafficType =="GameCategory").Select(e=>e.Imsi).Distinct().Count())),
				BrowseCategory=ToPercent(tt.Where (e=>e.TrafficType =="BrowseCategory").Sum (e=>e.MLen )*1.0/(mTime*tt.Where (e=>e.TrafficType =="BrowseCategory").Select(e=>e.Imsi).Distinct().Count())),
				P2P=ToPercent(tt.Where (e=>e.TrafficType =="P2P").Sum (e=>e.MLen )*1.0/(mTime*tt.Where (e=>e.TrafficType =="P2P").Select(e=>e.Imsi).Distinct().Count())),
		  };
		  
    var c= from p in Gb_Authentications
	       //where p.Authentication_Req_Repeat ==null
	       group p by p.CI into psbyfilenum
	       orderby psbyfilenum.Key 
	       select new 
		 {
	           mKey=psbyfilenum.Select(e=>e.LAC).FirstOrDefault()+"-"+psbyfilenum.Key ,
	           //mTime=psbyfilenum.Where (e=>e.FileNum ==psbyfilenum.Key).Select(e=>e.PacketTime.Value.AddHours(8)).Min (),
	           mTime=psbyfilenum.Min(e=>e.PacketTime.Value.AddHours(-8)),
	           mName="Authentication_and_Ciphering",
	           mMessage= psbyfilenum.Where (e=>e.Authentication_and_Ciphering_Resp!=null).Sum(e=>e.Authentication_and_Ciphering_Resp),
	           mSuccess= (psbyfilenum.Where (e=>e.Authentication_and_Ciphering_Resp!=null).Sum(e=>e.Authentication_and_Ciphering_Resp)+0.0)/psbyfilenum.Sum(e=>e.Authentication_and_Ciphering_Req),
	           mDelay= psbyfilenum.Where (e=>e.Authentication_and_Ciphering_Resp!=null).Average(e =>e.Authentication_and_Ciphering_Resp_delayFirst)/1000
	           //mStatus=Gb_LLC_Discardeds.Where(e=>e.BVCI==psbyfilenum.Key).Count()
       	};
		
	var d=from pp in b
	      join qq in c on  pp.mKey equals qq.mKey 
//		  into aa
		  select new 
		  {
		     pp.mKey,
		     pp.CiIpByte,
		     pp.CiPDCH,
		     pp.StreamingMedia,
		     pp.OtherCategory,
		     pp.MMS,
		     pp.IM,
		     pp.GeneralDownloads,
		     pp.GameCategory,
		     pp.BrowseCategory,
		     pp.P2P,
		     qq.mMessage,
		     qq.mSuccess,
		     qq.mDelay
		  };
	
	// d.Dump();
		
    d.OrderByDescending (e=>e.mDelay).Dump ();
	
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
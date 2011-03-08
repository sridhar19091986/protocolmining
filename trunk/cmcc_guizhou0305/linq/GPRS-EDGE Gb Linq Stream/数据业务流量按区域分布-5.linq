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
	var a=from p in MLocatingTypes  
		 select p;
	var b=from p in a
	      group p by p.LacCI  into tt
		  	  let allLen= a.Sum (e=>e.MLen )
		  select new
		  {
		        mKey=tt.Key ,
				CiIpByte=a.Where(e=>e.LacCI==tt.Key).Sum(e=>e.MLen),
				CiPDCH=a.Where(e=>e.LacCI==tt.Key).Select(e=>e.CiConverType).FirstOrDefault(),
	       	    StreamingMedia=ToPercent(tt.Where (e=>e.TrafficType =="StreamingMedia").Sum (e=>e.MLen )*1.0/a.Where(e=>e.LacCI==tt.Key).Sum(e=>e.MLen)),
		        StockCategory=ToPercent(tt.Where (e=>e.TrafficType =="StockCategory").Sum (e=>e.MLen )*1.0/a.Where(e=>e.LacCI==tt.Key).Sum(e=>e.MLen)),
			    OtherCategory=ToPercent(tt.Where (e=>e.TrafficType=="OtherCategory").Sum (e=>e.MLen )*1.0/a.Where(e=>e.LacCI==tt.Key).Sum(e=>e.MLen)),
			    MMS=ToPercent(tt.Where (e=>e.TrafficType =="MMS").Sum (e=>e.MLen )*1.0/a.Where(e=>e.LacCI==tt.Key).Sum(e=>e.MLen)),
		 	    IM=ToPercent(tt.Where (e=>e.TrafficType =="IM").Sum (e=>e.MLen )*1.0/a.Where(e=>e.LacCI==tt.Key).Sum(e=>e.MLen)),
				GeneralDownloads=ToPercent(tt.Where (e=>e.TrafficType=="GeneralDownloads").Sum (e=>e.MLen )*1.0/a.Where(e=>e.LacCI==tt.Key).Sum(e=>e.MLen)),
				GameCategory=ToPercent(tt.Where (e=>e.TrafficType =="GameCategory").Sum (e=>e.MLen )*1.0/a.Where(e=>e.LacCI==tt.Key).Sum(e=>e.MLen)),
				BrowseCategory=ToPercent(tt.Where (e=>e.TrafficType =="BrowseCategory").Sum (e=>e.MLen )*1.0/a.Where(e=>e.LacCI==tt.Key).Sum(e=>e.MLen)),
				P2P=ToPercent(tt.Where (e=>e.TrafficType =="P2P").Sum (e=>e.MLen )*1.0/a.Where(e=>e.LacCI==tt.Key).Sum(e=>e.MLen)),
		  };
		  b.OrderByDescending (e=>e.CiIpByte).Dump ();
}
// Define other methods and classes here
	double ToPercent(double? d)
	{
	    if (d==null) return 0;
	    double dd=(double)d;
		return dd;
		//return double.Parse(dd.ToString("P02"));
	}
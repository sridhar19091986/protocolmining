<Query Kind="Statements">
  <Connection>
    <ID>337b631f-296e-4a3b-aa36-09f23a9a9a38</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <Database>23A</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

var a=from p in MLocatingTypes  
	 select p;

var b=from p in a
      group p by p.TrafficType   into tt
	  	  let allLen= a.Sum (e=>e.MLen )
	  select new
	  {
	        mKey=tt.Key ,
			总流量=tt.Sum (e=>e.MLen ),
			流量占比=(tt.Sum (e=>e.MLen )+0.0)/allLen,
			用户数=tt.Select (e=>e.Imsi ).Distinct ().Count (),
			平均单用户流量=tt.Sum (e=>e.MLen )/tt.Select (e=>e.Imsi ).Distinct ().Count (),
	  };
	  
	  b.OrderByDescending (e=>e.mKey).Dump ();
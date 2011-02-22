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
			室内流量=tt.Where (e=>e.CiConverClass =="是" ).Sum (e=>e.MLen ),
			室内占比=(tt.Where (e=>e.CiConverClass =="是" ).Sum (e=>e.MLen )+0.0)/allLen,
			室外流量=tt.Where (e=>e.CiConverClass !="是" ).Sum (e=>e.MLen ),
			室外占比=(tt.Where (e=>e.CiConverClass !="是" ).Sum (e=>e.MLen )+0.0)/allLen,
	  };
	  
	  b.OrderByDescending (e=>e.mKey).Dump ();
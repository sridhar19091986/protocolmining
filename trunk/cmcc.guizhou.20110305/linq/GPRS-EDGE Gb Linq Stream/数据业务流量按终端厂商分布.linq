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

var b=from p in MLocatingTypes 
      select new {p.Imsi,p.Imei,p.MsimeiClass,p.MsimeiType,p.MLen};
var d=from p in b 
      group p by p.MsimeiClass into tt    //此处分组，
	  let ipLensum=b.Sum(e=>e.MLen)
	  select new {
	  mKey=tt.Key,
	  ipLen_sum=tt.Sum(e=>e.MLen),
	  ipLen_sum_rate=(tt.Sum(e=>e.MLen)+0.0)/ipLensum
	  };  
d.OrderByDescending (e=>e.ipLen_sum).Dump ();
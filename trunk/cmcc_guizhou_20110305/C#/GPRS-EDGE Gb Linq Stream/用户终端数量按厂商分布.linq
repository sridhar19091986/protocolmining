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
      select new {p.Imsi,p.Imei,p.MsimeiClass,p.MsimeiType};
var c=b.Distinct();
var d=from p in c 
      group p by p.MsimeiClass into tt    //此处分组，
	  let imsi_sum=c.Count()
	  select new {
	  mKey=tt.Key,
	  imsi_num=tt.Count(),
	  imsi_num_rate=(tt.Count()+0.0)/imsi_sum
	  };
d.OrderByDescending (e=>e.imsi_num).Dump ();
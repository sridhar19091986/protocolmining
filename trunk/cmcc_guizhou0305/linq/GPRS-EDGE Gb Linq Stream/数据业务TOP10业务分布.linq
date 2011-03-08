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
		  mSum=tt.Sum(e=>e.MLen),
		  mUri=(from q in tt
			let t2=q.UriType.Substring (q.UriType.LastIndexOf ("-"))
			group q by t2 into qq
			select new {qq.Key ,abcSum=qq.Sum (e=>e.MLen),abcRate=(qq.Sum (e=>e.MLen)+0.0)/tt.Sum(e=>e.MLen)}).OrderByDescending(e=>e.abcSum).Take (10),
	  };
	  
	  b.OrderByDescending (e=>e.mKey).Dump ();
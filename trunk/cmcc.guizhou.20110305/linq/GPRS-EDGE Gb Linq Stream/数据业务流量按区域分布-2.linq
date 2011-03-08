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
	        城中村=tt.Where (e=>e.CiConverType =="城中村").Sum (e=>e.MLen )*1.0/allLen,
	        道路=tt.Where (e=>e.CiConverType =="道路").Sum (e=>e.MLen )*1.0/allLen,
		    高层写字楼=tt.Where (e=>e.CiConverType =="高层写字楼").Sum (e=>e.MLen )*1.0/allLen,
		    工业园区=tt.Where (e=>e.CiConverType =="工业园区").Sum (e=>e.MLen )*1.0/allLen,
	 	    集团客户=tt.Where (e=>e.CiConverType =="集团客户").Sum (e=>e.MLen )*1.0/allLen,
			居民区=tt.Where (e=>e.CiConverType =="居民区").Sum (e=>e.MLen )*1.0/allLen,
			商业中心=tt.Where (e=>e.CiConverType =="商业中心").Sum (e=>e.MLen )*1.0/allLen,
			星级酒店=tt.Where (e=>e.CiConverType =="星级酒店").Sum (e=>e.MLen )*1.0/allLen
	  };
	  
	  b.OrderByDescending (e=>e.mKey).Dump ();
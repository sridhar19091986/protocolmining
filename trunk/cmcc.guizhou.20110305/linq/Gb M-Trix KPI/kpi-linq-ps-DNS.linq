<Query Kind="Statements">
  <Connection>
    <ID>337b631f-296e-4a3b-aa36-09f23a9a9a38</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <Database>23A</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var ps= from p in Gb_DNS
	group p by p.CI into psbyfilenum
	orderby psbyfilenum.Key 
	select new {
	mFile=psbyfilenum.Key ,
	mLac=psbyfilenum.Select(e=>e.LAC).FirstOrDefault(),
//	mTime=psbyfilenum.Where (e=>e.FileNum ==psbyfilenum.Key).Select(e=>e.PacketTime.Value.AddHours(8)).Min (),
	mTime=psbyfilenum.Min(e=>e.PacketTime.Value.AddHours(-8)),
	mName="DNS_Query_Response",
	mMessage= psbyfilenum.Where (e=>e.Response!=null).Sum (e=>e.Response),
	mSuccess= (psbyfilenum.Where (e=>e.Response!=null).Sum (e=>e.Response)+0.0)/psbyfilenum.Sum(e=>e.Query),
	mDelay=psbyfilenum.Where (e=>e.Response!=null).Average(e =>e.Response_delayFirst)
	};
	ps.Dump ();
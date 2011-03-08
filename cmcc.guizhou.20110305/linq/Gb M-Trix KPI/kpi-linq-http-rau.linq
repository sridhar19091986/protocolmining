<Query Kind="Statements">
  <Connection>
    <ID>337b631f-296e-4a3b-aa36-09f23a9a9a38</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <Database>23A</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var ps= from p in Gb_Routing_Area_Updates
	group p by p.CI into psbyfilenum
	orderby psbyfilenum.Key 
	select new {
	mFile=psbyfilenum.Key ,
	mLac=psbyfilenum.Select(e=>e.LAC).FirstOrDefault(),
	//	mTime=psbyfilenum.Where (e=>e.FileNum ==psbyfilenum.Key).Select(e=>e.PacketTime.Value.AddHours(8)).Min (),
		mTime=psbyfilenum.Min(e=>e.PacketTime.Value.AddHours(-8)),
	mName="RAU_Complete",
	mMessage= psbyfilenum.Where (e=>e.RAU_Complete!=null).Sum(e=>e.RAU_Complete),
	mSuccess= (psbyfilenum.Where (e=>e.RAU_Complete!=null).Sum(e=>e.RAU_Complete)+0.0)/psbyfilenum.Sum(e=>e.RAU_Request),
	mDelay= psbyfilenum.Where (e=>e.RAU_Complete!=null).Average(e =>e.RAU_Complete_delayFirst)
	};
	ps.Dump ();
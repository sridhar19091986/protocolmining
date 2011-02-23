<Query Kind="Statements">
  <Connection>
    <ID>337b631f-296e-4a3b-aa36-09f23a9a9a38</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <Database>23A</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var ps= from p in Gb_PDP_Activations
    where p.PDP_Act_Accept!=null
	group p by p.CI into psbyfilenum
	orderby psbyfilenum.Key 
	select new {
	mFile=psbyfilenum.Key ,
	mLac=psbyfilenum.Select(e=>e.LAC).FirstOrDefault(),
    //mTime=psbyfilenum.Where (e=>e.FileNum ==psbyfilenum.Key).Select(e=>e.PacketTime.Value.AddHours(8)).Min (),
	mTime=psbyfilenum.Min(e=>e.PacketTime.Value.AddHours(-8)),
	mName="PDP_Act_Accept",
	mMessage= psbyfilenum.Where (e=>e.PDP_Act_Accept!=null).Sum(e=>e.PDP_Act_Accept),
	mSuccess= (psbyfilenum.Where (e=>e.PDP_Act_Accept!=null).Sum(e=>e.PDP_Act_Accept)+0.0)/psbyfilenum.Sum(e=>e.PDP_Act_Request),
	mDelay= psbyfilenum.Where (e=>e.PDP_Act_Accept!=null).Average(e =>e.PDP_Act_Accept_delayFirst)
//	mStatus=Gb_LLC_Discardeds.Where(e=>e.BVCI==psbyfilenum.Key).Count()
	};
	ps.OrderByDescending(e=>e.mDelay).Dump ();
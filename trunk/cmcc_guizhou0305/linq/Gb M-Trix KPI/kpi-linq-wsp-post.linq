<Query Kind="Statements">
  <Connection>
    <ID>337b631f-296e-4a3b-aa36-09f23a9a9a38</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <Database>23A</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var ps= from p in Gb_Post1xes
	group p by p.CI into psbyfilenum
	orderby psbyfilenum.Key 
	select new {
		mFile=psbyfilenum.Key ,
	    mLac=psbyfilenum.Select(e=>e.LAC).FirstOrDefault(),
        //mTime=psbyfilenum.Select(e=>e.PacketTime.Value.AddHours(8)).Min (),
    	mTime=psbyfilenum.Min(e=>e.PacketTime.Value.AddHours(-8)),
    	mName="WSP_Post_Acknowledge",
    	mMessage= psbyfilenum.Where (e=>e.Acknowledge!=null).Sum(e=>e.Acknowledge),
    	mSuccess= (psbyfilenum.Where (e=>e.Acknowledge !=null).Sum(e=>e.Acknowledge)+0.0)/psbyfilenum.Sum(e=>e.Post1x),
    	mDelay= psbyfilenum.Where (e=>e.Acknowledge !=null).Average(e =>e.Acknowledge_delayFirst)
	};
	ps.Dump ();
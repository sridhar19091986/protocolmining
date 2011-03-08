<Query Kind="Statements">
  <Connection>
    <ID>337b631f-296e-4a3b-aa36-09f23a9a9a38</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <Database>23A</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var ps= from p in Gb_Paging_PS
	group p by p.CI into psbyfilenum
	orderby psbyfilenum.Key 
	select new 
	{
		mFile=psbyfilenum.Key ,
	    mLac=psbyfilenum.Select(e=>e.LAC).FirstOrDefault(),
        //mTime=psbyfilenum.Select(e=>e.PacketTime.Value.AddHours(8)).Min (),
    	mTime=psbyfilenum.Min (e=>e.PacketTime.Value.AddHours(-8)),
        //mName="Paging_TypePS_AnyUplinkPDU",
 	    mMessage= psbyfilenum.Sum (e=>e.Paging_Type_PS),   
	    mRepeat= psbyfilenum.Sum (e=>e.PS_Paging_Repeat),
	    mRespone= psbyfilenum.Sum (e=>e.Any_Uplink_PDU ),
	    mRepeatSucc= (psbyfilenum.Sum (e=>e.PS_Paging_Repeat)+0.0)/psbyfilenum.Sum (e=>e.Any_Uplink_PDU ),
	    mResponeSucc= (psbyfilenum.Sum (e=>e.Any_Uplink_PDU )+0.0)/psbyfilenum.Sum (e=>e.Paging_Type_PS),
	    mDelay=psbyfilenum.Average (e =>e.Any_Uplink_PDU_delayFirst)
	};
	ps.Dump ();
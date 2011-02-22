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

var readGb=IP_streams.Where(e=>e.FileNum<=3);

TimeSpan timer=readGb.Max(e=>e.PacketTime).Value- readGb.Min(e=>e.PacketTime).Value;
var mTime=timer.TotalSeconds;
var tt=readGb.Min(e=>e.PacketTime).Value.ToString()+"~"+readGb.Max(e=>e.PacketTime).Value.ToString()+"~"+mTime.ToString();
tt.Dump();

this.Connection.ConnectionString.Dump();
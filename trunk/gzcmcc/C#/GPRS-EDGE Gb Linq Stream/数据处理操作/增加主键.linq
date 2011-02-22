<Query Kind="SQL">
  <Connection>
    <ID>337b631f-296e-4a3b-aa36-09f23a9a9a38</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <Database>23A</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

--alter table MLocatingType alter column MLocatingType_id int not null
alter table MLocatingType alter column LacCI nvarchar(50) not null
alter table MLocatingType alter column FileNum int not null
alter table MLocatingType alter column Frame int not null
alter table  MLocatingType add constraint MLocatingType_id_pk primary key(LacCI,FileNum,Frame)


--DBCC SHRINKDATABASE ( sz_23A_20100524_11)
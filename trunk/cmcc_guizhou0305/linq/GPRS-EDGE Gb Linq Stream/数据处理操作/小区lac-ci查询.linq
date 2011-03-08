<Query Kind="SQL">
  <Connection>
    <ID>337b631f-296e-4a3b-aa36-09f23a9a9a38</ID>
    <Server>.\SQLEXPRESS</Server>
    <Persist>true</Persist>
    <Database>IP_Stream</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>


--useIP_Stream
--MLocatingTypes.Where(e=>e.LacCI=="10137-3881").Take (50)

select *
from ciCoverType
where ciName='富士康北d1'
or ciName='富士康d1'
or ciName='富士康d2'
or ciName='富士康d3'
or ciName='富士康m1'
or ciName='富士康m2'
or ciName='富士康m3'
or ciName='富士康北d2'
or ciName='富士康北d3'
or ciName='富士康北m1'
or ciName='富士康北m2'
or ciName='富士康北m3'
or ciName='富士康二d1'
or ciName='富士康二d2'
or ciName='富士康二d3'
or ciName='富士康二m1'
or ciName='富士康二m2'
or ciName='富士康二m3'
or ciName='富士康十三L1'
or ciName='富士康十三L2'
or ciName='富士康十三L3'
<Query Kind="SQL">
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>


 
-- Region Parameters
DECLARE @p0 NVarChar ( 1000 ) SET @p0 = '10167-3551'
DECLARE @p1 NVarChar ( 1000 ) SET @p1 = '10167-3552'
DECLARE @p2 NVarChar ( 1000 ) SET @p2 = '10167-3553'
DECLARE @p3 NVarChar ( 1000 ) SET @p3 = '10167-3561'
DECLARE @p4 NVarChar ( 1000 ) SET @p4 = '10167-3562'
DECLARE @p5 NVarChar ( 1000 ) SET @p5 = '10167-3563'
DECLARE @p6 NVarChar ( 1000 ) SET @p6 = '10137-3881'
DECLARE @p7 NVarChar ( 1000 ) SET @p7 = '10137-3882'
DECLARE @p8 NVarChar ( 1000 ) SET @p8 = '10137-3883'
DECLARE @p9 NVarChar ( 1000 ) SET @p9 = '10137-3981'
DECLARE @p10 NVarChar ( 1000 ) SET @p10 = '10137-3982'
DECLARE @p11 NVarChar ( 1000 ) SET @p11 = '10137-3983'
DECLARE @p12 NVarChar ( 1000 ) SET @p12 = '10167-3571'
DECLARE @p13 NVarChar ( 1000 ) SET @p13 = '10167-3572'
DECLARE @p14 NVarChar ( 1000 ) SET @p14 = '10167-3573'
DECLARE @p15 NVarChar ( 1000 ) SET @p15 = '10167-3751'
DECLARE @p16 NVarChar ( 1000 ) SET @p16 = '10167-3752'
DECLARE @p17 NVarChar ( 1000 ) SET @p17 = '10167-3753'
DECLARE @p18 NVarChar ( 1000 ) SET @p18 = '10137-3561'
DECLARE @p19 NVarChar ( 1000 ) SET @p19 = '10137-3562'
DECLARE @p20 NVarChar ( 1000 ) SET @p20 = '10137-3563'
-- EndRegion
--select * into  FuShiKang .. [mLocatingType] from
--sz_23A_20100524_11 .. [mLocatingType] where 1<>1
;
insert into FuShiKang .. [mLocatingType]
SELECT [fileNum]
	  ,[frame]
	  ,[bvci]
	  ,[lacCI]
	  ,[ciConverType]
	  ,[ciConverClass]
	  ,[tlli]
	  ,[imsi]
	  ,[imei]
	  ,[msimeiType]
	  ,[msimeiClass]
	  ,[trafficType]
	  ,[uriType]
	  ,[protocolType]
	  ,[portType]
	  ,[responseType]
	  ,[mLen]
FROM sz_23A_20100524_11 .. [mLocatingType] AS [t0]
WHERE ( [t0] . [lacCI] = @p0 ) OR ( [t0] . [lacCI] = @p1 ) OR ( [t0] . [lacCI] = @p2 ) OR ( [t0] . [lacCI] = @p3 ) OR ( [t0] . [lacCI] = @p4 ) OR ( [t0] . [lacCI] = @p5 ) OR ( [t0] . [lacCI] = @p6 ) OR ( [t0] . [lacCI] = @p7 ) OR ( [t0] . [lacCI] = @p8 ) OR ( [t0] . [lacCI] = @p9 ) OR ( [t0] . [lacCI] = @p10 ) OR ( [t0] . [lacCI] = @p11 ) OR ( [t0] . [lacCI] = @p12 ) OR ( [t0] . [lacCI] = @p13 ) OR ( [t0] . [lacCI] = @p14 ) OR ( [t0] . [lacCI] = @p15 ) OR ( [t0] . [lacCI] = @p16 ) OR ( [t0] . [lacCI] = @p17 ) OR ( [t0] . [lacCI] = @p18 ) OR ( [t0] . [lacCI] = @p19 ) OR ( [t0] . [lacCI] = @p20 )
;
--
insert into FuShiKang .. [mLocatingType]
SELECT [fileNum]
	  ,[frame]
	  ,[bvci]
	  ,[lacCI]
	  ,[ciConverType]
	  ,[ciConverClass]
	  ,[tlli]
	  ,[imsi]
	  ,[imei]
	  ,[msimeiType]
	  ,[msimeiClass]
	  ,[trafficType]
	  ,[uriType]
	  ,[protocolType]
	  ,[portType]
	  ,[responseType]
	  ,[mLen]
FROM sz_17a_20100818_18 .. [mLocatingType] AS [t0]
WHERE ( [t0] . [lacCI] = @p0 ) OR ( [t0] . [lacCI] = @p1 ) OR ( [t0] . [lacCI] = @p2 ) OR ( [t0] . [lacCI] = @p3 ) OR ( [t0] . [lacCI] = @p4 ) OR ( [t0] . [lacCI] = @p5 ) OR ( [t0] . [lacCI] = @p6 ) OR ( [t0] . [lacCI] = @p7 ) OR ( [t0] . [lacCI] = @p8 ) OR ( [t0] . [lacCI] = @p9 ) OR ( [t0] . [lacCI] = @p10 ) OR ( [t0] . [lacCI] = @p11 ) OR ( [t0] . [lacCI] = @p12 ) OR ( [t0] . [lacCI] = @p13 ) OR ( [t0] . [lacCI] = @p14 ) OR ( [t0] . [lacCI] = @p15 ) OR ( [t0] . [lacCI] = @p16 ) OR ( [t0] . [lacCI] = @p17 ) OR ( [t0] . [lacCI] = @p18 ) OR ( [t0] . [lacCI] = @p19 ) OR ( [t0] . [lacCI] = @p20 )
;
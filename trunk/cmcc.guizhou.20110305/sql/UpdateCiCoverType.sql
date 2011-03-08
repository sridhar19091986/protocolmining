
USE [IP_Stream]
GO

/****** Object:  Table [dbo].[ciCoverType]    Script Date: 03/03/2011 11:38:20 ******/
IF  EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ciCoverType]') AND type in (N'U'))
DROP TABLE [dbo].[ciCoverType]
GO
USE [IP_Stream]
GO	
SELECT IDENTITY(int, 1,1) AS ciCoverType_id,* into ciCoverType
from (select lac+'-'+ci as lacCI,ci_name as ciName,
available_pdch as ciCoverModel,use_pdch as ciCoverClass
from dbo.ciPdchBulk
where stat_time='16/02/2011 09:00:00') as a
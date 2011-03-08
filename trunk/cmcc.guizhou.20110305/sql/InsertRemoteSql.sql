
USE [IP_Stream]
GO

/****** Object:  Table [dbo].[ciCoverType]    Script Date: 02/23/2011 10:38:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ciCoverType] (
      [ciCoverType_id] [numeric] (18, 0) IDENTITY(1 ,1) NOT NULL,
      [lacCI] [nvarchar] (50) NULL,
      [ciName] [nvarchar] (500) NULL,
      [ciCoverModel] [nvarchar] (50) NULL,
      [ciCoverClass] [nvarchar] (5) NULL,
 CONSTRAINT [PK_ciCoverType_id] PRIMARY KEY NONCLUSTERED
(
      [ciCoverType_id] ASC
)WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF , IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON ) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [IP_Stream]
GO

/****** Object:  Table [dbo].[imeiType]    Script Date: 02/23/2011 10:38:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[imeiType] (
      [imeiType_id] [decimal] (18, 0) IDENTITY(1 ,1) NOT NULL,
      [imei] [nvarchar] (50) NULL,
      [imeiFactory] [nvarchar] (50) NULL,
      [imeiModel] [nvarchar] (500) NULL,
      [imeiClass] [nvarchar] (50) NULL,
 CONSTRAINT [PK_dbo.imeiType] PRIMARY KEY CLUSTERED
(
      [imeiType_id] ASC
)WITH ( PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF , IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON ) ON [PRIMARY]
) ON [PRIMARY]

GO






USE [IP_Stream]
GO
insert opendatasource ('SQLOLEDB', 'Data Source=192.168.2.105;User ID=sa;password=1234').IP_Stream. dbo.imeiType( [imei],[imeiFactory] ,[imeiModel], [imeiClass])
select [imei], [imeiFactory],[imeiModel] ,[imeiClass]
FROM [IP_Stream]. [dbo].[imeiType]
order by imeiType_id

GO
insert opendatasource ('SQLOLEDB', 'Data Source=192.168.2.105;User ID=sa;password=1234').[IP_Stream]. [dbo].[ciCoverType] ([lacCI], [ciName],[ciCoverModel] ,[ciCoverClass])
select [lacCI], [ciName],[ciCoverModel] ,[ciCoverClass]
FROM [IP_Stream]. [dbo].[ciCoverType]
order by ciCoverType_id

CREATE DATABASE TritonExpressVTDb
GO

USE [TritonExpressVTDb]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 2020/11/07 20:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Vehicle_Registration_Number] [int] IDENTITY(1,1) NOT NULL,
	[Vehicle_Number_Plate] [varchar](255) NOT NULL,
	[Vehicle_Make] [varchar](255) NOT NULL,
	[Vehicle_Model] [varchar](255) NOT NULL,
	[Branch] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[Vehicle_Registration_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Waybill](
	[WaybillId] [int] IDENTITY(1,1) NOT NULL,
	[Waybill_Total_weight] [varchar](255) NOT NULL,
	[Waybil_Total_Parcels_Allocated] [varchar](255) NOT NULL,
	[Vehicle_Registration_Number] [int] NOT NULL,
	[Vehicle_Number_Plate] [nvarchar](max) NULL,
 CONSTRAINT [PK_Waybill] PRIMARY KEY CLUSTERED 
(
	[WaybillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Waybill]  WITH CHECK ADD  CONSTRAINT [FK_Waybill_Vehicles_Vehicle_Registration_Number] FOREIGN KEY([Vehicle_Registration_Number])
REFERENCES [dbo].[Vehicles] ([Vehicle_Registration_Number])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Waybill] CHECK CONSTRAINT [FK_Waybill_Vehicles_Vehicle_Registration_Number]
GO

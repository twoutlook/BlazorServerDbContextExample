USE [TaiWei]
GO

SELECT [id]
      ,[cticketcode]
      ,[reason]
      ,[cstatus]
      ,[createowner]
      ,[createownername]
      ,[createtime]
      ,[reviewuser]
      ,[reviewtime]
      ,[lastupdateuser]
      ,[lastupdatetime]
      ,[cstatusname]
  FROM [dbo].[V2_STOCK_CURRENT_ADJUST]

GO


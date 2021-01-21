USE [TaiWei]
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V2_OUTASN'
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V2_OUTASN'
GO

/****** Object:  View [dbo].[V2_OUTASN]    Script Date: 2021/1/21 19:44:45 ******/
DROP VIEW [dbo].[V2_OUTASN]
GO

/****** Object:  View [dbo].[V2_OUTASN]    Script Date: 2021/1/21 19:44:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* 
SELECT * FROM BASE_OPERATOR
SELECT * FROM SYS_PARAMETER WHERE flag_type = 'OS'
- SELECT * FROM V_OUTASNList*/
CREATE VIEW [dbo].[V2_OUTASN]
AS
SELECT T1.cticketcode, T1.itype, T5.TYPENAME, T1.cstatus, T2.flag_name AS cstatusname, T1.reasoncode, T1.ccreateownercode, T4.coperatorname AS ccreateownername, T1.dcreatetime
FROM     dbo.OUTASN AS T1 INNER JOIN
                  dbo.SYS_PARAMETER AS T2 ON T1.cstatus = T2.flag_id AND T2.flag_type = 'OS' LEFT OUTER JOIN
                  dbo.BASE_OPERATOR AS T4 ON T1.ccreateownercode = T4.caccountid LEFT OUTER JOIN
                  dbo.V_INOutType AS T5 ON T1.itype = T5.CERPCODE
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "T1"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T2"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 338
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T4"
            Begin Extent = 
               Top = 343
               Left = 48
               Bottom = 506
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T5"
            Begin Extent = 
               Top = 7
               Left = 313
               Bottom = 170
               Right = 627
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V2_OUTASN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V2_OUTASN'
GO


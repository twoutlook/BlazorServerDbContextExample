USE [TaiWei]
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OUTASNList'
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OUTASNList'
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OUTASNList'
GO

/****** Object:  View [dbo].[V_OUTASNList]    Script Date: 2021/1/21 17:20:15 ******/
DROP VIEW [dbo].[V_OUTASNList]
GO

/****** Object:  View [dbo].[V_OUTASNList]    Script Date: 2021/1/21 17:20:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[V_OUTASNList]

AS

SELECT a.* FROM (SELECT   A.id,isnull(bo.coperatorname,A.ccreateownercode) as ccreateownercode, A.dcreatetime, A.cauditpersoncode, A.dauditdate, A.cticketcode, A.cerpcode, A.cstatus, 

                p.flag_name, A.itype, ot.typename, A.cdefine2, ISNULL(A.is_merge,0) is_merge, ISNULL(INFO.start_date, 

                CASE WHEN A.is_merge = '1' THEN

                    (SELECT   ini.start_date

                     FROM      dbo.IN_MO_INFO ini

                     WHERE   ini.wo =

                                         (SELECT   TOP 1 o.cerpcode

                                          FROM      dbo.OUTASN o

                                          WHERE   o.merge_id = a.merge_id AND o.is_merge = '0')) ELSE NULL END) AS START_DATES, 

                ISNULL(INFO.shift, CASE WHEN A.is_merge = '1' THEN

                    (SELECT   ini.shift

                     FROM      dbo.IN_MO_INFO ini

                     WHERE   ini.wo =

                                         (SELECT   TOP 1 o.cerpcode

                                          FROM      dbo.OUTASN o

                                          WHERE   o.merge_id = a.merge_id AND o.is_merge = '0')) ELSE '' END) AS SHIFTS, 

                CASE WHEN A.is_merge = '1' THEN 'Y' ELSE 'N' END AS is_mergename, CASE WHEN A.idefine5 IS NULL 

                THEN 0 WHEN A.idefine5 = 0 THEN 0 WHEN A.idefine5 = 1 THEN 1 END AS IsSpecialWipIssue, 

                CASE WHEN A.special_out = '1' THEN '是' ELSE '否' END AS special_out, CASE WHEN A.out_vendor = '0' AND 

                A.is_smt = 1 AND A.site = 'A' THEN '厂内SMT-A' WHEN A.out_vendor = '0' AND A.is_smt = 1 AND 

                A.site = 'B' THEN '厂内SMT-B' WHEN A.out_vendor = '0' AND A.is_smt = 0 AND A.site IS NULL 

                THEN '厂内非SMT' WHEN A.out_vendor != '0' AND A.is_smt = 1 AND A.site IS NULL 

                THEN '厂外SMT' WHEN A.out_vendor != '0' AND A.is_smt = 0 AND A.site IS NULL THEN '厂外非SMT' END AS smttype, 

                dbo.Fun_GetCount_FromOutasnd(A.id) AS is_cj, 

                CASE WHEN A.cstatus = '0' THEN '未处理' WHEN A.cstatus = '1' THEN '已指引' WHEN A.cstatus = '2' THEN '拣货中' WHEN

                 A.cstatus = '3' THEN '已完成' WHEN A.cstatus = '4' THEN '已合并' WHEN A.cstatus = '5' THEN '已结案' WHEN A.cstatus

                 = '6' THEN '已撤销' END AS cstatusname, CASE WHEN A.out_vendor = '0' AND A.is_smt = 1 AND 

                A.site = 'A' THEN '0' WHEN A.out_vendor = '0' AND A.is_smt = 1 AND A.site = 'B' THEN '1' WHEN A.out_vendor = '0' AND 

                A.is_smt = 0 AND A.site IS NULL THEN '2' WHEN A.out_vendor != '0' AND A.is_smt = 1 AND A.site IS NULL 

                THEN '3' WHEN A.out_vendor != '0' AND A.is_smt = 0 AND A.site IS NULL THEN '4' END AS smttypeint, A.cso,A.worktype

FROM      dbo.OUTASN AS A LEFT OUTER JOIN

                dbo.IN_MO_INFO AS INFO ON A.cerpcode = INFO.wo LEFT OUTER JOIN

                dbo.SYS_PARAMETER AS p ON A.cstatus = p.flag_id AND p.flag_type = 'OS' LEFT OUTER JOIN

                dbo.OUTTYPE AS ot ON A.itype = ot.cerpcode
				left join BASE_OPERATOR bo on A.ccreateownercode = bo.caccountid
				) a











GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[20] 4[15] 2[28] 3) )"
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
         Begin Table = "A"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 145
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "INFO"
            Begin Extent = 
               Top = 6
               Left = 272
               Bottom = 145
               Right = 450
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 488
               Bottom = 145
               Right = 636
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ot"
            Begin Extent = 
               Top = 150
               Left = 38
               Bottom = 289
               Right = 281
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
      Begin ColumnWidths = 23
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OUTASNList'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'= 1440
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OUTASNList'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OUTASNList'
GO


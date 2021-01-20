USE [TaiWei]
GO

/****** Object:  View [dbo].[V2_OUTBILL]    Script Date: 2021/1/20 18:59:41 ******/
DROP VIEW [dbo].[V2_OUTBILL]
GO

/****** Object:  View [dbo].[V2_OUTBILL]    Script Date: 2021/1/20 18:59:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V2_OUTBILL]
AS
SELECT 

T1.cticketcode,
T3.cticketcode coutasn,

T4.TYPENAME outtype,

ISNULL(T2.coperatorname, CONCAT ( '(',T1.ccreateownercode,')')) ccreateownername,
T1.dindate,
T1.debittime

,T1.cstatus,T5.flag_name cstatusname


FROM OUTBILL T1
INNER JOIN OUTASN T3
ON T1.coutasnid = T3.id
INNER JOIN V_INOutType T4
ON T1.otype = T4.CERPCODE

INNER JOIN SYS_PARAMETER T5
ON T5.flag_type= 'OUTBILL' AND T5.flag_id = T1.cstatus

LEFT JOIN BASE_OPERATOR   T2
ON T1.ccreateownercode = T2.caccountid
GO


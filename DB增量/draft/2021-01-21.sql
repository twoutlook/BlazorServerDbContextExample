select * from V_INASN


/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
T1.cticketcode,
T1.itype,
T3.TYPENAME,
T1.reasoncode,
T1.reasoncontent,
T1.ccreateownercode,
* FROM INASN T1
INNER JOIN INASN_D T2
ON T1.id = T2.id
--WHERE T1.cticketcode >='Inasn201228'

INNER JOIN V_INOutType T3
ON T1.itype = T3.CERPCODE

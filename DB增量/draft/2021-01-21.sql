--


/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
T1.cticketcode,
T1.itype,
T3.TYPENAME,
T1.reasoncode,
T1.ccreateownercode,
T4.
* FROM OUTASN T1


INNER JOIN V_INOutType T3
ON T1.itype = T3.CERPCODE
LEFT JOIN BASE_OPERATOR T4
ON T1.ccreateownercode=T4.caccountid
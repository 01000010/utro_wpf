-- Read the data from the excel file and write it into the database --

--sp_configure 'show advanced options', 1;
--RECONFIGURE;
--GO
--sp_configure 'Ad Hoc Distributed Queries', 1;
--RECONFIGURE
--GO
--EXEC sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'AllowInProcess', 1   
--EXEC sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'DynamicParam', 1

--USE izdelie;
--GO
--SELECT * INTO dbo.TKANI_TEMP
--FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
--    'Excel 12.0; Database=nomenklatura.xlsx', [Ткани$])
--GO

--USE izdelie;
--GO
--SELECT * INTO dbo.FURNI_TEMP
--FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
--    'Excel 12.0; Database=nomenklatura.xlsx', [Фурнитура$])
--GO

--USE izdelie;
--GO
--SELECT * INTO dbo.IZD_TEMP
--FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
--    'Excel 12.0; Database=nomenklatura.xlsx', [Изделия$])
--GO

--USE izdelie;
--GO
--INSERT INTO DBO.ТКАНЬ
--    SELECT * FROM TKANI_TEMP
--GO

--USE izdelie;
--GO
--INSERT INTO DBO.ФУРНИТУРА
--    SELECT * FROM FURNI_TEMP
--GO

--USE izdelie;
--GO
--INSERT INTO DBO.ИЗДЕЛИЕ
--    SELECT * FROM IZD_TEMP
--GO

﻿USE [SecurityGuard]
GO
 

DECLARE @SQL NVARCHAR(MAX)	
 
SELECT
	@SQL = '-- Start '
 
WHILE @SQL > ''
BEGIN
	SELECT
		@SQL = ''
 
	SELECT
		@SQL = @SQL + 
			CASE
				WHEN DATALENGTH(@SQL) < 7500 THEN
					N'alter table ' + QUOTENAME(schema_name(schema_id)) 
					+ N'.' 
					+ QUOTENAME(OBJECT_NAME(parent_object_id)) 
					+ N' drop constraint ' 
					+ name
					+ CHAR(13) + CHAR(10) --+ 'GO' + CHAR(13) + CHAR(10)
				ELSE
					''
			END
	FROM
		sys.foreign_keys
 
	PRINT @SQL
	EXEC SP_EXECUTESQL @SQL
	PRINT '--------------'
END
 
GO
 
----------------------
-- Uncomment the line below to drop all tables too   
PRINT 'sp_msforeachtable  drop table ?'   
exec sp_msforeachtable 'drop table ?'
 

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertLog]') AND type IN ( N'P', N'PC' ) ) DROP PROCEDURE [dbo].[InsertLog] 
GO  

 


print ' ' 
print 'finished dropping all tables'
print ' '
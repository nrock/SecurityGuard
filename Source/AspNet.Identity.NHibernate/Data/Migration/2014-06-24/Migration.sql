USE [SecurityGuard];
GO 



  
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'config')
BEGIN
    Exec('CREATE SCHEMA [config]')
end    
GO      


IF not  EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Configuration]')  AND type IN ( N'U' ) )  
begin
	print 'creating [Configuration]'  
 
	CREATE TABLE [dbo].[Configuration](
		[Id] [int] IDENTITY(1,1) NOT NULL,
        [InsertDateTime] [datetime] NOT NULL Default(GetUTCDate()),
		[UpdateDateTime] [datetime] NOT NULL Default(GetUTCDate()) ,
		[Name] [nvarchar](50) NULL,
		[Value] [nvarchar](1000) NULL 
	PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
	    
	INSERT INTO  [dbo].[Configuration] ( [Name], [Value] ) VALUES   
	('StartDate', '10/31/2013'),
	('End Date', '12/25/2013'); 
END 

 
IF not  EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[AspNetUser]')  AND type IN ( N'U' ) )  
begin
	print 'creating [AspNetUser]'   
	CREATE TABLE [dbo].AspNetUser(
		[Id] [int] IDENTITY(1,1) NOT NULL,
        [InsertDateTime] [datetime] NOT NULL Default(GetUTCDate()),
		[UpdateDateTime] [datetime] NOT NULL Default(GetUTCDate()) , 
		[Username] [varchar](50) NOT NULL,
		[Email] [varchar](50) NOT NULL
	 CONSTRAINT [PK_Dealer] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY] 
	  
END
GO 

INSERT INTO [AspNetUser]  ( [Username] ,[Email])
select 'a@a.com' , 'a@a.com'   union all 
select 'b@b.com' , 'b@b.com'   union all 
select 'c@c.com' , 'c@c.com'    
GO


 

PRINT '		===== DONE MAIN MIGRATION ===== '

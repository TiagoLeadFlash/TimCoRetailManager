CREATE TABLE [dbo].[User]
(
	[Id] Nvarchar(128) not null Primary key,
	[FirstName] nvarchar(50) not null, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(256) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(),

)

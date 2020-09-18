CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)
AS
BEGIN
	set nocount on;

	SELECT id, FirstName, LastName, EmailAddress, CreateDate
	FROM [dbo].[User]
	WHERE Id = @Id

END
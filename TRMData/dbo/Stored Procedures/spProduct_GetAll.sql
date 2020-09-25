CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
BEGIN
	set nocount on;

	SELECT [Id], [ProductName], [Description], [RetailPrice], [QuantityInStock]
	FROM Dbo.Product
	ORDER by ProductName 
END 
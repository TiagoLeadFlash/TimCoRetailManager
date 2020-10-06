CREATE PROCEDURE [dbo].[spSale_SaleReport]
AS
BEGIN
	set nocount on;

	SELECT [s].[SaleDate], [s].[SubTotal], [s].[Tax], [s].[Total] , u.FirstName, u.LastName, u.EmailAddress 
	FROM dbo.sale s
		inner join dbo.[User] u on s.CashierID = u.id

END
CREATE PROCEDURE [dbo].[spSale_Lookup]
	@CashierId nvarchar(128),
	@SaleDate datetime2
AS
BEGIN
	SELECT Id
	FROM dbo.Sale 
	WHERE CashierID = @CashierId
		and SaleDate = @SaleDate 
END 

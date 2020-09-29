CREATE PROCEDURE [dbo].[spSaleDetail_Insert]
	@SaleId int,
	@ProductID int,
	@Quantity int,
	@PurchasePrice money,
	@Tax money

AS
BEGIN
	SET nocount on;

	Insert into dbo.SaleDetail(SaleID, ProductID, Quantity, PurchasePrice, Tax)
	values (@SaleId, @ProductID, @Quantity, @PurchasePrice, @Tax)
END



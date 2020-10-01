CREATE PROCEDURE [dbo].[spSale_Insert]
	@id int,
	@CashierId nvarchar(128),
	@SaleDate datetime,
	@SubTotal money,
	@Tax money,
	@Total money
AS
BEGIN
	SET nocount on;

	INSERT INTO dbo.Sale(CashierID, SaleDate, SubTotal, Tax, Total)
	values (@CashierId, @SaleDate, @SubTotal, @Tax, @Total)

	select @id = SCOPE_IDENTITY();
END 

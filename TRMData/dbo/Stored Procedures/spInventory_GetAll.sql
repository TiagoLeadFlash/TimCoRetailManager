CREATE PROCEDURE [dbo].[spInventory_GetAll]

AS
BEGIN
	 set nocount on;

	 select [Id], [ProductID], [Quantity], [PurchasePrice], [PurchaseDate] 
	 from 
	 dbo.Inventory;
END

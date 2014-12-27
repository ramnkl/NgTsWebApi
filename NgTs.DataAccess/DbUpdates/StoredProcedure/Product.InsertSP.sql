 
--This auto genrated code please do not alter  12/26/2014 11:01:57
--SP Generation
 IF  EXISTS ( SELECT 'X' FROM SYSOBJECTS WHERE Xtype='P' AND  NAME ='ProductInsert')
BEGIN
DROP PROCEDURE ProductInsert
END
GO
CREATE PROCEDURE ProductInsert
(
@ProductId int ,
@ProductName varchar(50) ,
@ProductDesc varchar(50) ,
@Price decimal (12,2) 
)
AS
BEGIN
INSERT INTO Product (
	[ProductId],
	[ProductName],
	[ProductDesc],
	[Price]
)
Values (
	@ProductId,
	@ProductName,
	@ProductDesc,
	@Price
)
END
GO
--Auto generated for Update sp 12/26/2014 11:01:57 AM
 IF  EXISTS ( SELECT 'X' FROM SYSOBJECTS WHERE Xtype='P' AND  NAME ='ProductUpdate')
BEGIN
DROP PROCEDURE ProductUpdate
END
GO
CREATE PROCEDURE ProductUpdate
(
@ProductId int ,
@ProductName varchar(50) ,
@ProductDesc varchar(50) ,
@Price decimal (12,2) 
)
AS
BEGIN
UPDATE   [Product] SET 
	[ProductId]=@ProductId,
	[ProductName]=@ProductName,
	[ProductDesc]=@ProductDesc,
	[Price]=@Price
WHERE [ProductId] = @ProductId
END
GO
--Auto generated for Update sp 12/26/2014 11:01:57 AM
 IF  EXISTS ( SELECT 'X' FROM SYSOBJECTS WHERE Xtype='P' AND  NAME ='ProductGetAll')
BEGIN
DROP PROCEDURE ProductGetAll
END
GO
CREATE PROCEDURE ProductGetAll
AS
BEGIN
SELECT 
	[ProductId],
	[ProductName],
	[ProductDesc],
	[Price]
FROM [Product]
END
GO
--Auto generated for get by Id sp 12/26/2014 11:01:57 AM
 IF  EXISTS ( SELECT 'X' FROM SYSOBJECTS WHERE Xtype='P' AND  NAME ='ProductLoadByProductId')
BEGIN
DROP PROCEDURE ProductLoadByProductId
END
GO
CREATE PROCEDURE ProductLoadByProductId
(
@ProductId int
)
AS
BEGIN
SELECT
	[ProductId],
	[ProductName],
	[ProductDesc],
	[Price]
FROM [Product]
WHERE [ProductId] = @ProductId
END

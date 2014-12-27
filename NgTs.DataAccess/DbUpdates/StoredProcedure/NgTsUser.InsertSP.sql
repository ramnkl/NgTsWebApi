 
--This auto genrated code please do not alter  12/26/2014 11:01:57
--SP Generation
 IF  EXISTS ( SELECT 'X' FROM SYSOBJECTS WHERE Xtype='P' AND  NAME ='NgTsUserInsert')
BEGIN
DROP PROCEDURE NgTsUserInsert
END
GO
CREATE PROCEDURE NgTsUserInsert
(
@UserId int ,
@UserName varchar(50) ,
@UserCode varchar(50) ,
@FirstName varchar(50) ,
@LastName varchar(50) ,
@Password varchar(50) 
)
AS
BEGIN
INSERT INTO NgTsUser (
	[UserId],
	[UserName],
	[UserCode],
	[FirstName],
	[LastName],
	[Password]
)
Values (
	@UserId,
	@UserName,
	@UserCode,
	@FirstName,
	@LastName,
	@Password
)
END
GO
--Auto generated for Update sp 12/26/2014 11:01:57 AM
 IF  EXISTS ( SELECT 'X' FROM SYSOBJECTS WHERE Xtype='P' AND  NAME ='NgTsUserUpdate')
BEGIN
DROP PROCEDURE NgTsUserUpdate
END
GO
CREATE PROCEDURE NgTsUserUpdate
(
@UserId int ,
@UserName varchar(50) ,
@UserCode varchar(50) ,
@FirstName varchar(50) ,
@LastName varchar(50) ,
@Password varchar(50) 
)
AS
BEGIN
UPDATE   [NgTsUser] SET 
	[UserId]=@UserId,
	[UserName]=@UserName,
	[UserCode]=@UserCode,
	[FirstName]=@FirstName,
	[LastName]=@LastName,
	[Password]=@Password
WHERE [UserId] = @UserId
END
GO
--Auto generated for Update sp 12/26/2014 11:01:57 AM
 IF  EXISTS ( SELECT 'X' FROM SYSOBJECTS WHERE Xtype='P' AND  NAME ='NgTsUserGetAll')
BEGIN
DROP PROCEDURE NgTsUserGetAll
END
GO
CREATE PROCEDURE NgTsUserGetAll
AS
BEGIN
SELECT 
	[UserId],
	[UserName],
	[UserCode],
	[FirstName],
	[LastName],
	[Password]
FROM [NgTsUser]
END
GO
--Auto generated for get by Id sp 12/26/2014 11:01:57 AM
 IF  EXISTS ( SELECT 'X' FROM SYSOBJECTS WHERE Xtype='P' AND  NAME ='NgTsUserLoadByUserId')
BEGIN
DROP PROCEDURE NgTsUserLoadByUserId
END
GO
CREATE PROCEDURE NgTsUserLoadByUserId
(
@UserId int
)
AS
BEGIN
SELECT
	[UserId],
	[UserName],
	[UserCode],
	[FirstName],
	[LastName],
	[Password]
FROM [NgTsUser]
WHERE [UserId] = @UserId
END

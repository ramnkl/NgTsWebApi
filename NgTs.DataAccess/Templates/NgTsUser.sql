DROP PROCEDURE IF EXISTS EZEE_SP_NgTsUser_IUD
DELIMITER $$
CREATE PROCEDURE EZEE_SP_NgTsUser_IUD
(
	pUserName VARCHAR(50)
	,pUserCode VARCHAR(50)
	,pFirstName VARCHAR(50)
	,pLastName VARCHAR(50)
	,pPassword VARCHAR(50)
	, OUT pitRowCount INT)
 /* 
* Procedure Name    : EZEE_SP_NgTsUser_IUD
* 
* Purpose       : Insert /Update /DeleteNgTsUser Table 
*
* Input        : None
*
* Output        : 
* 						 Affected Rows
*
* Returns       : None
*
* Dependencies
*
*   Tables      : NgTsUser
*
*   Functions    : None
*
*   Procedures    : EZEE_SP_SEQUENCE_GENERATOR
*
* Revision History:
*
*  
*
*----------------------------------------------------------------------------------------------------
* Variable Declare
*-----------------------------------------------------------------------------------------------------
*-----------------------------------------------------------------------------------------------------
*/
BEGIN
/*
*-----------------------------------------------------------------------------------------------------
* Variable Initialized
*------------------------------------------------------------------------------------------------------
*/
SET	pitRowCount  = 0;
/*
*-----------------------------------------------------------------------------------------------------
*/
/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
/* -------------------------------------------------------------------------------------
/NgTsUser Update
  -------------------------------------------------------------------------------------
   */ 
IF (pactive_flag = 1 AND EZEE_FN_ISNOTNULL(pcode)  ) THEN
	UPDATE NgTsUser
	SET
		UserName = pUserName,
		UserCode = pUserCode,
		FirstName = pFirstName,
		LastName = pLastName,
		Password = pPassword where `code`=pcode  
SELECT ROW_COUNT() INTO pitRowCount;
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
 ELSEIF (pactive_flag = 1 AND EZEE_FN_ISNULL(pcode) ) THEN
INSERT INTONgTsUser
(
	UserName
	 ,UserCode
	 ,FirstName
	 ,LastName
	 ,Password
	 )
VALUES(
	pUserName
	 ,pUserCode
	 ,pFirstName
	 ,pLastName
	 ,pPassword
	 );SELECT ROW_COUNT() INTO pitRowCount;
	/* -------------------------------------------------------------------------------------*/
/* DELETE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
/* -------------------------------------------------------------------------------------
/    NgTsUser DELETE
  -------------------------------------------------------------------------------------  */
  	ELSEIF (pactive_flag != 1 AND EZEE_FN_ISNOTNULL(pcode)) THEN
IF (pactive_flag = 9) THEN
	SET pactive_flag = 1;
END IF;
UPDATE NgTsUser SET active_flag = pactive_flag, updated_by = pupdated_by, updated_at = now() WHERE `code` = pcode;
SELECT ROW_COUNT() INTO pitRowCount;
END IF;
END$$
DELIMITER ;	

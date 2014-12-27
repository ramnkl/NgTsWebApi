DROP PROCEDURE IF EXISTS EZEE_SP_Product_IUD
DELIMITER $$
CREATE PROCEDURE EZEE_SP_Product_IUD
(
	pProductName VARCHAR(50)
	,pProductDesc VARCHAR(50)
	,pPrice DECIMAL 
	, OUT pitRowCount INT)
 /* 
* Procedure Name    : EZEE_SP_Product_IUD
* 
* Purpose       : Insert /Update /DeleteProduct Table 
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
*   Tables      : Product
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
/Product Update
  -------------------------------------------------------------------------------------
   */ 
IF (pactive_flag = 1 AND EZEE_FN_ISNOTNULL(pcode)  ) THEN
	UPDATE Product
	SET
		ProductName = pProductName,
		ProductDesc = pProductDesc,
		Price = pPrice where `code`=pcode  
SELECT ROW_COUNT() INTO pitRowCount;
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
 ELSEIF (pactive_flag = 1 AND EZEE_FN_ISNULL(pcode) ) THEN
INSERT INTOProduct
(
	ProductName
	 ,ProductDesc
	 ,Price
	 )
VALUES(
	pProductName
	 ,pProductDesc
	 ,pPrice
	 );SELECT ROW_COUNT() INTO pitRowCount;
	/* -------------------------------------------------------------------------------------*/
/* DELETE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
/* -------------------------------------------------------------------------------------
/    Product DELETE
  -------------------------------------------------------------------------------------  */
  	ELSEIF (pactive_flag != 1 AND EZEE_FN_ISNOTNULL(pcode)) THEN
IF (pactive_flag = 9) THEN
	SET pactive_flag = 1;
END IF;
UPDATE Product SET active_flag = pactive_flag, updated_by = pupdated_by, updated_at = now() WHERE `code` = pcode;
SELECT ROW_COUNT() INTO pitRowCount;
END IF;
END$$
DELIMITER ;	

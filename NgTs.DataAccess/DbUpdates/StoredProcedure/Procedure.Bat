











sqlcmd -S %SName% -U %UName% -P %Pwd% -d %DbName% -I -i %Opath%\StoredProcedure\NgTsUser.InsertSP.sql -o %Opath%\Error\StoredProcedure\NgTsUser.InertSP.sql.err
sqlcmd -S %SName% -U %UName% -P %Pwd% -d %DbName% -I -i %Opath%\StoredProcedure\Product.InsertSP.sql -o %Opath%\Error\StoredProcedure\Product.InertSP.sql.err













sqlcmd -S %SName% -U %UName% -P %Pwd% -d %DbName% -I -i %Opath%\Table\NgTsUser.table.sql -o %Opath%\Error\Tables\NgTsUser.table.sql.err
sqlcmd -S %SName% -U %UName% -P %Pwd% -d %DbName% -I -i %Opath%\Table\Product.table.sql -o %Opath%\Error\Tables\Product.table.sql.err

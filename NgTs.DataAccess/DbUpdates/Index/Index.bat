sqlcmd -S %SName% -U %UName% -P %Pwd% -d %DbName% -I -i %Opath%\Index\Index.sql -o %Opath%\Error\Index\Index.sql.err

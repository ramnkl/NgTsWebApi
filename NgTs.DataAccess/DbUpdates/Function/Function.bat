sqlcmd -S %SName% -U %UName% -P %Pwd% -d %DbName% -I -i %Opath%\Function\Test.sql -o %Opath%\Error\Function\Test.sql.err
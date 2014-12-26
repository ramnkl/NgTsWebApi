sqlcmd -S %SName% -U %UName% -P %Pwd% -d %DbName% -I -i %Opath%\View\Test_vw.sql -o %Opath%\Error\View\Test_vw.sql.err


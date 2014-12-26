sqlcmd -S %SName% -U %UName% -P %Pwd% -d %DbName% -I -i %Opath%\Metadata\Metadata.sql -o %Opath%\Error\Metadata\Metadata.sql.err

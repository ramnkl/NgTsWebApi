@echo off
cls
set /p SName=Server Name :
set /p UName=User Name :
set /p Pwd=Password :
set /p DbName=Database Name :
set /p Opath=Objects Path :

set /p choice=ARE YOU SURE TO EXECUTE SCRIPTS in %DbName% (y/n) ?
if '%choice%'=='y' goto begin
goto end
:begin
@echo on 
call %Opath%\Table\Table.bat %SName% %UName% %Pwd% %DbName% %Opath%
call %Opath%\MetaData\MetaData.bat %SName% %UName% %Pwd% %DbName% %Opath%
call %Opath%\View\View.bat %SName% %UName% %Pwd% %DbName% %Opath%
call %Opath%\Function\Function.bat %SName% %UName% %Pwd% %DbName% %Opath%
call %Opath%\StoredProcedure\Procedure.bat %SName% %UName% %Pwd% %DbName% %Opath%
call %Opath%\Index\Index.bat %SName% %UName% %Pwd% %DbName% %Opath%

setLocal EnableDelayedExpansion
for /f "tokens=* delims= " %%a in ('dir/s/b/a-d %Opath%') do if %%~za equ 0 del "%%a"

:end
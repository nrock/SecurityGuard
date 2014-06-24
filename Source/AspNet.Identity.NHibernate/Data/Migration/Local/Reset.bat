@echo off
cls

sqlcmd -E -S . -i ../Local/DropDb.sql  
 
pause 

sqlcmd -E -S . -i ../2014-06-24/Migration.sql 

pause 
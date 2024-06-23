@echo off
SETLOCAL

REM Set the database connection details
SET SERVER_NAME=(localdb)\MSSQLLocalDB
SET DATABASE_NAME=DatingApp
SET SQL_FILE="C:\Users\svaki\source\repos\BlazorApp\BlazorApp\SQLQueryInsert100AccountsAndProfiles.sql"

REM Check if SQLCMD is available
sqlcmd -? >nul 2>&1
IF ERRORLEVEL 1 (
    echo SQLCMD utility is not available. Please install it and ensure it is in your PATH.
    EXIT /B 1
)

REM Execute the SQL script
sqlcmd -S %SERVER_NAME% -d %DATABASE_NAME% -i %SQL_FILE%
IF ERRORLEVEL 1 (
    echo Failed to execute the SQL script.
    EXIT /B 1
)

echo Data initialization completed successfully.
ENDLOCAL
EXIT /B 0
@echo off
SETLOCAL

REM Set the project root directory
SET PROJECT_ROOT=%~dp0

REM Set the database connection details
SET SERVER_NAME=(localdb)\MSSQLLocalDB
SET BCP_FILE="%PROJECT_ROOT%PostNr.txt"

REM Check if BCP is available
bcp -? >nul 2>&1
IF ERRORLEVEL 1 (
    echo BCP utility is not available. Please install it and ensure it is in your PATH.
    EXIT /B 1
)

REM Import city data using BCP
bcp DatingApp.dbo.Cities in %BCP_FILE% -S %SERVER_NAME% -c -C 65001 -T -t, -r \n
IF ERRORLEVEL 1 (
    echo Failed to import city data using BCP.
    EXIT /B 1
)

echo City data import completed successfully.
ENDLOCAL
EXIT /B 0

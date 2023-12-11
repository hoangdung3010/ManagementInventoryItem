cd /D "%~dp0"
sc stop MTSyncData_ExportVT
MT.WorkerSyncData.exe uninstall
pause;

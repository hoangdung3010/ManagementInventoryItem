cd /D "%~dp0"
MT.WorkerSyncData.exe install
sc start MTSyncData_ExportVT
pause;

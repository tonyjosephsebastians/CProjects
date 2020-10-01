// FtpUploader.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

#include "FtpUploader.h"
#include <windows.h>

#include <wininet.h>

FtpUploader::FtpUploader()
{

}

extern "C" __declspec(dllexport) bool Uploader(LPWSTR FilePath, LPWSTR FileName, LPWSTR FTP_Server, LPWSTR Username, LPWSTR password)
{
	bool bUpload = false;
	HINTERNET hInternetRoot;
	HINTERNET hFtp = NULL;
	hInternetRoot = InternetOpen(NULL, INTERNET_OPEN_TYPE_DIRECT, NULL, NULL, 0);
	if (hInternetRoot != NULL)
	{
		bUpload = false;
		hFtp = InternetConnect(hInternetRoot, FTP_Server, INTERNET_DEFAULT_FTP_PORT, Username, password, INTERNET_SERVICE_FTP, 0, 0);
		if (hFtp != NULL) {

			bUpload = FtpPutFile(hFtp, FileName, FilePath, FTP_TRANSFER_TYPE_BINARY, 0);
		}
	}
	InternetCloseHandle(hInternetRoot);
	InternetCloseHandle(hFtp);
	return bUpload;

}
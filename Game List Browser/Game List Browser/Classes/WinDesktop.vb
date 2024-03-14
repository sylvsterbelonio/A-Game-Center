Public Class WinDesktop
#Region "WinAPI declarations"
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long
    Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal hWnd1 As Long, ByVal hWnd2 As Long, ByVal lpsz1 As String, ByVal lpsz2 As String) As Long
    Private Declare Function SetParentWindow Lib "user32" Alias "SetParent" (ByVal hWndChild As Long, ByVal hWndNewParent As Long) As Long
#End Region
    Public Shared Sub AttachFormToDesktop(ByRef targetForm As Form)
        Dim hWinShell, hDesktopClass, hDesktopFileListView As Long

        'In the below: Retrieving neccessary handles, one by one.

        '"ProgMan" is the Windows shell.
        hWinShell = FindWindow("progman", vbNullString)

        'The windows desktop is a "shelldll_defview" class, and also a child to the ProgMan window.
        hDesktopClass = FindWindowEx(hWinShell, 0, "shelldll_defview", vbNullString)

        '"syslistview32" is a windows listview. This particular listview is the desktops listview, and that's where we'll append our targetForm. 
        hDesktopFileListView = FindWindowEx(hDesktopClass, 0, "syslistview32", vbNullString)

        SetParentWindow(targetForm.Handle, hDesktopFileListView) 'Set targetform's parent window to the desktops' file listview

    End Sub 'Makes the form permanently positioned on top of the desktop, above the desktop icons but below any other running applications.
End Class


Imports System.IO
Imports System.Xml
Imports System.Threading

Module modMain

    Private irgsMutex As Mutex

    Sub Main()

        Try
            'AddHandler Application.ThreadException, AddressOf CustomExceptionHandler.OnThreadException

            Try
                Application.EnableVisualStyles()
                Application.SetCompatibleTextRenderingDefault(False)
            Catch ex As Exception

            End Try

            Dim con As New PowerNET8.myConnector
            If con.check_No_Multi_System_Running("Game List Browser") Then
                If con.connection_MYSQL_Settings(Application.StartupPath, "connection.ini") Then
                    With con
                        dblocalhost = ._Localhost
                        dbport = ._Port
                        dbuser = ._UserRoot
                        dbpassword = ._Password
                        db = ._Database
                    End With
                   
                    Dim frm As New frmDashBoard
                    frm.ShowDialog()

                End If
            Else
                MsgBox("Application is already running.", MsgBoxStyle.Exclamation, "Unable to Open Multiple Times")
            End If

        Catch e As System.ObjectDisposedException

        End Try

    End Sub

End Module

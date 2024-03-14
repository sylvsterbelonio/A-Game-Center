Module modPublic
    Public dblocalhost As String = "localhost"
    Public dbport As String = "3306"
    Public dbuser As String = "root"
    Public dbpassword As String = ""
    Public db As String = "gamelist"
    Public userID1 As String
    Public userID2 As String

    Public Sub connect(ByRef mysql As PowerNET8.mySQL.Init.SQL)
        mysql.connectDatabase(dblocalhost, dbport, dbuser, dbpassword, db)
    End Sub

End Module

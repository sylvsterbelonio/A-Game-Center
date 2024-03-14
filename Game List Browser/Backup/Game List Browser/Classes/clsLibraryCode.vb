Imports PowerNET8.myString.Share
Imports Infragistics.Win.DateTimeEditor
Imports System.Xml
Imports System.IO
Namespace LibraryCode
    Public Class File
        Public Function getLocationOfLastSelectedFiles(ByVal data As String) As String
            Dim colData() As String = data.ToString.Split("\")
            Dim locValue As String = ""
            For i As Integer = 0 To colData.Count - 2
                Concat.Append(locValue, colData(i), "\")
            Next
            Return locValue
        End Function
    End Class

    Public Class Data

        Public Shared Sub saveGameType(ByVal table As DataTable)
            Try
                If (IO.File.Exists(Application.StartupPath + "\Data\gameType.xml")) Then IO.File.Delete(Application.StartupPath + "\Data\gameType.xml")
            Catch ex As Exception
                MsgBox(ex)
            End Try
            Dim loc As String = Application.StartupPath + "\Data\"
            If Not System.IO.Directory.Exists(Application.StartupPath + "\Data") Then
                PowerNET8.myFile.Share.Folders.createFolder("Data")
            End If

            Dim doc = New XDocument()

            Dim emp = New XElement("GameType")
            For i As Integer = 0 To table.Rows.Count - 1
                Dim list = New XElement("List")
                list.Add(New XElement("id", table.Rows(i).Item("id")))
                list.Add(New XElement("gameType", table.Rows(i).Item("gameType")))
                list.Add(New XElement("yearPublished", table.Rows(i).Item("yearPublished")))
                list.Add(New XElement("coverLocation", table.Rows(i).Item("coverLocation")))
                emp.Add(list)
            Next
            doc.Add(emp)

            doc.Save(loc + "gameType.xml")

        End Sub

        Public Shared Sub loadGameType(ByRef tablename As DataTable)
            If (IO.File.Exists(Application.StartupPath + "\Data\gameType.xml")) Then
                Dim xmldoc As New XmlDataDocument()
                Dim xmlnode As XmlNodeList
                Dim i As Integer
                Dim str As String
                Dim fs As New FileStream(Application.StartupPath + "\Data\gameType.xml", FileMode.Open, FileAccess.Read)
                xmldoc.Load(fs)
                xmlnode = xmldoc.GetElementsByTagName("List")
                For i = 0 To xmlnode.Count - 1
                    xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                    With tablename
                        .Rows.Add()
                        .Rows(i).Item("id") = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                        .Rows(i).Item("gameType") = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()
                        .Rows(i).Item("yearPublished") = xmlnode(i).ChildNodes.Item(2).InnerText.Trim()
                        .Rows(i).Item("coverLocation") = xmlnode(i).ChildNodes.Item(3).InnerText.Trim()
                    End With
                Next
            End If
        End Sub

    End Class

    Public Class Skin

        Public Sub setSkin(ByRef colObject As Collection)

            For Each obj As Object In colObject

                If TypeOf obj Is TextBox Then
                    With CType(obj, TextBox)
                        AddHandler .GotFocus, AddressOf txt_GotFocus
                        AddHandler .LostFocus, AddressOf txt_LostFocus
                    End With
                End If
            Next
        End Sub

        Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            sender.backcolor = Color.FromArgb(64, 64, 64)
        End Sub

        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            sender.backcolor = Color.FromArgb(21, 21, 21)
        End Sub

    End Class

    Public Class newsFeed

    End Class

End Namespace



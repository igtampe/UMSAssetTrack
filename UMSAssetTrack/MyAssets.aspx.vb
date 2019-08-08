Imports System.Data.OleDb
Imports System.IO
Imports System.Net.Sockets
Public Class MyAssets
    Inherits System.Web.UI.Page

    Private Shared con As OleDbConnection
    Private Shared cmd As OleDbCommand

    Public UMSWEBID As String
    Public Username As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Logoncheck()



    End Sub


    Sub Logoncheck()
        If Request.Cookies("UMSWEBID") IsNot Nothing Then
            If Request.Cookies("UMSWEBPIN") IsNot Nothing Then
                Dim tc As TcpClient = New TcpClient()
                Dim ns As NetworkStream
                Dim br As BinaryReader
                Dim bw As BinaryWriter
                Dim ServerMSG As String
                Dim ID As String
                Dim PIN As String


                ID = Request.Cookies("UMSWEBID").Value
                PIN = Request.Cookies("UMSWEBPIN").Value
                UMSWEBID = ID

                If ID = "" Then
                    Response.Redirect("~/login")

                    Exit Sub
                End If
                If Not ID.Count = 5 Then
                    Response.Redirect("~/login")
                    Exit Sub
                End If
                If PIN = "" Then
                    Response.Redirect("~/login")
                    Exit Sub
                End If
                If Not PIN.Count = 4 Then
                    Response.Redirect("~/login")
                    Exit Sub
                End If
                Try
                    tc.Connect(“igtnet-w.ddns.net”, 757)
                    Exit Try
                Catch
                    Response.Redirect("~/login")
                    Exit Sub
                End Try
                If tc.Connected = True Then
                    ns = tc.GetStream
                    br = New BinaryReader(ns)
                    bw = New BinaryWriter(ns)
                    bw.Write("CU" & ID & PIN)
                    Try
                        ServerMSG = br.ReadString()
                    Catch
                        Response.Redirect("~/login")
                        Exit Sub
                    End Try

                    tc.Close()

                    Select Case ServerMSG
                        Case 1
                            Response.Redirect("~/login")
                            Exit Select
                        Case 2
                            Response.Redirect("~/login")
                            Exit Select
                        Case 3
                            Dim splitvalues As String()
                            ServerMSG = ServerCommand("INFO" & UMSWEBID)
                            splitvalues = ServerMSG.Split(",")

                            Username = splitvalues(6)

                            UsernameLabel.Text = Username
                            IDLabel.Text = UMSWEBID

                            Exit Select
                    End Select
                End If

            Else
                Response.Cookies.Remove("UMSWEBID")
            End If

        End If
    End Sub
    Function ServerCommand(ByVal ClientMSG As String) As String
        Dim tc As TcpClient = New TcpClient()
        Dim ns As NetworkStream
        Dim br As BinaryReader
        Dim bw As BinaryWriter
        Dim ServerMSG As String
        ServerMSG = "E"
        If ClientMSG = "" Then
            ServerCommand = "E"
            Exit Function
        End If
        Try
            tc.Connect(“Igtnet-w.ddns.net”, 757)
            Exit Try
        Catch
            ServerCommand = "NOCONNECT"
            Exit Function
        End Try
        If tc.Connected = True Then
            ns = tc.GetStream
            br = New BinaryReader(ns)
            bw = New BinaryWriter(ns)
            bw.Write(ClientMSG)
            Try
                ServerMSG = br.ReadString()
            Catch
                ServerCommand = "CRASH"
                Exit Function
            End Try
            tc.Close()
        End If
        ServerCommand = ServerMSG
    End Function

    Protected Sub LogoutBTN_Click(sender As Object, e As EventArgs) Handles LogoutBTN.Click
        Response.Cookies("UMSWEBID").Value = ""
        Response.Cookies("UMSWEBPIN").Value = ""
        Response.Cookies("UMSWEBID").Expires = Now
        Response.Cookies("UMSWEBPIN").Expires = Now
        Response.Redirect("~")
    End Sub

    Protected Sub CreateBTN_Click(sender As Object, e As EventArgs) Handles CreateBTN.Click
        Response.Redirect("~/AssetForm.aspx?mode=new")
    End Sub
End Class
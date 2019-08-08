Imports System.IO
Imports System.Net.Sockets

Public Class Login
    Inherits Page

    Sub PageLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Call logoncheck()

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

                If ID = "" Then
                    NotificationSub(Drawing.Color.Pink, "You must enter an ID")
                    Response.Cookies.Remove("UMSWEBID")
                    Response.Cookies.Remove("UMSWEBPIN")

                    Exit Sub
                End If
                If Not ID.Count = 5 Then
                    NotificationSub(Drawing.Color.Wheat, "ID must have 5 digits")
                    Response.Cookies.Remove("UMSWEBID")
                    Response.Cookies.Remove("UMSWEBPIN")
                    Exit Sub
                End If
                If PIN = "" Then
                    NotificationSub(Drawing.Color.Pink, "You must enter a PIN")
                    Response.Cookies.Remove("UMSWEBID")
                    Response.Cookies.Remove("UMSWEBPIN")
                    Exit Sub
                End If
                If Not PIN.Count = 4 Then
                    NotificationSub(Drawing.Color.Wheat, "Pin must be 4 digits")
                    Response.Cookies.Remove("UMSWEBID")
                    Response.Cookies.Remove("UMSWEBPIN")
                    Exit Sub
                End If
                Try
                    tc.Connect(“igtnet-w.ddns.net”, 757)
                    Exit Try
                Catch
                    NotificationSub(Drawing.Color.Red, "Could not connect to ViBE Server")
                    Response.Cookies.Remove("UMSWEBID")
                    Response.Cookies.Remove("UMSWEBPIN")
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
                        NotificationSub(Drawing.Color.Wheat, "ViBE Server did not respond")
                        Response.Cookies.Remove("UMSWEBID")
                        Response.Cookies.Remove("UMSWEBPIN")
                        Exit Sub
                    End Try

                    tc.Close()

                    Select Case ServerMSG
                        Case 1
                            NotificationSub(Drawing.Color.Pink, "User not found")
                            Response.Cookies.Remove("UMSWEBID")
                            Response.Cookies.Remove("UMSWEBPIN")
                            Exit Select
                        Case 2
                            NotificationSub(Drawing.Color.Pink, "Incorrect Pin")
                            Response.Cookies.Remove("UMSWEBID")
                            Response.Cookies.Remove("UMSWEBPIN")
                            Exit Select
                        Case 3
                            Response.Redirect("~/MyAssets")
                            Exit Select
                    End Select
                End If

            Else
                Response.Cookies.Remove("UMSWEBID")
            End If

        End If
    End Sub

    Protected Sub LogonBTN_Click(sender As Object, e As EventArgs) Handles LogonBTN.Click
        NotifPanel.Visible = False

        Dim UMSWEBID As New HttpCookie("UMSWEBID")
        Dim UMSWEBPIN As New HttpCookie("UMSWEBPIN")

        Dim ID As String
        Dim PIN As String


        ID = LogonID.Text
        PIN = LogonPin.Text

        UMSWEBID.Value = ID
        UMSWEBID.Expires = DateTime.Now.AddHours(2)
        UMSWEBPIN.Value = PIN
        UMSWEBPIN.Expires = DateTime.Now.AddHours(2)

        Response.Cookies.Add(UMSWEBID)
        Response.Cookies.Add(UMSWEBPIN)

        Logoncheck()

    End Sub


    ''' <summary>
    ''' Summon the Notification Panel
    ''' </summary>
    ''' <param name="BackColor">Color of the notificaiton</param>
    ''' <param name="Notification">The actual notification</param>
    Sub NotificationSub(ByVal BackColor As Drawing.Color, ByVal Notification As String)

        NotifPanel.BackColor = BackColor
        NotifLabel.Text = Notification
        NotifPanel.Visible = True

    End Sub

End Class
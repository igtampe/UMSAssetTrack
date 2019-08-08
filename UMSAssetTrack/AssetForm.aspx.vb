Imports System.Data.OleDb
Imports System.IO
Imports System.Net.Sockets

Public Class AssetForm
    Inherits System.Web.UI.Page

    Public Structure UMSAsset
        Public AName As String
        Public AType As String
        Public Owner As String
        Public District As String
        Public City As String
        Public MapURL As String
        Public AssetImage As String
        Public Status As String
        Public DOC As String
        Public DOLM As String
        Public Complete As String
        Public Price As String
        Public OwnerID As String
        Public SUnits As Integer
        Public BR1Units As Integer
        Public BR2Units As Integer
        Public BR3Units As Integer
        Public PHUnits As Integer
        Public SRent As Integer
        Public BR1Rent As Integer
        Public BR2Rent As Integer
        Public BR3Rent As Integer
        Public PHRent As Integer
        Public Rooms As Integer
        Public Suites As Integer
        Public RoomRate As Integer
        Public SuitesRate As Integer
        Public MiscIncome As Integer
        Public BType As Integer
        Public Chairs As Integer
        Public AvgSpending As Integer
        Public CustomersPerHour As Integer
        Public HoursOpen As Integer
        Public Income As String
        Public XDim As Integer
        Public YDim As Integer
        Public ZDim As Integer
        Public Coord As String
    End Structure

    Public CurrentItem As UMSAsset
    Public PageMode As Integer
    Public CurrentItemID As Integer
    Private Shared con As OleDbConnection
    Private Shared cmd As OleDbCommand
    Public Reader As OleDbDataReader
    Public UserName As String
    Public UMSWEBID As String
    Public Loaded As Boolean = False

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
                UMSWEBID = ID
                PIN = Request.Cookies("UMSWEBPIN").Value

                If ID = "" Then
                    NotificationSub(Drawing.Color.Pink, "You must enter an ID")
                    Response.Cookies.Remove("UMSWEBID")
                    Response.Cookies.Remove("UMSWEBPIN")
                    UMSWEBID = ID
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
                            Dim splitvalues As String()
                            ServerMSG = ServerCommand("INFO" & UMSWEBID)
                            splitvalues = ServerMSG.Split(",")

                            UserName = splitvalues(6)


                            Exit Select
                    End Select
                End If

            Else
                Response.Cookies.Remove("UMSWEBID")
            End If

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Logoncheck()
        con = New OleDbConnection(ConfigurationManager.ConnectionStrings("doot").ConnectionString)



        If Request.QueryString("mode") IsNot Nothing Then
            If Request.QueryString("mode").ToUpper = "EDIT" Then

                FormTitle.Text = "ASSET UPDATE FORM"
                CreateModBtn.Text = "Update Asset"

                If Request.QueryString("ID") IsNot Nothing Then
                    'Modification
                    CurrentItemID = Request.QueryString("ID")
                    PageMode = 1
                    CreateModBtn.Enabled = True
                    'Check if the ItemName was already loaded, and if so exit the sub
                    If Not AssetNametextbox.Text = "ITEM NAME" Then Exit Sub

                    GetTodo(Request.QueryString("ID"))

                    'Check if the owner is the logged in user and if it isn't then tell him no
                    If Not OwnerIDTextbox.Text = UMSWEBID Then
                        PageMode = 10
                        CreateModBtn.Enabled = False
                        NotificationSub(Drawing.Color.Pink, "You don't own this item! You cannot edit it!")
                    End If


                Else
                        NotificationSub(Drawing.Color.Pink, "You must specify an ID to edit!")
                    PageMode = 10
                    CreateModBtn.Enabled = False
                End If
            ElseIf Request.QueryString("mode").ToUpper = "NEW" Then
                'Creation
                PageMode = 0
                FormTitle.Text = "ASSET CREATION FORM"
                CreateModBtn.Text = "Create Asset"
                OwnerIDTextbox.Text = UMSWEBID
                Ownertextbox.Text = UserName
                CreateModBtn.Enabled = True
            Else
                PageMode = 10
                NotificationSub(Drawing.Color.Pink, "Unknown pagemode specified:" & Request.QueryString("mode"))
                CreateModBtn.Enabled = False
            End If
        Else

            PageMode = 10
            NotificationSub(Drawing.Color.Pink, "No Mode specified")
            CreateModBtn.Enabled = False
        End If



    End Sub

    Sub GetTodo(ID As Integer)
        cmd = New OleDbCommand
        cmd.Connection = con
        cmd.CommandText = "Select * from Registry where ID=@p1"
        con.Open()
        cmd.Prepare()
        cmd.Parameters.AddWithValue("@p1", ID)
        Reader = cmd.ExecuteReader()
        Reader.Read()
        Try
            CurrentItem.AName = Reader.GetValue(1)
            CurrentItem.AType = Reader.GetValue(2)
            CurrentItem.Owner = Reader.GetValue(3)
            CurrentItem.District = Reader.GetValue(4)
            CurrentItem.City = Reader.GetValue(5)
            CurrentItem.MapURL = Reader.GetValue(6)
            CurrentItem.AssetImage = Reader.GetValue(7)
            CurrentItem.Status = Reader.GetValue(8)
            CurrentItem.DOC = Reader.GetValue(9)
            CurrentItem.DOLM = Reader.GetValue(10)
            CurrentItem.Complete = True
            CurrentItem.Price = Reader.GetValue(12)
            CurrentItem.OwnerID = Reader.GetValue(13)
            CurrentItem.SUnits = Reader.GetValue(14)
            CurrentItem.BR1Units = Reader.GetValue(15)
            CurrentItem.BR2Units = Reader.GetValue(16)
            CurrentItem.BR3Units = Reader.GetValue(17)
            CurrentItem.PHUnits = Reader.GetValue(18)
            CurrentItem.SRent = Reader.GetValue(19)
            CurrentItem.BR1Rent = Reader.GetValue(20)
            CurrentItem.BR2Rent = Reader.GetValue(21)
            CurrentItem.BR3Rent = Reader.GetValue(22)
            CurrentItem.PHRent = Reader.GetValue(23)
            CurrentItem.Rooms = Reader.GetValue(24)
            CurrentItem.Suites = Reader.GetValue(25)
            CurrentItem.RoomRate = Reader.GetValue(26)
            CurrentItem.SuitesRate = Reader.GetValue(27)
            CurrentItem.MiscIncome = Reader.GetValue(28)
            CurrentItem.BType = Reader.GetValue(29)
            CurrentItem.Chairs = Reader.GetValue(30)
            CurrentItem.AvgSpending = Reader.GetValue(31)
            CurrentItem.CustomersPerHour = Reader.GetValue(32)
            CurrentItem.HoursOpen = Reader.GetValue(33)
            CurrentItem.Income = Reader.GetValue(34)
            CurrentItem.XDim = Reader.GetValue(35)
            CurrentItem.YDim = Reader.GetValue(36)
            CurrentItem.ZDim = Reader.GetValue(37)
            CurrentItem.Coord = Reader.GetValue(38)

            'now that we have todo, lets display todo

            AssetID.Text = CurrentItemID

            AssetNametextbox.Text = CurrentItem.AName
            AssetID.Text = CurrentItemID
            Ownertextbox.Text = CurrentItem.Owner
            OwnerIDTextbox.Text = CurrentItem.OwnerID
            Districttextbox.Text = CurrentItem.District
            CityTextBox.Text = CurrentItem.City
            Pricetextbox.Text = CurrentItem.Price
            Incometextbox.Text = CurrentItem.Income
            Statustextbox.Text = CurrentItem.Status

            ImageURLTextBox.Text = CurrentItem.AssetImage

            SUnitstextbox.Text = CurrentItem.SUnits
            BR1Unitstextbox.Text = CurrentItem.BR1Units
            BR2Unitstextbox.Text = CurrentItem.BR2Units
            BR3Unitstextbox.Text = CurrentItem.BR3Units
            PHUnitstextbox.Text = CurrentItem.PHUnits

            SRenttextbox.Text = CurrentItem.SRent
            BR1Renttextbox.Text = CurrentItem.BR1Rent
            BR2Renttextbox.Text = CurrentItem.BR2Rent
            BR3Renttextbox.Text = CurrentItem.BR3Rent
            PHRenttextbox.Text = CurrentItem.PHRent

            RoomUnittextbox.Text = CurrentItem.Rooms
            SuiteUnitstextbox.Text = CurrentItem.Suites
            RoomRatetextbox.Text = CurrentItem.RoomRate
            SuiteRatetextbox.Text = CurrentItem.SuitesRate
            MiscIncometextbox.Text = CurrentItem.MiscIncome

            Chairstextbox.Text = CurrentItem.Chairs
            AvgSpendingtextbox.Text = CurrentItem.AvgSpending
            CustomersPerHour.Text = CurrentItem.CustomersPerHour
            HoursOpentextbox.Text = CurrentItem.HoursOpen
            TypeDropdown.Text = CurrentItem.AType


            Coordinatetextbox.Text = CurrentItem.Coord
            XDimensiontextbox.Text = CurrentItem.XDim
            YDimensiontextbox.Text = CurrentItem.YDim
            ZDimensiontextbox.Text = CurrentItem.ZDim

            con.Close()
        Catch ex As Exception
            Try
                con.Close()
            Catch

            End Try
            NotificationSub(Drawing.Color.Pink, "Could not load item " & CurrentItemID & " Because: " & vbNewLine & ex.ToString)
            PageMode = 10
            CreateModBtn.Enabled = False
        End Try



    End Sub

    Protected Sub CancelBTN_Click(sender As Object, e As EventArgs) Handles CancelBTN.Click
        Response.Redirect("~/MyAssets")
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

    Protected Sub CreateModBtn_Click(sender As Object, e As EventArgs) Handles CreateModBtn.Click
        CurrentItem.AName = ""
        CurrentItem.AName = AssetNametextbox.Text

        CurrentItem.Owner = Ownertextbox.Text
        CurrentItem.OwnerID = OwnerIDTextbox.Text
        CurrentItem.District = Districttextbox.Text
        CurrentItem.City = CityTextBox.Text
        CurrentItem.Price = Pricetextbox.Text
        CurrentItem.Income = Incometextbox.Text
        CurrentItem.Status = Statustextbox.Text

        CurrentItem.AssetImage = ImageURLTextBox.Text

        CurrentItem.SUnits = SUnitstextbox.Text
        CurrentItem.BR1Units = BR1Unitstextbox.Text
        CurrentItem.BR2Units = BR2Unitstextbox.Text
        CurrentItem.BR3Units = BR3Unitstextbox.Text
        CurrentItem.PHUnits = PHUnitstextbox.Text

        CurrentItem.SRent = SRenttextbox.Text
        CurrentItem.BR1Rent = BR1Renttextbox.Text
        CurrentItem.BR2Rent = BR2Renttextbox.Text
        CurrentItem.BR3Rent = BR3Renttextbox.Text
        CurrentItem.PHRent = PHRenttextbox.Text

        CurrentItem.Rooms = RoomUnittextbox.Text
        CurrentItem.Suites = SuiteUnitstextbox.Text
        CurrentItem.RoomRate = RoomRatetextbox.Text
        CurrentItem.SuitesRate = SuiteRatetextbox.Text
        CurrentItem.MiscIncome = MiscIncometextbox.Text
        CurrentItem.AType = TypeDropdown.Text

        CurrentItem.Chairs = Chairstextbox.Text
        CurrentItem.AvgSpending = AvgSpendingtextbox.Text
        CurrentItem.CustomersPerHour = CustomersPerHour.Text
        CurrentItem.HoursOpen = HoursOpentextbox.Text



        CurrentItem.Coord = Coordinatetextbox.Text
        CurrentItem.XDim = XDimensiontextbox.Text
        CurrentItem.YDim = YDimensiontextbox.Text
        CurrentItem.ZDim = ZDimensiontextbox.Text

        Select Case PageMode
            Case 0
                'insert
                CurrentItem.DOLM = DateTime.Now.ToShortDateString
                CurrentItem.DOC = DateTime.Now.ToShortDateString
                CurrentItem.Complete = True
                CurrentItem.MapURL = "http://igtnet-w.ddns.net:100/ums/ums/index.html"
                cmd = New OleDbCommand
                cmd.Connection = con
                cmd.CommandText = "Insert into Registry (
AName, 
AType, 
Owner, 
District, 
City, 
MapURL, 
ImageURL, 
Status, 
DOC, 
DOLM, 
Complete, 
Price, 
OwnerID, 
SUnits, 
1BRUnits, 
2BRUnits, 
3BRUnits, 
PHUnits, 
SRent, 
1BRRent, 
2BRRent, 
3BRRent, 
PHRent, 
Rooms, 
Suites, 
RoomRate, 
SuiteRate, 
MiscIncome, 
BType, 
Chairs, 
AvgSpending, 
CustomersPerHour, 
HoursOpen, 
Income, 
XDim, 
YDim, 
ZDim, 
CornerPos
) Values ('" & CurrentItem.AName & "', '" & CurrentItem.AType & "', '" & CurrentItem.Owner & "', '" & CurrentItem.District & "', '" & CurrentItem.City & "', '" & CurrentItem.MapURL & "', '" & CurrentItem.AssetImage & "', '" & CurrentItem.Status & "', '" & CurrentItem.DOC & "', '" & CurrentItem.DOLM & "', '" & CurrentItem.Complete & "', '" & CurrentItem.Price & "', '" & CurrentItem.OwnerID & "', '" & CurrentItem.SUnits & "', '" & CurrentItem.BR1Units & "', '" & CurrentItem.BR2Units & "', '" & CurrentItem.BR3Units & "', '" & CurrentItem.PHUnits & "', '" & CurrentItem.SRent & "', '" & CurrentItem.BR1Rent & "', '" & CurrentItem.BR2Rent & "', '" & CurrentItem.BR3Rent & "', '" & CurrentItem.PHRent & "', '" & CurrentItem.Rooms & "', '" & CurrentItem.Suites & "', '" & CurrentItem.RoomRate & "', '" & CurrentItem.SuitesRate & "', '" & CurrentItem.MiscIncome & "', '" & CurrentItem.BType & "', '" & CurrentItem.Chairs & "', '" & CurrentItem.AvgSpending & "', '" & CurrentItem.CustomersPerHour & "', '" & CurrentItem.HoursOpen & "', '" & CurrentItem.Income & "', '" & CurrentItem.XDim & "', '" & CurrentItem.YDim & "', '" & CurrentItem.ZDim & "', '" & CurrentItem.Coord & "');"
                con.Open()
                cmd.Prepare()
                cmd.ExecuteNonQuery()
                Response.Redirect("~/myassets.aspx")

            Case 1
                CurrentItem.DOLM = DateTime.Now
                CurrentItem.Complete = True
                CurrentItem.MapURL = "http://igtnet-w.ddns.net:100/ums/ums/index.html"
                cmd = New OleDbCommand
                cmd.Connection = con
                cmd.CommandText = "

Update Registry 
Set 
AName = '" & CurrentItem.AName & "', 
AType = '" & CurrentItem.AType & "', 
Owner = '" & CurrentItem.Owner & "', 
District = '" & CurrentItem.District & "', 
City = '" & CurrentItem.City & "', 
MapURL = '" & CurrentItem.MapURL & "', 
ImageURL = '" & CurrentItem.AssetImage & "', 
Status = '" & CurrentItem.Status & "', 
DOC = '" & CurrentItem.DOC & "', 
DOLM = '" & CurrentItem.DOLM & "', 
Complete = '" & CurrentItem.Complete & "', 
Price = '" & CurrentItem.Price & "', 
OwnerID = '" & CurrentItem.OwnerID & "', 
SUnits = '" & CurrentItem.SUnits & "', 
1BRUnits = '" & CurrentItem.BR1Units & "', 
2BRUnits = '" & CurrentItem.BR2Units & "', 
3BRUnits = '" & CurrentItem.BR3Units & "', 
PHUnits = '" & CurrentItem.PHUnits & "', 
SRent = '" & CurrentItem.SRent & "', 
1BRRent = '" & CurrentItem.BR1Rent & "', 
2BRRent = '" & CurrentItem.BR2Rent & "', 
3BRRent = '" & CurrentItem.BR3Rent & "', 
PHRent = '" & CurrentItem.PHRent & "', 
Rooms = '" & CurrentItem.Rooms & "', 
Suites = '" & CurrentItem.Suites & "', 
RoomRate = '" & CurrentItem.RoomRate & "', 
SuiteRate = '" & CurrentItem.SuitesRate & "', 
MiscIncome = '" & CurrentItem.MiscIncome & "', 
BType = '" & CurrentItem.BType & "', 
Chairs = '" & CurrentItem.Chairs & "', 
AvgSpending = '" & CurrentItem.AvgSpending & "', 
CustomersPerHour = '" & CurrentItem.CustomersPerHour & "', 
HoursOpen = '" & CurrentItem.HoursOpen & "', 
Income = '" & CurrentItem.Income & "', 
XDim = '" & CurrentItem.XDim & "', 
YDim = '" & CurrentItem.YDim & "', 
ZDim = '" & CurrentItem.ZDim & "', 
CornerPos = '" & CurrentItem.Coord & "'
WHERE ID = " & CurrentItemID & ";"
                con.Open()
                cmd.Prepare()
                cmd.ExecuteNonQuery()
                Response.Redirect("~/AssetDetails.aspx?ID=" & CurrentItemID)
                'Mod
        End Select
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
End Class
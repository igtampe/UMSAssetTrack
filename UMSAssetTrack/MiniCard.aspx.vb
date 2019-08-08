Imports System.Data.OleDb

Public Class MiniCard
    Inherits System.Web.UI.Page

    Public CurrentItem As AssetDetails.UMSAsset
    Private Shared con As OleDbConnection
    Private Shared cmd As OleDbCommand
    Public Reader As OleDbDataReader
    Public CurrentItemID As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New OleDbConnection(ConfigurationManager.ConnectionStrings("doot").ConnectionString)
        If Request.QueryString("ID") IsNot Nothing Then
            CurrentItemID = Request.QueryString("ID")
            GetTodoLite(CurrentItemID)
        Else
            CurrentItemID = 1
            GetTodoLite(1)
        End If

        AssetNameLabel.NavigateUrl = "~/AssetDetails.aspx?ID=" & CurrentItemID
        AssetNameLabel.Target = "_blank"

    End Sub

    Sub GetTodoLite(ID As Integer)
        cmd = New OleDbCommand
        cmd.Connection = con
        cmd.CommandText = "Select * from Registry where ID=@p1"
        con.Open()
        cmd.Prepare()
        cmd.Parameters.AddWithValue("@p1", ID)
        Reader = cmd.ExecuteReader()
        Reader.Read()

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
        CurrentItem.Complete = Reader.GetValue(11)
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

        AssetNameLabel.Text = CurrentItem.AName & " (" & ID & ")"
        OwnerLabel.Text = CurrentItem.Owner
        StatusLabel.Text = CurrentItem.Status

        AssetImage.ImageUrl = CurrentItem.AssetImage

        con.Close()

    End Sub



End Class
Imports System.Data.OleDb

Public Class AssetDetails
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
    Private Shared con As OleDbConnection
    Private Shared cmd As OleDbCommand
    Public Reader As OleDbDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New OleDbConnection(ConfigurationManager.ConnectionStrings("doot").ConnectionString)

        If Request.QueryString("ID") IsNot Nothing Then
            GetTodo(Request.QueryString("ID"))
        Else
            GetTodo(1)
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
        TypeLabel.Text = CurrentItem.AType
        LocationLabel.Text = CurrentItem.City & ", " & CurrentItem.District
        CreationDate.Text = CurrentItem.DOC
        PriceLabel.Text = CurrentItem.Price
        IncomeLabel.Text = CurrentItem.Income
        StatusLabel.Text = CurrentItem.Status

        AssetImage.ImageUrl = CurrentItem.AssetImage

        SUnitsLabel.Text = CurrentItem.SUnits
        BR1UnitsLabel.Text = CurrentItem.BR1Units
        BR2UnitsLabel.Text = CurrentItem.BR2Units
        BR3UnitsLabel.Text = CurrentItem.BR3Units
        PHUnitsLabel.Text = CurrentItem.PHUnits

        SRentLabel.Text = CurrentItem.SRent
        BR1RentLabel.Text = CurrentItem.BR1Rent
        BR2RentLabel.Text = CurrentItem.BR2Rent
        BR3RentLabel.Text = CurrentItem.BR3Rent
        PHRentLabel.Text = CurrentItem.PHRent

        RoomUnitLabel.Text = CurrentItem.Rooms
        SuiteUnitsLabel.Text = CurrentItem.Suites
        RoomRateLabel.Text = CurrentItem.RoomRate
        SuiteRateLabel.Text = CurrentItem.SuitesRate
        MiscIncomeLabel.Text = CurrentItem.MiscIncome

        ChairsLabel.Text = CurrentItem.Chairs
        AvgSpendingLabel.Text = CurrentItem.AvgSpending
        CustomersPerHour.Text = CurrentItem.CustomersPerHour
        HoursOpenLabel.Text = CurrentItem.HoursOpen

        LastModDate.Text = CurrentItem.DOLM

        CoordinateLabel.Text = CurrentItem.Coord
        XDimensionLabel.Text = CurrentItem.XDim
        YDimensionLabel.Text = CurrentItem.YDim
        ZDimensionLabel.Text = CurrentItem.ZDim

        con.Close()



    End Sub

End Class
Public Class Contact
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Request.QueryString("search") IsNot Nothing Then
            ResultsLabel.Text = "Search results for '" & Request.QueryString("Search") & "'"

            ResultsLabel.Visible = True
        Else
            ResultsLabel.Visible = False
        End If
    End Sub

    Protected Sub LogoutBTN_Click(sender As Object, e As EventArgs) Handles LogoutBTN.Click
        Response.Redirect("~/contact.aspx?search=" & searchbox.Text)
    End Sub
End Class
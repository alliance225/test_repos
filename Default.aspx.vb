
Imports System.Text.RegularExpressions
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim cEx As New cExecute

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

        Dim Emails As String() = ExtractEmailAddressesFromString()

        Dim Cles, Valeurs As New ArrayList


        For i = 0 To Emails.Count - 1

            Cles.Clear() : Valeurs.Clear()

            Cles.Add("@EMAIL") : Valeurs.Add(Emails(i))
            Cles.Add("@CATEGORIE") : Valeurs.Add("OUTLOOK")

            cEx.Execute_Commande_StoreProc("SP_EMAIL_ADD", Cles, Valeurs)

        Next




    End Sub


    Private Function ExtractEmailAddressesFromString() As String()
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\Users\kourouma\Documents\myemails2.txt", System.Text.Encoding.ASCII)

        Dim mc As MatchCollection
        Dim i As Integer

        ' expression garnered from www.regexlib.com - thanks guys!
        mc = Regex.Matches(fileReader,
            "([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})")
        Dim results(mc.Count - 1) As String
        For i = 0 To results.Length - 1
            results(i) = mc(i).Value
        Next

        Return results
    End Function

End Class

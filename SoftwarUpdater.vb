'' Softwar Updater v0.1 beta
'' Developed by badiiiro
'' Author: badiiiro
'' License: N/A
'' License URL: N/A
'' Copyright (C) 2019
Public Class softwareUpdater

    Private Sub softwareUpdater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForUpdateInWebSite()
    End Sub

    Public Sub CheckForUpdateInWebSite()
        MsgBox("Check our website for the last update")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button1.Text = "Checking for updates..."
        Timer1.Start()
        Label1.Text = ProgressBar1.Value & (" %")
        CheckForUpdates()
    End Sub

    Public Sub CheckForUpdates()
        If ProgressBar1.Value = 100 Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://localhost/download/version.ini")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            If newestversion.Contains(currentversion) Then
                Button1.Text = ("You are up todate!")
                MsgBox("You may now close this programs")
            Else
                Button1.Text = ("Downloading update!")
                WebBrowser1.Navigate("http://localhost/download/update.zip")
                MsgBox("You may now close this programs")
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)
        Label1.Text = ProgressBar1.Value & (" %")
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()

            If ProgressBar1.Value = 100 Then
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://localhost/download/version.ini")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()

                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

                Dim newestversion As String = sr.ReadToEnd()
                Dim currentversion As String = Application.ProductVersion
                If newestversion.Contains(currentversion) Then
                    Button1.Text = ("You are up todate!")
                    MsgBox("You may now close this programs")
                Else
                    Button1.Text = ("Downloading update!")
                    WebBrowser1.Navigate("http://localhost/download/update.zip")
                    MsgBox("You may now close this programs")
                End If
            End If
        End If
    End Sub

    Private Sub StopUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopUpdate.Click
        Timer1.Stop()
        ProgressBar1.Value = 0
        StopUpdate.Enabled = False
        StopUpdate.Text = ("Update Canceled")
        Label1.Text = "0 %"
        Me.Close()
    End Sub

    Private Sub About_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles About.Click
        AboutBox.Show()
    End Sub
End Class

Imports System.Data.OleDb
Imports System.IO

Public Class frmUpdatePurok

    'PUROK ID LOADER FUNCTION
    Private Sub purokID(Optional ByVal q As String = "")
        If con.State = ConnectionState.Closed Then
            OpenCon()
        End If
        Try
            Dim strsql As String
            strsql = "SELECT * FROM tblPurok WHERE [Purok_ID] = " & frmDashboard.txtPurID.Text & ""
            Dim cmd As New OleDbCommand(strsql, con)
            dr = cmd.ExecuteReader
            dr.Read()
            txtPurok.Text = dr("Purok_Name")
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
    End Sub

    'LOADER
    Private Sub frmUpdatePurok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call purokID()
    End Sub

    'BUTTON UPDATE
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If con.State = ConnectionState.Closed Then
            OpenCon()
        End If
        Try
            If txtPurok.Text = "" Then
                MessageBox.Show("Please input empty fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                query.Connection = con
                query.CommandText = "UPDATE tblPurok SET [Purok_Name] = '" & txtPurok.Text & "' WHERE [Purok_ID] = " & frmDashboard.txtPurID.Text & ""
                query.ExecuteNonQuery()
                MessageBox.Show("Update Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call frmDashboard.loadPurok()
                txtPurok.Clear()
                frmDashboard.txtPurID.Clear()
                frmDashboard.txtPurName.Clear()
                con.Close()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
        Call frmDashboard.loadPurok()
    End Sub

    'BUTTON BACK
    Private Sub btnBac_Click(sender As Object, e As EventArgs) Handles btnBac.Click
        Me.Close()
    End Sub

End Class
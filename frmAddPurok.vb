Imports System.Data.OleDb
Public Class frmAddPurok

    'BUTTON SAVE
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If con.State = ConnectionState.Closed Then
            OpenCon()
        End If

        If txtPurok.Text = "" Then
            MessageBox.Show("Please input empty fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                query.Connection = con
                query.CommandText = "INSERT INTO tblPurok([Purok_Name]) VALUES('" & txtPurok.Text & "')"
                query.ExecuteNonQuery()
                MessageBox.Show("New Purok Has Been Added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call frmDashboard.loadPurok()
                txtPurok.Clear()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            con.Close()
        End If

    End Sub

    'BUTTON BACK
    Private Sub btnBac_Click(sender As Object, e As EventArgs) Handles btnBac.Click
        Me.Hide()
    End Sub
End Class
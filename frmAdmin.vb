Imports System.Data.OleDb
Public Class frmAdmin
    'LOADER FUNCTION
    Private Sub LoadTables(Optional ByVal q As String = "")
        Try
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If
            query.Connection = con
            query.CommandText = "SELECT * FROM tblEmployee"
            adapter.SelectCommand = query
            dt.Clear()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
    End Sub

    'LOADER
    Private Sub frmAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadTables()
    End Sub

    'DATA GRID VIEW SELECTOR
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        txtUserid.Text = row.Cells(0).Value.ToString()
        txtFullname.Text = row.Cells(1).Value.ToString()
        txtUsername.Text = row.Cells(2).Value.ToString()
        txtContactNo.Text = row.Cells(3).Value.ToString()
        txtPassword.Text = row.Cells(4).Value.ToString()
        txtStatus.Text = row.Cells(6).Value.ToString()
    End Sub

    'BUTTON VERIFY ACCOUNT
    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Try
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If
            txtStatus.Text = "VERIFIED"
            query.CommandText = "UPDATE tblEmployee SET Status = '" & txtStatus.Text & "' WHERE Employee_ID = " & txtUserid.Text & ""
            query.ExecuteNonQuery()
            MessageBox.Show("Verified Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Call LoadTables()
    End Sub

    'BUTTON MODIFY ACCOUNT
    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Try
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If

            If btnModify.Text = "&Modify Account" Then
                txtFullname.ReadOnly = False
                txtUsername.ReadOnly = False
                txtContactNo.ReadOnly = False
                txtPassword.ReadOnly = False

                btnModify.Text = "Confirm"
                con.Close()
            ElseIf btnModify.Text = "Confirm" Then
                query.CommandText = "UPDATE tblEmployee SET [Fullname] = '" & txtFullname.Text & "', [Username] = '" & txtUsername.Text & "', [Contact_Number] = '" & txtContactNo.Text & "', [Password] = '" & txtPassword.Text & "', [Date_Created] = '" & Today & "' WHERE Employee_ID = " & txtUserid.Text & ""
                query.ExecuteNonQuery()
                txtFullname.ReadOnly = True
                txtUsername.ReadOnly = True
                txtContactNo.ReadOnly = True
                txtPassword.ReadOnly = True
                MessageBox.Show("Updated Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnModify.Text = "&Modify Account"
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Call LoadTables()
    End Sub

    'BUTTON DELETE
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If
            query.CommandText = "DELETE * FROM tblEmployee WHERE Employee_ID = " & txtUserid.Text & ""
            query.ExecuteNonQuery()
            MessageBox.Show("Account has been Deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close()
            txtFullname.Clear()
            txtUserid.Clear()
            txtContactNo.Clear()
            txtPassword.Clear()
            txtStatus.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
        Call LoadTables()
    End Sub

    'BUTTON BACK
    Private Sub btnBac_Click(sender As Object, e As EventArgs) Handles btnBac.Click
        Me.Close()
        frmStart.Show()
    End Sub

    'BUTTON LOAD
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Call LoadTables()
    End Sub
End Class
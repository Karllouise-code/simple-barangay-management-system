Imports System.Data.OleDb
Imports System.IO
Public Class frmDashboard
    Dim i As Integer

    'LOADER PUROK 
    Public Sub loadPurok(Optional ByVal q As String = "")
        Try
            DataGridView1.Rows.Clear()
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If
            Dim cmd As New OleDb.OleDbCommand("SELECT * FROM tblPurok", con)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("Purok_ID"), dr.Item("Purok_Name"))
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
    End Sub

    'LOADER HOUSEHOLD
    Public Sub loadHousehold(Optional ByVal q As String = "")
        Try
            DataGridView2.Rows.Clear()
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If
            Dim cmd As New OleDb.OleDbCommand("SELECT * FROM tblHousehold", con)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView2.Rows.Add(dr.Item("Household_ID"), dr.Item("Last_Name"), dr.Item("First_Name"), dr.Item("Middle"), dr.Item("Ext"), dr.Item("No"),
                    dr.Item("Street"), dr.Item("Purok"), dr.Item("Place_of_Birth"), dr.Item("Birthdate"), dr.Item("Sex"), dr.Item("Civil Status"), dr.Item("Citizenship"), dr.Item("Occupation"))
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
    End Sub

    'DATA GRID VIEW SELECTOR OF PUROK
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        txtPurID.Text = row.Cells(0).Value.ToString
        txtPurName.Text = row.Cells(1).Value.ToString
    End Sub


    'FULLNAME OF EMPLOYEE FUNCTION
    Private Sub employeeName(Optional ByVal q As String = "")
        If con.State = ConnectionState.Closed Then
            OpenCon()
        End If
        Try
            Dim strsql As String
            strsql = "SELECT * FROM tblEmployee WHERE [Username] = '" & frmLogin.txtUsername.Text & "'"
            Dim cmd As New OleDbCommand(strsql, con)
            Dim myReader As OleDbDataReader
            myReader = cmd.ExecuteReader
            myReader.Read()
            lblFullname.Text = myReader("Fullname")
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
    End Sub

    'PICTURE LOADER
    Public Sub picLoader(Optional ByVal q As String = "")
        Try
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If
            Dim picture() As Byte
            Dim strsql As String
            strsql = "SELECT * FROM tblEmployee WHERE [Username] = '" & frmLogin.txtUsername.Text & "'"
            Dim cmd As New OleDbCommand(strsql, con)
            cmd.Parameters.Clear()
            Dim da As New OleDbDataAdapter
            da.SelectCommand = cmd
            da.Fill(dt)
            'Convert Image to Binary String
            picture = dt.Rows(0).Item("Pic")
            Dim mstream As New System.IO.MemoryStream(picture)
            PictureBox1.Image = Image.FromStream(mstream)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
    End Sub

    'LOADER
    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call picLoader()
        Call employeeName()
        Call loadPurok()
        Call loadHousehold()
        Timer1.Enabled = True
        lblHouseID.Hide()
        txtHouseID.Hide()
    End Sub


    ''''''' ---------------- PUROK ---------------- '''''''

    'BUTTON ADD PUROK
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        frmAddPurok.Show()
    End Sub

    'BUTTON UPDATE PUROK
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If con.State = ConnectionState.Closed Then
            OpenCon()
        End If
        Using cmd As New OleDbCommand("SELECT COUNT(*) FROM tblPurok WHERE [Purok_ID] = @Purok_ID", con)
            cmd.Parameters.AddWithValue("@Purok_ID", OleDbType.VarChar).Value = txtPurID.Text.Trim
            Dim count = Convert.ToInt32(cmd.ExecuteScalar())
            If count > 0 Then
                frmUpdatePurok.Show()
                con.Close()
                Exit Sub
            Else
                MessageBox.Show("Purok ID is not Registered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

    End Sub

    'BUTTON DELETE PUROK
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If
            If MsgBox("Are you sure you want to delete this record?", vbQuestion + vbYesNo) = vbYes Then
                Dim cmd As New OleDb.OleDbCommand("DELETE FROM tblPurok WHERE [Purok_ID] = @Purok_ID", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@Purok_ID", txtPurID.Text)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("Record Deleted Succesfully!", vbInformation)
                    txtPurID.Clear()
                    txtPurName.Clear()
                Else
                    MsgBox("Failed!", vbCritical)
                End If
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
        Call loadPurok()
    End Sub

    'SEARCH BAR PUROK
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            DataGridView1.Rows.Clear()
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If
            Dim cmd As New OleDb.OleDbCommand("SELECT * FROM tblPurok WHERE [Purok_ID] like '%" & txtSearch.Text & "%' or [Purok_Name] like '%" & txtSearch.Text & "%' ", con)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("Purok_ID"), dr.Item("Purok_Name"))
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
    End Sub

    'BUTTON REFRESH PUROK
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Call loadPurok()
    End Sub

    'BUTTON REFRESH HOUSEHOLD
    Private Sub btnLoad2_Click(sender As Object, e As EventArgs) Handles btnLoad2.Click
        Call loadHousehold()
    End Sub

    'TAB PAGE 1 MOUSE ENTER
    Private Sub TabPage1_MouseEnter(sender As Object, e As EventArgs) Handles TabPage1.MouseEnter
        Label7.Show()
        Label8.Show()
        txtPurID.Show()
        txtPurName.Show()
        lblHouseID.Hide()
        txtHouseID.Hide()
    End Sub

    'TAB PAGE 2 MOUSE ENTER
    Private Sub TabPage2_MouseEnter(sender As Object, e As EventArgs) Handles TabPage2.MouseEnter
        Label7.Hide()
        Label8.Hide()
        txtPurID.Hide()
        txtPurName.Hide()
        lblHouseID.Show()
        txtHouseID.Show()
    End Sub


    ''''''' ---------------- HOUSEHOLD ---------------- '''''''

    'DATA GRID VIEW SELECTOR OF HOUSEHOLD
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim row As DataGridViewRow = DataGridView2.CurrentRow
        txtHouseID.Text = row.Cells(0).Value.ToString
    End Sub
    'BUTTON ADD PUROK
    Private Sub btnAdd2_Click(sender As Object, e As EventArgs) Handles btnAdd2.Click
        frmAddHousehold.Show()
    End Sub

    'BUTTON VIEW
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        frmUpdateHousehold.Show()
    End Sub

    'BUTTON DELETE HOUSEHOLD
    Private Sub btnDelete2_Click(sender As Object, e As EventArgs) Handles btnDelete2.Click
        Try
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If
            If MsgBox("Are you sure you want to delete this record?", vbQuestion + vbYesNo) = vbYes Then
                Dim cmd As New OleDb.OleDbCommand("DELETE FROM tblHousehold WHERE [Household_ID] = @Household_ID", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@Household_ID", txtHouseID.Text)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("Record Deleted Succesfully!", vbInformation)
                    txtHouseID.Clear()
                Else
                    MsgBox("Failed!", vbCritical)
                End If
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
        Call loadHousehold()
    End Sub

    'SEARCH BAR HOUSEHOLD
    Private Sub txtSearch2_TextChanged(sender As Object, e As EventArgs) Handles txtSearch2.TextChanged
        Try
            DataGridView2.Rows.Clear()
            If con.State = ConnectionState.Closed Then
                OpenCon()
            End If
            Dim cmd As New OleDb.OleDbCommand("SELECT * FROM tblHousehold WHERE [Household_ID] like '%" & txtSearch2.Text & "%' or [Last_Name] like '%" & txtSearch2.Text & "%' or [First_Name] like '%" & txtSearch2.Text & "%' or [Middle] like '%" & txtSearch2.Text & "%' or [Ext] like '%" & txtSearch2.Text &
                                              "%' or [No] like '%" & txtSearch2.Text & "%' or [Street] like '%" & txtSearch2.Text & "%' or [Purok] like '%" & txtSearch2.Text & "%' or [Place_of_Birth] like '%" & txtSearch2.Text & "%' or [Birthdate] like '%" & txtSearch2.Text & "%' or [Sex] like '%" & txtSearch2.Text &
                                              "%' or [Civil Status] like '%" & txtSearch2.Text & "%' or [Citizenship] like '%" & txtSearch2.Text & "%' or [Occupation] like '%" & txtSearch2.Text & "%' ", con)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView2.Rows.Add(dr.Item("Household_ID"), dr.Item("Last_Name"), dr.Item("First_Name"), dr.Item("Middle"), dr.Item("Ext"), dr.Item("No"), dr.Item("Street"), dr.Item("Purok"), dr.Item("Place_of_Birth"), dr.Item("Birthdate"), dr.Item("Sex"), dr.Item("Civil Status"), dr.Item("Citizenship"), dr.Item("Occupation"))
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
    End Sub




    'TIMER TICK
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Date.Now.ToString("MMM dd yyyy")
        lblTime.Text = Date.Now.ToString("hh:mm:ss tt")
    End Sub

    'BUTTON LOGOUT
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        frmStart.Show()
    End Sub

End Class
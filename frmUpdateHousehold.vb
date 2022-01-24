Imports System.Data.OleDb
Imports System.IO

Public Class frmUpdateHousehold

    'SEX CHECKER
    Sub sexChecker()
        If txtSex.Text = "MALE" Then
            RadioButton1.Checked = True
        ElseIf txtSex.Text = "FEMALE" Then
            RadioButton2.Checked = True
        End If
    End Sub

    'CIVIL STATUS CHECKER
    Sub civilChecker()
        If txtCivil.Text = "SINGLE" Then
            CheckBox1.Checked = True
        ElseIf txtCivil.Text = "MARRIED" Then
            CheckBox2.Checked = True
        ElseIf txtCivil.Text = "WIDOW" Then
            CheckBox3.Checked = True
        ElseIf txtCivil.Text = "SEPARATED" Then
            CheckBox4.Checked = True
        End If
    End Sub

    'COMBOBOX PUROK READER
    Sub purokLoad()
        If con.State = ConnectionState.Closed Then
            OpenCon()
        End If
        ComboBox2.Items.Clear()
        Dim cmd As New OleDb.OleDbCommand("SELECT * FROM tblPurok", con)
        dr = cmd.ExecuteReader
        While dr.Read
            ComboBox2.Items.Add(dr.GetString(1))
        End While
        dr.Close()
        con.Close()
    End Sub

    'TEXTBOXES LOADER FUNCTION
    Private Sub loadInformation(Optional ByVal q As String = "")
        If con.State = ConnectionState.Closed Then
            OpenCon()
        End If
        Try
            txtRegion.Text = "IV - A"
            txtProvince.Text = "LAGUNA"
            txtCityMun.Text = "BIÑAN"
            txtBrgy.Text = "TRIMEX"
            Dim strsql As String
            strsql = "SELECT * FROM tblHousehold WHERE [Household_ID] = " & frmDashboard.txtHouseID.Text & ""
            Dim cmd As New OleDbCommand(strsql, con)
            dr = cmd.ExecuteReader
            dr.Read()
            txtLast.Text = dr("Last_Name")
            txtFirst.Text = dr("First_Name")
            txtMiddle.Text = dr("Middle")
            ComboBox1.Text = dr("Ext")
            txtHouseno.Text = dr("No")
            txtStreet.Text = dr("Street")
            ComboBox2.Text = dr("Purok")
            txtPlaceofbirth.Text = dr("Place_of_Birth")
            DateTimePicker1.Value = dr("Birthdate")
            txtSex.Text = dr("Sex")
            txtCivil.Text = dr("Civil Status")
            txtCitizenship.Text = dr("Citizenship")
            txtOccupation.Text = dr("Occupation")
            sexChecker()
            civilChecker()
            dr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
    End Sub

    'RADIOBUTTON MALE
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        txtSex.Text = "MALE"
    End Sub

    'RADIOBUTTON FEMALE
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        txtSex.Text = "FEMALE"
    End Sub

    'CHECKBOX SINGLE
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        txtCivil.Text = "SINGLE"
    End Sub

    'CHECKBOX MARRIED
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        txtCivil.Text = "MARRIED"
    End Sub

    'CHECKBOX WIDOW
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        txtCivil.Text = "WIDOW"
    End Sub

    'CHECKBOX SEPARATED
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        txtCivil.Text = "SEPARATED"
    End Sub

    'LOADER
    Private Sub frmUpdateHousehold_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadInformation()
        Call purokLoad()
    End Sub

    'BUTTON UPDATE
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If con.State = ConnectionState.Closed Then
            OpenCon()
        End If
        Try
            Dim emptyTextboxes = From txt In Me.Controls.OfType(Of TextBox)() Where txt.Text.Length = 0 Select txt.Name

            If emptyTextboxes.Any Then
                MessageBox.Show("Please fill empty fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                query.Connection = con
                query.CommandText = "UPDATE tblHousehold SET [Last_Name] = '" & txtLast.Text & "', [First_Name] = '" & txtFirst.Text & "', [Middle] = '" & txtMiddle.Text & "', [Ext] = '" & ComboBox1.Text & "', [No] = '" & txtHouseno.Text &
                    "', [Street] = '" & txtStreet.Text & "', [Purok] = '" & ComboBox2.Text & "', [Place_of_Birth] = '" & txtPlaceofbirth.Text & "', [Birthdate] = '" & DateTimePicker1.Text & "', [Sex] = '" & txtSex.Text & "', [Civil Status] = '" & txtCivil.Text &
                    "', [Citizenship] = '" & txtCitizenship.Text & "', [Occupation] = '" & txtOccupation.Text & "'  WHERE [Household_ID] = " & frmDashboard.txtHouseID.Text & ""
                query.ExecuteNonQuery()
                MessageBox.Show("Update Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call frmDashboard.loadHousehold()
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
        Call frmDashboard.loadHousehold()
    End Sub

    'BUTTON BACK
    Private Sub btnBac_Click(sender As Object, e As EventArgs) Handles btnBac.Click
        Me.Close()
    End Sub


End Class
Public Class frmAddHousehold

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

    'LOADER
    Private Sub frmAddHousehold_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        purokLoad()
        txtRegion.Text = "IV - A"
        txtProvince.Text = "LAGUNA"
        txtCityMun.Text = "BIÑAN"
        txtBrgy.Text = "TRIMEX"
        txtSex.Hide()
        txtCivil.Hide()
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If con.State = ConnectionState.Closed Then
            OpenCon()
        End If
        Dim emptyTextboxes = From txt In Me.Controls.OfType(Of TextBox)() Where txt.Text.Length = 0 Select txt.Name

        If emptyTextboxes.Any Then
            MessageBox.Show("Please fill empty fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                query.Connection = con
                query.CommandText = "INSERT INTO tblHousehold([Last_Name], [First_Name], [Middle], [Ext], [No], [Street], [Purok], [Place_of_Birth], [Birthdate], [Sex], [Civil Status], [Citizenship], [Occupation]) VALUES('" _
                    & txtLast.Text & "', '" & txtFirst.Text & "', '" & txtMiddle.Text & "', '" & ComboBox1.Text & "', '" & txtHouseno.Text & "', '" & txtStreet.Text & "', '" & ComboBox2.Text & "', '" & txtPlaceofbirth.Text &
                    "', '" & DateTimePicker1.Text & "', '" & txtSex.Text & "', '" & txtCivil.Text & "', '" & txtCitizenship.Text & "', '" & txtOccupation.Text & "')"
                query.ExecuteNonQuery()
                MessageBox.Show("New Record Has Been Added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call frmDashboard.loadHousehold()
                txtLast.Clear()
                txtFirst.Clear()
                txtMiddle.Clear()
                ComboBox1.Text = ""
                DateTimePicker1.Value = "1/1/2000"
                txtPlaceofbirth.Clear()
                txtSex.Clear()
                txtCivil.Clear()
                txtCitizenship.Clear()
                txtOccupation.Clear()
                txtHouseno.Clear()
                txtStreet.Clear()
                ComboBox2.Text = ""
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            con.Close()
        End If
    End Sub

    Private Sub btnBac_Click(sender As Object, e As EventArgs) Handles btnBac.Click
        Me.Hide()
    End Sub
End Class
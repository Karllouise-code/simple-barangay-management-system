Imports System.Data.OleDb
Imports System.IO
Public Class frmRegister

    'LOADER 
    Private Sub frmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Hide()
        LinkLabel1.Hide()
        'TEXTBOXES
        txtFullname.Hide()
        txtUsername.Hide()
        txtContactNumber.Hide()
        txtPassword.Hide()
        txtConfirmPassword.Hide()
        txtSecretword.Hide()
        'LABELS
        lblFullname.Hide()
        lblUsername.Hide()
        lblPassword.Hide()
        lblConfirmPass.Hide()
        lblContactNumber.Hide()
        lblSecretWord.Hide()
        lblDateTime.Text = Today
    End Sub

    'COMBO BOX
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Employee" Then
            PictureBox1.Show()
            LinkLabel1.Show()
            'TEXTBOXES
            txtFullname.Show()
            txtUsername.Show()
            txtContactNumber.Show()
            txtPassword.Show()
            txtConfirmPassword.Show()
            txtSecretword.Hide()
            'LABELS
            lblFullname.Show()
            lblUsername.Show()
            lblContactNumber.Show()
            lblPassword.Show()
            lblConfirmPass.Show()
            lblSecretWord.Hide()

        ElseIf ComboBox1.Text = "Admin" Then

            PictureBox1.Hide()
            LinkLabel1.Hide()

            'TEXTBOXES
            txtFullname.Hide()
            txtUsername.Hide()
            txtContactNumber.Hide()
            txtPassword.Hide()
            txtConfirmPassword.Hide()

            'LABELS
            lblFullname.Hide()
            lblUsername.Hide()
            lblPassword.Hide()
            lblConfirmPass.Hide()
            lblContactNumber.Hide()

            lblSecretWord.Show()
            txtSecretword.Show()
        End If
    End Sub

    'SECRET WORD FOR ADMIN
    Private Sub txtSecretword_TextChanged(sender As Object, e As EventArgs) Handles txtSecretword.TextChanged
        If txtSecretword.Text = "secret" Then
            txtSecretword.Hide()
            lblSecretWord.Hide()
            txtSecretword.Clear()
            'TEXTBOXES
            txtFullname.Show()
            txtUsername.Show()
            txtContactNumber.Show()
            txtPassword.Show()
            txtConfirmPassword.Show()
            'LABELS
            lblFullname.Show()
            lblUsername.Show()
            lblContactNumber.Show()
            lblPassword.Show()
            lblConfirmPass.Show()
        End If
    End Sub

    'BUTTON BACK
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        frmStart.Show()
    End Sub

    'BUTTON REGISTER
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

        If con.State = ConnectionState.Closed Then
            OpenCon()
        End If

        If txtFullname.Text = "" Or txtUsername.Text = "" Or txtContactNumber.Text = "" Or txtPassword.Text = "" Or txtConfirmPassword.Text = "" Then
            MessageBox.Show("Please Enter Empty Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf ComboBox1.Text = "Admin" Then
            'Validation on database if the account is already registerd
            Using cmd As New OleDbCommand("SELECT COUNT(*) FROM tblAdmin WHERE [Username] = @Username", con)
                cmd.Parameters.AddWithValue("@Username", OleDbType.VarChar).Value = txtUsername.Text.Trim
                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("Whoops! Username has already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Using

            'If Username is available
            Using create As New OleDbCommand("INSERT INTO tblAdmin([Fullname], [Username], [Contact_Number], [Password], [Date_Created]) VALUES(@Fullname, @Username, @Contact_Number, @Password, @Date_Created)", con)
                If txtPassword.Text = txtConfirmPassword.Text Then
                    create.Parameters.AddWithValue("@Fullname", OleDbType.VarChar).Value = txtFullname.Text.Trim
                    create.Parameters.AddWithValue("@Username", OleDbType.VarChar).Value = txtUsername.Text.Trim
                    create.Parameters.AddWithValue("@Contact_Number", OleDbType.VarChar).Value = txtPassword.Text.Trim
                    create.Parameters.AddWithValue("@Password", OleDbType.VarChar).Value = txtPassword.Text.Trim
                    create.Parameters.AddWithValue("@Date_Created", OleDbType.VarChar).Value = lblDateTime.Text.Trim

                    If create.ExecuteNonQuery Then
                        MessageBox.Show("Account Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtFullname.Clear()
                        txtUsername.Clear()
                        txtContactNumber.Clear()
                        txtPassword.Clear()
                        txtConfirmPassword.Clear()
                    End If
                Else
                    MessageBox.Show("Password Mismatch!")
                    txtPassword.Clear()
                    txtConfirmPassword.Clear()
                End If
            End Using

        Else
            'Validation on database if the account is already registerd
            Using cmdUser As New OleDbCommand("SELECT COUNT(*) FROM tblEmployee WHERE [Username] = @Username", con)
                cmdUser.Parameters.AddWithValue("@Username", OleDbType.VarChar).Value = txtUsername.Text.Trim
                Dim count = Convert.ToInt32(cmdUser.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("Whoops! Username has already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtUsername.Clear()
                    txtPassword.Clear()
                    txtConfirmPassword.Clear()
                    txtContactNumber.Clear()
                    Exit Sub
                End If
            End Using

            'If Username is available
            Using createUser As New OleDbCommand("INSERT INTO tblEmployee([Fullname], [Username], [Contact_Number], [Password], [Date_Created] , [Status], [Pic]) VALUES(@Fullname, @Username, @Contact_Number, @Password, @Date_Created, @Status, @Pic)", con)
                If PictureBox1.Image Is Nothing Then
                    MessageBox.Show("Please Put Picture!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                ElseIf txtPassword.Text = txtConfirmPassword.Text Then
                    createUser.Parameters.AddWithValue("@Fullname", OleDbType.VarChar).Value = txtFullname.Text.Trim
                    createUser.Parameters.AddWithValue("@Username", OleDbType.VarChar).Value = txtUsername.Text.Trim
                    createUser.Parameters.AddWithValue("@Contact_Number", OleDbType.VarChar).Value = txtContactNumber.Text.Trim
                    createUser.Parameters.AddWithValue("@Password", OleDbType.VarChar).Value = txtPassword.Text.Trim
                    createUser.Parameters.AddWithValue("@Date_Created", OleDbType.VarChar).Value = lblDateTime.Text.Trim
                    createUser.Parameters.AddWithValue("@Status", OleDbType.VarChar).Value = "UNVERIFIED"

                    'Image Convert into Binary Format
                    Dim FileSize As New UInt32
                    Dim mstream As New System.IO.MemoryStream
                    PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim picture() As Byte = mstream.GetBuffer
                    FileSize = mstream.Length
                    mstream.Close()
                    createUser.Parameters.AddWithValue("@Pic", picture)

                    If createUser.ExecuteNonQuery Then
                        MessageBox.Show("Account Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtFullname.Clear()
                        txtUsername.Clear()
                        txtContactNumber.Clear()
                        txtPassword.Clear()
                        txtConfirmPassword.Clear()
                        PictureBox1.Image = Nothing
                    End If
                Else
                    MessageBox.Show("Password Mismatch!")
                    txtPassword.Clear()
                    txtConfirmPassword.Clear()
                End If
            End Using
            con.Close()
        End If
    End Sub

    'LINK LABEL
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim pop As OpenFileDialog = New OpenFileDialog
        If pop.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            PictureBox1.Image = Image.FromFile(pop.FileName)
        End If
    End Sub

    'BUTTON LOGIN INSTEAD
    Private Sub btnLoginIns_Click(sender As Object, e As EventArgs) Handles btnLoginIns.Click
        frmLogin.Show()
        Me.Hide()
    End Sub
End Class
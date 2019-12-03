Imports System.Data.Odbc
Public Class Form1
    Dim saldoSekarang As Integer
    Sub TampilGrid()
        bukakoneksi()

        DA = New OdbcDataAdapter("select * From aplikasi_kas ", CONN)
        DS = New DataSet
        DA.Fill(DS, "aplikasi_kas")
        DataGridView1.DataSource = DS.Tables("aplikasi_kas")

        tutupkoneksi()
    End Sub

    Sub saldo_sekarang()
        bukakoneksi()

        CMD = New OdbcCommand("select * from aplikasi_kas order by id_kas desc limit 1", CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            saldo.Text = "0"
        Else
            saldo.Text = RD.Item("saldo_sekarang")
            saldoSekarang = RD.Item("saldo_sekarang")
        End If

        tutupkoneksi()
    End Sub
    Sub MunculCombo()
        ComboBox1.Items.Add("Masuk")
        ComboBox1.Items.Add("Keluar")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilGrid()
        MunculCombo()
        saldo_sekarang()
    End Sub

    Sub KosongkanData()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress

        TextBox2.MaxLength = 20
        If e.KeyChar = Chr(13) Then
            bukakoneksi()
            CMD = New OdbcCommand("Select * from aplikasi_kas where keterangan ='" & TextBox2.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                MsgBox("Keterangan Tidak Ada, Silahkan coba lagi!")
                TextBox2.Focus()
            Else
                DateTimePicker1.Text = RD.Item("tanggal")
                ComboBox1.Text = RD.Item("jenis")
                TextBox1.Text = RD.Item("jumlah")
                TextBox2.Text = RD.Item("keterangan")
                TextBox2.Focus()
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Or DateTimePicker1.Text = "" Then
            MsgBox("Silahkan Isi Semua Form")
        Else
            bukakoneksi()

            If ComboBox1.Text = "Masuk" Then
                saldoSekarang = saldoSekarang + TextBox1.Text
                saldo.Text = saldoSekarang
            ElseIf ComboBox1.Text = "Keluar" Then
                If saldoSekarang < TextBox1.Text Then
                    MsgBox("Saldo Utama Tidak Cukup")
                Else
                    saldoSekarang = saldoSekarang - TextBox1.Text
                    saldo.Text = saldoSekarang
                End If
            End If
            Dim simpan As String = "insert into aplikasi_kas values ('" & "','" & DateTimePicker1.Text & "','" & ComboBox1.Text & "','" & TextBox1.Text & "','" & saldosekarang & "','" &
                TextBox2.Text & "')"

            CMD = New OdbcCommand(simpan, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Input data berhasil")
            TampilGrid()
            KosongkanData()
            tutupkoneksi()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        bukakoneksi()
        Dim edit As String = "update aplikasi_kas set
        tanggal='" & DateTimePicker1.Text & "',
        jenis='" & ComboBox1.Text & "',
        jumlah='" & TextBox1.Text & "',
        keterangan='" & TextBox2.Text & "'
        where keterangan ='" & TextBox2.Text & "'"

        CMD = New OdbcCommand(edit, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Data Berhasil diUpdate")
        TampilGrid()
        KosongkanData()
        tutupkoneksi()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("Silahkan Pilih Data yang akan dihapus dengan Masukan keterangan dan Enter")
        Else
            If MessageBox.Show("Yakin akan dihapus..? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) Then
                bukakoneksi()
                Dim hapus As String = "delete from aplikasi_kas where keterangan ='" & TextBox2.Text & "'"
                CMD = New OdbcCommand(hapus, CONN)
                CMD.ExecuteNonQuery()
                TampilGrid()
                KosongkanData()
                tutupkoneksi()
            End If
        End If
    End Sub
End Class
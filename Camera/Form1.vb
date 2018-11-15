Imports AForge.Video.DirectShow
Imports AForge.Video
Imports System.IO
Imports AForge


Public Class Form1
    Dim camera As VideoCaptureDevice
    Dim bmp As Bitmap

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
        If cameras.showDialog() = Windows.Forms.DialogResult.OK Then
            camera = cameras.videodevice
            AddHandler camera.NewFrame, New NewFrameEventHandler(AddressOf Captured)
            camera.Start()
        End If
    End Sub
    Private Sub Captured(sender As Object, eventargs As NewFrameEventArgs)
        bmp = DirectCast(eventargs.Frame.Clone(), Bitmap)
        PictureBox1.Image = DirectCast(eventargs.Frame.Clone(), Bitmap)


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox2.Image = PictureBox1.Image
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveFileDialog1.DefaultExt = ".bmp"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox2.Image.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Bmp)

        End If
    End Sub
    Private Sub form1_formCLosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        camera.Stop()
    End Sub
End Class

Imports System.IO
Imports System.Drawing.Imaging

Module ItemConverter
    Public Function BinaryToImage(imageBytes As Byte()) As Image
        'Convertir una matriz de bytes en imagen.
        Using tempStream As MemoryStream = New MemoryStream(imageBytes, 0, imageBytes.Length)
            tempStream.Write(imageBytes, 0, imageBytes.Length)
            Dim image As Image = Image.FromStream(tempStream, True)
            Return image
        End Using
    End Function

    Public Function ImageToBinary(image As Image) As Byte()
        'Convertir una imagen en una matriz de bytes.
        Using tempStream As MemoryStream = New MemoryStream()
            image.Save(tempStream, ImageFormat.Png)
            tempStream.Seek(0, SeekOrigin.Begin)
            Dim imageBytes As Byte() = tempStream.ToArray()
            Return imageBytes
        End Using
    End Function
End Module

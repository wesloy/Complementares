Imports System.IO
Imports System.Net
Imports System.Drawing

Public Class googleMaps

    Dim chave_google_api As String = "AIzaSyChyr_KEaT9q-_oAxpnnzLT3NYvTYy1pAg"
    Dim url_google_api As String = "https://maps.googleapis.com/maps/api/streetview?size=@LARGURAx@ALTURA&location=@ENDERECO@NUMERO@CIDADE@UF&fov=90&heading=$i&pitch=0&sensor=false&key=@CHAVE"
    Dim url_google_api_satelite As String = "https://maps.googleapis.com/maps/api/staticmap?center=@ENDERECO@NUMERO@CIDADE@UF&zoom=19&size=@LARGURAx@ALTURA&maptype=satellite&markers=color:blue|@ENDERECO@NUMERO@CIDADE@UF&key=@CHAVE"
    Dim url_google_api_geocode As String = "https://maps.googleapis.com/maps/api/geocode/json?address=@ENDERECO@NUMERO@CIDADE@UF&key=@CHAVE"

#Region "Metodos"
    Public Function imgRua(endereco As String,
                           nro As String,
                           city As String,
                           uf As String,
                           Optional img_altura As String = "400",
                           Optional img_largura As String = "600") As Image
        Try
            Dim url As String
            url = url_google_api.Replace("@CHAVE", chave_google_api)
            url = url.Replace("@LARGURA", img_largura)
            url = url.Replace("@ALTURA", img_altura)
            url = url.Replace("@ENDERECO", endereco & " ")
            url = url.Replace("@NUMERO", nro & " ")
            url = url.Replace("@CIDADE", city & " ")
            url = url.Replace("@UF", uf)
            Dim img As Image = getPicture(url)
            Return img
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function imgSatelite(endereco As String,
                           nro As String,
                           city As String,
                           uf As String,
                           Optional img_altura As String = "400",
                           Optional img_largura As String = "600") As Image
        Try
            Dim url As String
            url = url_google_api_satelite.Replace("@CHAVE", chave_google_api)
            url = url.Replace("@LARGURA", img_largura)
            url = url.Replace("@ALTURA", img_altura)
            url = url.Replace("@ENDERECO", endereco & " ")
            url = url.Replace("@NUMERO", nro & " ")
            url = url.Replace("@CIDADE", city & " ")
            url = url.Replace("@UF", uf)
            Dim img As Image = getPicture(url)
            Return img
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function geoLocalizacao(endereco As String,
                           nro As String,
                           city As String,
                           uf As String,
                           Optional img_altura As String = "400",
                           Optional img_largura As String = "600") As String
        Try
            Dim url As String
            url = url_google_api_geocode.Replace("@CHAVE", chave_google_api)
            url = url.Replace("@LARGURA", img_largura)
            url = url.Replace("@ALTURA", img_altura)
            url = url.Replace("@ENDERECO", endereco & " ")
            url = url.Replace("@NUMERO", nro & " ")
            url = url.Replace("@CIDADE", city & " ")
            url = url.Replace("@UF", uf)
            Dim img As String = GetJsonGeoLocalizacao(url)
            Return img
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function salvarImagem(img As Image, diretorio As String, nomeArquivo As String) As Boolean
        Try
            Dim imagePath As String = diretorio + nomeArquivo
            img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function getPicture(ByVal url As String) As Image
        Try
            url = Trim(url)
            Dim web_client As New WebClient()
            'web_client.Headers.Add("Content-Type", "application/json; charset=utf-8")
            Dim image_stream As New _
                MemoryStream(web_client.DownloadData(url))
            Return Image.FromStream(image_stream)
        Catch ex As Exception
            'MsgBox(ex.Message, vbCritical, "Alerta")
            Return Nothing
        End Try
    End Function
    Private Function GetJsonGeoLocalizacao(ByVal url As String) As String
        Try
            url = Trim(url)
            Dim web_client As New WebClient()
            web_client.Headers.Add("Content-Type", "application/json; charset=utf-8")
            'WebClient client = New WebClient();
            'client.UseDefaultCredentials = True;
            'client.Credentials = New NetworkCredential("username", "password");
            Dim str_json As String = web_client.DownloadString(url)


            Return str_json
            'Dim j As Object = New JavaScriptSerializer().Deserialize(Of Object)(str_json)
            'j.("nomecampo")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Alerta")
            Return Nothing
        End Try
    End Function
    Public Function imgToByteArray(ByVal img As Image) As Byte()
        Using mStream As New MemoryStream()
            img.Save(mStream, img.RawFormat)
            Return mStream.ToArray()
        End Using
    End Function
    Public Function byteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Using mStream As New MemoryStream(byteArrayIn)
            Return Image.FromStream(mStream)
        End Using
    End Function
    Public Function imgToByteConverter(ByVal inImg As Image) As Byte()
        Dim imgCon As New ImageConverter()
        Return DirectCast(imgCon.ConvertTo(inImg, GetType(Byte())), Byte())
    End Function
#End Region
End Class


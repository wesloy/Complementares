Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Public Class metodosRequest

#Region "REQUEST [POST/GET/PUT]"

    'Private Function getToken(user As String, pwd As String, url As String) As String
    '    'Dim json As New JavaScriptSerializer()
    '    'Dim param As String = "grant_type=password&username=" & user.ToString & "&password=" & pwd.ToString
    '    'json.MaxJsonLength = Int32.MaxValue
    '    'Dim sJson As String = ""
    '    'Dim obj As New objetos.Token
    '    'sJson = getKey(param, url)
    '    'obj = json.Deserialize(Of objetos.Token)(sJson)
    '    ''Dim j As Object = New JavaScriptSerializer().Deserialize(Of Object)(sJson)
    '    ''j.("nomecampo") or j("nomecampo").ToString
    '    'Return obj.access_token.ToString
    'End Function
    Private Function getKey(param As String, url As String) As String
        Dim responseData As String = ""
        Try
            ' Create a request for the URL. 
            Dim request As WebRequest = WebRequest.Create(url)
            'Proxy Default
            'System.Net.ServicePointManager.Expect100Continue = False
            'Dim credentials As System.Net.NetworkCredential = CredentialCache.DefaultCredentials
            'System.Net.WebRequest.DefaultWebProxy.Credentials = credentials
            'request.Credentials = credentials
            If request.Proxy IsNot Nothing Then
                request.Proxy.Credentials = CredentialCache.DefaultCredentials
            End If
            request.Method = "POST"
            request.ContentType = "application/x-www-form-urlencoded"
            Dim bytes As Byte() = System.Text.Encoding.ASCII.GetBytes(param)
            request.ContentLength = bytes.Length
            Dim os As System.IO.Stream = request.GetRequestStream()
            os.Write(bytes, 0, bytes.Length)
            os.Close()
            ' Get the response.
            Dim response As WebResponse = request.GetResponse()
            ' Get the stream containing content returned by the server.
            Dim dataStream As Stream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.
            Dim reader As New StreamReader(dataStream)
            ' Read the content.
            Dim responseFromServer As String = reader.ReadToEnd()
            responseData = responseFromServer
            ' Clean up the streams and the response.
            reader.Close()
            response.Close()
        Catch e As Exception
            'responseData = "An error occurred: " & e.Message
        End Try
        Return responseData
    End Function
    Public Function postData(ByVal url As String, ByVal strJSON As String, ByVal token As String) As String
        Try
            Dim strURL As String
            Dim myWebReq As HttpWebRequest
            Dim myWebResp As HttpWebResponse
            Dim encoding As New System.Text.UTF8Encoding
            Dim getData__1 As String = ""
            Dim sr As StreamReader
            getData__1 = getData__1 & strJSON
            Dim data As Byte() = encoding.GetBytes(getData__1)
            strURL = url
            myWebReq = DirectCast(WebRequest.Create(strURL), HttpWebRequest)
            myWebReq.ContentType = "application/json; charset=utf-8"
            myWebReq.Headers.Add("Authorization", token)
            myWebReq.ContentLength = data.Length
            myWebReq.Method = "POST"
            myWebReq.KeepAlive = True
            'myWebReq.UserAgent = ".NET Framework Test Client"
            If myWebReq.Proxy IsNot Nothing Then
                myWebReq.Proxy.Credentials = CredentialCache.DefaultCredentials
            End If
            Dim myStream As Stream = myWebReq.GetRequestStream()
            If data.Length > 0 Then
                myStream.Write(data, 0, data.Length)
                myStream.Close()
            End If
            myWebResp = DirectCast(myWebReq.GetResponse(), HttpWebResponse)
            sr = New StreamReader(myWebResp.GetResponseStream())
            Dim strJSON__2 As String = sr.ReadToEnd()
            Dim HTTP_Status_Code As Integer = myWebResp.StatusCode

            ' Clean up the streams and the response.
            myWebResp.Close()
            sr.Close()

            '200: OK - TOKEN | MESSAGE
            If HTTP_Status_Code = 200 Then
                'Dim j As Object = New JavaScriptSerializer().Deserialize(Of Object)(strJSON__2)
                'j.("nomecampo")
                Return strJSON__2

                '201: OK - ANALISE                
            ElseIf HTTP_Status_Code = 201 Then
                'Dim j As Object = New JavaScriptSerializer().Deserialize(Of Object)(strJSON__2)
                'j.("nomecampo")
                Return strJSON__2
            Else
                Return ""
            End If

        Catch e As Exception
            'MsgBox("An error occurred: " & e.Message, vbCritical)
            Return ""
        End Try
    End Function
    Public Function putData(url As String, sJson As String, token As String) As Boolean
        Try
            Dim myReq As HttpWebRequest
            Dim myResp As HttpWebResponse
            Dim myMsn As New HttpRequestHeader
            Dim encoding As New System.Text.UTF8Encoding
            Dim data As Byte() = encoding.GetBytes(sJson)
            Dim myreader As StreamReader
            Dim myText As String
            myReq = System.Net.WebRequest.Create(url)
            myReq.Method = "PUT"
            myReq.ContentType = "application/json"
            myReq.Headers.Add("Authorization", token)
            myReq.Accept = "Accept=application/json"
            If myReq.Proxy IsNot Nothing Then
                myReq.Proxy.Credentials = CredentialCache.DefaultCredentials
            End If
            myReq.GetRequestStream.Write(System.Text.Encoding.UTF8.GetBytes(sJson), 0, System.Text.Encoding.UTF8.GetBytes(sJson).Count)
            myResp = myReq.GetResponse()
            myreader = New System.IO.StreamReader(myResp.GetResponseStream)
            myText = myreader.ReadToEnd

            ' Clean up the streams and the response.
            myResp.Close()
            myreader.Close()

            Dim HTTP_Status_Code As Integer = myResp.StatusCode
            If HTTP_Status_Code = 201 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function getData(urlRequest As String, token As String) As String
        Dim responseData As String = ""
        Try
            ' Create a request for the URL. 
            Dim request As WebRequest = WebRequest.Create(urlRequest)

            If request.Proxy IsNot Nothing Then
                request.Proxy.Credentials = CredentialCache.DefaultCredentials
            End If

            request.Method = "GET"
            request.Headers.Add("Authorization", token)
            request.ContentType = "application/json"

            ' Get the response.
            Dim response As WebResponse = request.GetResponse()
            ' Get the stream containing content returned by the server.
            Dim dataStream As Stream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.
            Dim reader As New StreamReader(dataStream)
            ' Read the content.
            Dim responseFromServer As String = reader.ReadToEnd()
            responseData = responseFromServer

            ' Clean up the streams and the response.
            reader.Close()
            response.Close()
            Return responseData
        Catch e As Exception
            Return ""
            'responseData = "An error occurred: " & e.Message
        End Try

    End Function
#End Region

#Region "JSON"
    Public Function JsonDeserializeTOKEN(strJson As String) As objetos.RootObjectToken
        Dim json As New JavaScriptSerializer()
        json.MaxJsonLength = Int32.MaxValue
        Try
            Return json.Deserialize(Of objetos.RootObjectToken)(strJson)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function JsonSerializeOcorrencia(obj As objetos.RootObjectOcorrencia) As String
        Try
            Dim json As New JavaScriptSerializer
            json.MaxJsonLength = Int32.MaxValue
            Return json.Serialize(obj)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Public Function JsonDeserializeOcorrencia(strJson As String) As objetos.RootObjectRetornoOcorrencia
        Dim json As New JavaScriptSerializer()
        json.MaxJsonLength = Int32.MaxValue
        Try
            Return json.Deserialize(Of objetos.RootObjectRetornoOcorrencia)(strJson)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function JsonDeserializeMessage(strJson As String) As objetos.RootObjectMessage
        Dim json As New JavaScriptSerializer()
        json.MaxJsonLength = Int32.MaxValue
        Try
            Return json.Deserialize(Of objetos.RootObjectMessage)(strJson)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function JsonDeserializeResultadoFinalAnalise(strJson As String) As objetos.RootObjectResultadoFinalAnalise
        Dim json As New JavaScriptSerializer()
        json.MaxJsonLength = Int32.MaxValue
        Try
            Return json.Deserialize(Of objetos.RootObjectResultadoFinalAnalise)(strJson)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function JsonDeserializeResultadoFinalAnaliseObject(strJson As String) As Object
        Dim json As New JavaScriptSerializer()
        json.MaxJsonLength = Int32.MaxValue
        Try
            Return json.Deserialize(Of Object)(strJson)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function JsonDeserializeGeoLocalizacao(strJson As String) As objetos.RootObjectGeoLocalizacao
        Dim json As New JavaScriptSerializer()
        json.MaxJsonLength = Int32.MaxValue
        Try
            Return json.Deserialize(Of objetos.RootObjectGeoLocalizacao)(strJson)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region
End Class

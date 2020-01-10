Public Class objetos

#Region "ANALISE"
    Public Class RootObjectOcorrencia
        Public Property guid As String
        Public Property queue As String
        Public Property task As String
        Public Property client As String
        Public Property status As String
        Public Property cpf As String
        Public Property address As Address
        Public Property oldAddress As Oldaddress
        Public Property firstPhone As String
        Public Property secondPhone As String
        Public Property thirdPhone As String
    End Class
    Public Class Address
        Public Property street As String
        Public Property number As String
        Public Property complement As String
        Public Property neighborhood As String
        Public Property city As String
        Public Property state As String
        Public Property zipCode As String
    End Class
    Public Class Oldaddress
        Public Property street As String
        Public Property number As String
        Public Property complement As String
        Public Property neighborhood As String
        Public Property city As String
        Public Property state As String
        Public Property zipCode As String
    End Class
#End Region

#Region "TOKEN"
    Public Class RootObjectToken
        Public Property token As String
        Public Property user As User
    End Class
    Public Class User
        Public Property _id As String
        Public Property name As String
        Public Property email As String
        Public Property picture As String
        Public Property createdAt As Date
        Public Property updatedAt As Date
    End Class
#End Region

#Region "RETORNO OCORRENCIA"
    Public Class RootObjectRetornoOcorrencia
        Public Property token As String
        Public Property occurrence As Ocorrencia
    End Class
    Public Class Ocorrencia
        Inherits RootObjectOcorrencia
        Public Property _id As String
        Public Property createdAt As Date
        Public Property updatedAt As Date
    End Class
#End Region

#Region "MESSAGE"
    Public Class RootObjectMessage
        Public Property message As String
    End Class
#End Region

#Region "Resultado final ANALISE"
    Public Class RootObjectResultadoFinalAnalise
        Public Property count As Integer
        Public Property rows As List(Of Row)
    End Class

    Public Class Row
        Public Property _id As String
        Public Property title As String
        Public Property time As Integer
        Public Property type As String
        Public Property steps As Steps
        Public Property occurrence As String
        Public Property createdAt As Date
        Public Property updatedAt As Date
    End Class

    Public Class Steps
        Public Property buscando_ocorrencia As Buscando_Ocorrencia
        Public Property ocorrencia_encontrada As Ocorrencia_Encontrada
        Public Property validando_CPF_de_origem As Validando_CPF_De_Origem
        Public Property validando_mudanca_de_estado As Validando_Mudanca_De_Estado
        Public Property validando_endereco_de_origem_e_antigo As Validando_Endereco_De_Origem_E_Antigo
        Public Property latitude_e_longitude As Latitude_E_Longitude
        Public Property distancia_em_metros As Distancia_Em_Metros
        Public Property endereco_para_busca_endereco_atual As Endereco_Para_Busca_Endereco_Atual
        Public Property requisitando_google_street_view_endereco_atual As Requisitando_Google_Street_View_Endereco_Atual
        Public Property resposta_google_street_view_endereco_atual As Resposta_Google_Street_View_Endereco_Atual
        Public Property endereco_para_busca_endereco_anterior As Endereco_Para_Busca_Endereco_Anterior
        Public Property requisitando_google_street_view_endereco_anterior As Requisitando_Google_Street_View_Endereco_Anterior
        Public Property resposta_google_street_view_endereco_anterior As Resposta_Google_Street_View_Endereco_Anterior
        Public Property requisitando_google_maps_endereco_atual As Requisitando_Google_Maps_Endereco_Atual
        Public Property resposta_google_maps_endereco_atual As Resposta_Google_Maps_Endereco_Atual
        Public Property requisitando_google_maps_endereco_anterior As Requisitando_Google_Maps_Endereco_Anterior
        Public Property resposta_google_maps_endereco_anterior As Resposta_Google_Maps_Endereco_Anterior
        Public Property requisitando_google_vision As Requisitando_Google_Vision
        Public Property resposta_google_vision As Resposta_Google_Vision
        Public Property requisitando_aws_recognition As Requisitando_Aws_Recognition
        Public Property resposta_aws_recognition As Resposta_Aws_Recognition
    End Class

    Public Class Buscando_Ocorrencia
        Public Property id As String
    End Class

    Public Class Ocorrencia_Encontrada
        Public Property occurrence As Occurrence
    End Class

    Public Class Occurrence
        Inherits RootObjectOcorrencia
        Public Property keywords As List(Of String)
        Public Property _id As String
        Public Property createdAt As Date
        Public Property updatedAt As Date
        Public Property __v As Integer
    End Class


    Public Class Validando_CPF_De_Origem
        Public Property cpf As String
        Public Property validationDigit As String
        Public Property homeState As List(Of String)
    End Class

    Public Class Validando_Mudanca_De_Estado
        Public Property message As String
        Public Property currentState As String
        Public Property oldState As String
    End Class

    Public Class Validando_Endereco_De_Origem_E_Antigo
        Public Property currentAddress As String
        Public Property oldAddress As String
    End Class

    Public Class Latitude_E_Longitude
        Public Property currentAddress As Currentaddress
        Public Property oldAddress As Oldaddress1
    End Class

    Public Class Currentaddress
        Public Property lat As Single
        Public Property lng As Single
    End Class

    Public Class Oldaddress1
        Public Property lat As Single
        Public Property lng As Single
    End Class

    Public Class Distancia_Em_Metros
        Public Property distanceInMeters As Integer
    End Class

    Public Class Endereco_Para_Busca_Endereco_Atual
        Public Property address As String
    End Class

    Public Class Requisitando_Google_Street_View_Endereco_Atual
        Public Property url As String
        Public Property method As String
        Public Property encoding As Object
    End Class

    Public Class Resposta_Google_Street_View_Endereco_Atual
        Public Property image As String
    End Class

    Public Class Endereco_Para_Busca_Endereco_Anterior
        Public Property address As String
    End Class

    Public Class Requisitando_Google_Street_View_Endereco_Anterior
        Public Property url As String
        Public Property method As String
        Public Property encoding As Object
    End Class

    Public Class Resposta_Google_Street_View_Endereco_Anterior
        Public Property image As String
    End Class

    Public Class Requisitando_Google_Maps_Endereco_Atual
        Public Property url As String
        Public Property method As String
        Public Property encoding As Object
    End Class

    Public Class Resposta_Google_Maps_Endereco_Atual
        Public Property image As String
    End Class

    Public Class Requisitando_Google_Maps_Endereco_Anterior
        Public Property url As String
        Public Property method As String
        Public Property encoding As Object
    End Class

    Public Class Resposta_Google_Maps_Endereco_Anterior
        Public Property image As String
    End Class

    Public Class Requisitando_Google_Vision
        Public Property url As String
        Public Property method As String
        Public Property headers As Headers
        Public Property body As Body
        Public Property json As Boolean
    End Class

    Public Class Headers
        Public Property ContentType As String
    End Class

    Public Class Body
        Public Property requests As List(Of Request)
    End Class

    Public Class Request
        Public Property image As Image
        Public Property features As List(Of Feature)
    End Class

    Public Class Image
        Public Property content As String
    End Class

    Public Class Feature
        Public Property type As String
        Public Property maxResults As Integer
    End Class

    Public Class Resposta_Google_Vision
        Public Property responses As List(Of Respons)
    End Class

    Public Class Respons
        Public Property labelAnnotations As List(Of Labelannotation)
        Public Property localizedObjectAnnotations As List(Of Localizedobjectannotation)
    End Class

    Public Class Labelannotation
        Public Property mid As String
        Public Property description As String
        Public Property score As Single
        Public Property topicality As Single
    End Class

    Public Class Localizedobjectannotation
        Public Property mid As String
        Public Property name As String
        Public Property score As Single
        Public Property boundingPoly As Boundingpoly
    End Class

    Public Class Boundingpoly
        Public Property normalizedVertices As List(Of Normalizedvertice)
    End Class

    Public Class Normalizedvertice
        Public Property x As Single
        Public Property y As Single
    End Class

    Public Class Requisitando_Aws_Recognition
        Public Property Image As Image1
        Public Property MaxLabels As Integer
    End Class

    Public Class Image1
        Public Property S3Object As S3object
    End Class

    Public Class S3object
        Public Property Bucket As String
        Public Property Name As String
    End Class

    Public Class Resposta_Aws_Recognition
        Public Property Labels As List(Of Label)
        Public Property LabelModelVersion As String
    End Class

    Public Class Label
        Public Property Name As String
        Public Property Confidence As Single
        Public Property Instances As List(Of Object)
        Public Property Parents As List(Of Parent)
    End Class

    Public Class Parent
        Public Property Name As String
    End Class


#End Region

#Region "GeoLocalizacao"

    Public Class RootObjectGeoLocalizacao
        Public Property results As List(Of Result)
        Public Property status As String
    End Class

    Public Class Result
        Public Property address_components As List(Of Address_Components)
        Public Property formatted_address As String
        Public Property geometry As Geometry
        Public Property place_id As String
        Public Property plus_code As Plus_Code
        Public Property types As List(Of String)
    End Class

    Public Class Geometry
        Public Property location As Location
        Public Property location_type As String
        Public Property viewport As Viewport
    End Class

    Public Class Location
        Public Property lat As Single
        Public Property lng As Single
    End Class

    Public Class Viewport
        Public Property northeast As Northeast
        Public Property southwest As Southwest
    End Class

    Public Class Northeast
        Public Property lat As Single
        Public Property lng As Single
    End Class

    Public Class Southwest
        Public Property lat As Single
        Public Property lng As Single
    End Class

    Public Class Plus_Code
        Public Property compound_code As String
        Public Property global_code As String
    End Class

    Public Class Address_Components
        Public Property long_name As String
        Public Property short_name As String
        Public Property types As List(Of String)

    End Class
#End Region





End Class

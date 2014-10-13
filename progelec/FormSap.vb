Public Class FormSap

    'Private Sub ButtonX1_Click( sender As Object,  e As EventArgs) Handles ButtonX1.Click
    '        dim ctlLogon as   SAPLogonCtrl.SAPLogonControl
    '        ctlLogon = CType(CreateObject("SAP.Logoncontrol.1"), SAPLogonCtrl.SAPLogonControl)

    'dim oConnection as SAPLogonCtrl.Connection
    'oConnection = CType(ctlLogon.NewConnection, SAPLogonCtrl.Connection)

    'oConnection.User = "lverhaeg"
    'oConnection.Client = "300"
    '        oConnection.MessageServer = "lvaprd01.cegelec.com"
    '        oConnection.SystemID = "PRD"
    'oConnection.Password = "cegelec7"
    ''oConnection.ApplicationServer = "10.250.2.49"
    'oConnection.Language = "FR"
    ''oConnection.SystemNumber = CInt("00")
    '        oConnection.GroupName = "Prd CEGELEC"

    'Dim booReturn As Boolean
    'booReturn = oConnection.Logon(0, True)

    'If booReturn <> True Then
    'MsgBox ("erreur connection")
    'Else
    'MsgBox ("connection Reussit")
    'End If

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Set funcControl = CreateObject("SAP.Functions")
    'funcControl.Connection = oConnection
    'Set oRFC = funcControl.Add("ZSIILMM002")
    'Set oText = oRFC.Exports("TEXT1")
    'Set oWerks = oRFC.Exports("WERKS1")
    'Set oProduct = oRFC.Exports("PRODUCT")
    'oText.Value = Data
    'oWerks.Value = Works
    'oProduct.Value = Product
    'If oRFC.Call = True Then
    'oStatus = oRFC.Imports("STATUS")
    'If oStatus = 1 Then ' fail
    'PostCoil = 1
    'End If
    'If oStatus = 0 Then ' success
    'PostCoil = 2
    'End If
    'If oStatus = 2 Then ' DATA ALREADY I SAP
    'PostCoil = 5
    'End If
    'Else
    'PostCoil = 4 ' RFC not executed
    'End If
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'End Sub
End Class
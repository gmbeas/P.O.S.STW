﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.4952
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace Pws0049
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="INTERFAZ LISA", ConfigurationName:="Pws0049.Pws0049SoapPort")>  _
    Public Interface Pws0049SoapPort
        
        'CODEGEN: Generating message contract since the wrapper name (Pws0049.Execute) of message ExecuteRequest does not match the default value (Execute)
        <System.ServiceModel.OperationContractAttribute(Action:="INTERFAZ LISAaction/APWS0049.Execute", ReplyAction:="*")>  _
        Function Execute(ByVal request As Pws0049.ExecuteRequest) As Pws0049.ExecuteResponse
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="Pws0049.Execute", WrapperNamespace:="INTERFAZ LISA", IsWrapped:=true)>  _
    Partial Public Class ExecuteRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="INTERFAZ LISA", Order:=0)>  _
        Public Xmlini As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Xmlini As String)
            MyBase.New
            Me.Xmlini = Xmlini
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="Pws0049.ExecuteResponse", WrapperNamespace:="INTERFAZ LISA", IsWrapped:=true)>  _
    Partial Public Class ExecuteResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="INTERFAZ LISA", Order:=0)>  _
        Public Xmlfin As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Xmlfin As String)
            MyBase.New
            Me.Xmlfin = Xmlfin
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
    Public Interface Pws0049SoapPortChannel
        Inherits Pws0049.Pws0049SoapPort, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
    Partial Public Class Pws0049SoapPortClient
        Inherits System.ServiceModel.ClientBase(Of Pws0049.Pws0049SoapPort)
        Implements Pws0049.Pws0049SoapPort
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function Pws0049_Pws0049SoapPort_Execute(ByVal request As Pws0049.ExecuteRequest) As Pws0049.ExecuteResponse Implements Pws0049.Pws0049SoapPort.Execute
            Return MyBase.Channel.Execute(request)
        End Function
        
        Public Function Execute(ByVal Xmlini As String) As String
            Dim inValue As Pws0049.ExecuteRequest = New Pws0049.ExecuteRequest
            inValue.Xmlini = Xmlini
            Dim retVal As Pws0049.ExecuteResponse = CType(Me,Pws0049.Pws0049SoapPort).Execute(inValue)
            Return retVal.Xmlfin
        End Function
    End Class
End Namespace

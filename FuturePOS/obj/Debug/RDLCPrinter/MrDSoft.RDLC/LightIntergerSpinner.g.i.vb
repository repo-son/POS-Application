﻿#ExternalChecksum("..\..\..\..\RDLCPrinter\MrDSoft.RDLC\LightIntergerSpinner.xaml","{8829d00f-11b8-4213-878b-770e8597ac16}","5CA8ED9BE4BF0E6CD2121F8CF56428D7D72AF3B966B4E4628791202856D7B6EF")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell

Namespace DSoft.RDLCReport
    
    '''<summary>
    '''LightIntergerSpinner
    '''</summary>
    <Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
    Partial Public Class LightIntergerSpinner
        Inherits System.Windows.Controls.UserControl
        Implements System.Windows.Markup.IComponentConnector
        
        
        #ExternalSource("..\..\..\..\RDLCPrinter\MrDSoft.RDLC\LightIntergerSpinner.xaml",26)
        <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
        Friend WithEvents ButtonColumn As System.Windows.Controls.ColumnDefinition
        
        #End ExternalSource
        
        
        #ExternalSource("..\..\..\..\RDLCPrinter\MrDSoft.RDLC\LightIntergerSpinner.xaml",32)
        <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
        Friend WithEvents NumPager As System.Windows.Controls.TextBox
        
        #End ExternalSource
        
        
        #ExternalSource("..\..\..\..\RDLCPrinter\MrDSoft.RDLC\LightIntergerSpinner.xaml",34)
        <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
        Friend WithEvents SpinnerUp As System.Windows.Controls.Button
        
        #End ExternalSource
        
        
        #ExternalSource("..\..\..\..\RDLCPrinter\MrDSoft.RDLC\LightIntergerSpinner.xaml",37)
        <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
        Friend WithEvents SpinnerDown As System.Windows.Controls.Button
        
        #End ExternalSource
        
        Private _contentLoaded As Boolean
        
        '''<summary>
        '''InitializeComponent
        '''</summary>
        <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
        Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
            If _contentLoaded Then
                Return
            End If
            _contentLoaded = true
            Dim resourceLocater As System.Uri = New System.Uri("/FuturePOS;component/rdlcprinter/mrdsoft.rdlc/lightintergerspinner.xaml", System.UriKind.Relative)
            
            #ExternalSource("..\..\..\..\RDLCPrinter\MrDSoft.RDLC\LightIntergerSpinner.xaml",1)
            System.Windows.Application.LoadComponent(Me, resourceLocater)
            
            #End ExternalSource
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
         System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
         System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
         System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
         System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
        Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
            If (connectionId = 1) Then
                
                #ExternalSource("..\..\..\..\RDLCPrinter\MrDSoft.RDLC\LightIntergerSpinner.xaml",7)
                AddHandler CType(target,DSoft.RDLCReport.LightIntergerSpinner).Loaded, New System.Windows.RoutedEventHandler(AddressOf Me.UserControl_Loaded)
                
                #End ExternalSource
                Return
            End If
            If (connectionId = 2) Then
                Me.ButtonColumn = CType(target,System.Windows.Controls.ColumnDefinition)
                Return
            End If
            If (connectionId = 3) Then
                Me.NumPager = CType(target,System.Windows.Controls.TextBox)
                Return
            End If
            If (connectionId = 4) Then
                Me.SpinnerUp = CType(target,System.Windows.Controls.Button)
                
                #ExternalSource("..\..\..\..\RDLCPrinter\MrDSoft.RDLC\LightIntergerSpinner.xaml",34)
                AddHandler Me.SpinnerUp.Click, New System.Windows.RoutedEventHandler(AddressOf Me.SpinnerUp_Click)
                
                #End ExternalSource
                Return
            End If
            If (connectionId = 5) Then
                Me.SpinnerDown = CType(target,System.Windows.Controls.Button)
                
                #ExternalSource("..\..\..\..\RDLCPrinter\MrDSoft.RDLC\LightIntergerSpinner.xaml",37)
                AddHandler Me.SpinnerDown.Click, New System.Windows.RoutedEventHandler(AddressOf Me.SpinnerDown_Click)
                
                #End ExternalSource
                Return
            End If
            Me._contentLoaded = true
        End Sub
    End Class
End Namespace

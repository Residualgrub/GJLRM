﻿#pragma checksum "..\..\..\SReport\SRConfigTranAddEditWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85DB5A61C213BB973479552CA7B5B2B1CBBAA9D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GlennsReportManager.SReport;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GlennsReportManager.SReport {
    
    
    /// <summary>
    /// SRConfigTranAddEditWindow
    /// </summary>
    public partial class SRConfigTranAddEditWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TXTType;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CKTax;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CKComm;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TXTRate;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TXTMin;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTSave;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTCan;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GlennsReportManager;component/sreport/srconfigtranaddeditwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TXTType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.CKTax = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.CKComm = ((System.Windows.Controls.CheckBox)(target));
            
            #line 34 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
            this.CKComm.Click += new System.Windows.RoutedEventHandler(this.CKComm_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TXTRate = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
            this.TXTRate.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TXTRate_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
            this.TXTRate.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.TXTRate_Pasting));
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 43 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TXTRate_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.TXTRate_Pasting));
            
            #line default
            #line hidden
            return;
            case 6:
            this.TXTMin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BTSave = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\SReport\SRConfigTranAddEditWindow.xaml"
            this.BTSave.Click += new System.Windows.RoutedEventHandler(this.BTSave_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BTCan = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


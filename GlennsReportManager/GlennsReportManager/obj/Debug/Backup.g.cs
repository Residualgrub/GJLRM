﻿#pragma checksum "..\..\Backup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28E600CB4A662C0305E2C5589CB4617D566418FD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GlennsReportManager;
using GlennsReportManager.UserControls;
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


namespace GlennsReportManager {
    
    
    /// <summary>
    /// Backup
    /// </summary>
    public partial class Backup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\Backup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TXTBackDate;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Backup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTRefresh;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Backup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GlennsReportManager.UserControls.DataContainerWide DriveContain;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Backup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TXTStep;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Backup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar PBBar;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Backup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTBack;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Backup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTRestore;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Backup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTHow;
        
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
            System.Uri resourceLocater = new System.Uri("/GlennsReportManager;component/backup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Backup.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.TXTBackDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BTRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Backup.xaml"
            this.BTRefresh.Click += new System.Windows.RoutedEventHandler(this.BTRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DriveContain = ((GlennsReportManager.UserControls.DataContainerWide)(target));
            return;
            case 4:
            this.TXTStep = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PBBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 6:
            this.BTBack = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Backup.xaml"
            this.BTBack.Click += new System.Windows.RoutedEventHandler(this.BTBack_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BTRestore = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.BTHow = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


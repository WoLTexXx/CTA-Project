﻿#pragma checksum "..\..\FSCWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5F1E74A4255E7A7FB1B43EFE585275E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace CTA {
    
    
    /// <summary>
    /// FSCWindow
    /// </summary>
    public partial class FSCWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\FSCWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CTA.FSCWindow FSCWindow_Main;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\FSCWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listbx_ADAccounts;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\FSCWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add_account;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\FSCWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_del_account;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\FSCWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_domain;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\FSCWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_login;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\FSCWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwbx_password;
        
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
            System.Uri resourceLocater = new System.Uri("/CTA;component/fscwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FSCWindow.xaml"
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
            this.FSCWindow_Main = ((CTA.FSCWindow)(target));
            
            #line 4 "..\..\FSCWindow.xaml"
            this.FSCWindow_Main.Closing += new System.ComponentModel.CancelEventHandler(this.FSCWindow_Main_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listbx_ADAccounts = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.btn_add_account = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\FSCWindow.xaml"
            this.btn_add_account.Click += new System.Windows.RoutedEventHandler(this.btn_add_account_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_del_account = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\FSCWindow.xaml"
            this.btn_del_account.Click += new System.Windows.RoutedEventHandler(this.btn_del_account_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txbx_domain = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txbx_login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.pwbx_password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


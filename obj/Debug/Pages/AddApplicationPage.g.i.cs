﻿#pragma checksum "..\..\..\Pages\AddApplicationPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EFAE237D83D6CD669E61B16E4469CB3CAD30312C964F867D94A7BB312EC930E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using GazLink.Pages;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace GazLink.Pages {
    
    
    /// <summary>
    /// AddApplicationPage
    /// </summary>
    public partial class AddApplicationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 53 "..\..\..\Pages\AddApplicationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearchClient;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\AddApplicationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVAppClient;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\Pages\AddApplicationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDate;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Pages\AddApplicationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearchProduct;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\Pages\AddApplicationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVAppProducts;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\..\Pages\AddApplicationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTotalSum;
        
        #line default
        #line hidden
        
        
        #line 265 "..\..\..\Pages\AddApplicationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVCheque;
        
        #line default
        #line hidden
        
        
        #line 390 "..\..\..\Pages\AddApplicationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddApplication;
        
        #line default
        #line hidden
        
        
        #line 402 "..\..\..\Pages\AddApplicationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClear;
        
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
            System.Uri resourceLocater = new System.Uri("/GazLink;component/pages/addapplicationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AddApplicationPage.xaml"
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
            this.tbSearchClient = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\..\Pages\AddApplicationPage.xaml"
            this.tbSearchClient.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbSearchClient_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LVAppClient = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.dpDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.tbSearchProduct = ((System.Windows.Controls.TextBox)(target));
            
            #line 149 "..\..\..\Pages\AddApplicationPage.xaml"
            this.tbSearchProduct.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbSearchProduct_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LVAppProducts = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.tbTotalSum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.LVCheque = ((System.Windows.Controls.ListView)(target));
            return;
            case 12:
            this.btnAddApplication = ((System.Windows.Controls.Button)(target));
            
            #line 390 "..\..\..\Pages\AddApplicationPage.xaml"
            this.btnAddApplication.Click += new System.Windows.RoutedEventHandler(this.btnAddApplication_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnClear = ((System.Windows.Controls.Button)(target));
            
            #line 402 "..\..\..\Pages\AddApplicationPage.xaml"
            this.btnClear.Click += new System.Windows.RoutedEventHandler(this.btnClear_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 219 "..\..\..\Pages\AddApplicationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAddInCheque_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 342 "..\..\..\Pages\AddApplicationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnMinus_Click);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 357 "..\..\..\Pages\AddApplicationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnPlus_Click);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 362 "..\..\..\Pages\AddApplicationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnRemoveFromCheque_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


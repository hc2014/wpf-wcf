﻿#pragma checksum "..\..\..\UserControls\VerifyUserAuthenticate.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "315CFFD9A60D3B0B3F91C489B8808CDC"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18034
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using AdminManager.UserControls;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace AdminManager.UserControls {
    
    
    /// <summary>
    /// VerifyUserAuthenticate
    /// </summary>
    public partial class VerifyUserAuthenticate : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 38 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtname;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker timefrom;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker timeto;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid1;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox All;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel bottom;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid right;
        
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
            System.Uri resourceLocater = new System.Uri("/AdminManager;component/usercontrols/verifyuserauthenticate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
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
            
            #line 10 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
            ((AdminManager.UserControls.VerifyUserAuthenticate)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.combox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.timefrom = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 5:
            this.timeto = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 6:
            
            #line 52 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 53 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 57 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
            this.DataGrid1.PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DataGrid1_PreviewMouseDoubleClick_1);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
            this.DataGrid1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid1_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.All = ((System.Windows.Controls.CheckBox)(target));
            
            #line 61 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
            this.All.Click += new System.Windows.RoutedEventHandler(this.All_Click_1);
            
            #line default
            #line hidden
            return;
            case 11:
            this.bottom = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 12:
            this.right = ((System.Windows.Controls.Grid)(target));
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
            case 10:
            
            #line 73 "..\..\..\UserControls\VerifyUserAuthenticate.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Grid_State_SelectionChanged_1);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


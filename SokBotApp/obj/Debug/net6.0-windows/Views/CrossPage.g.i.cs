﻿#pragma checksum "..\..\..\..\Views\CrossPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89819D26299E67F1EA8CC7003B22DAFD7128151D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SokBotApp.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace SokBotApp.Views {
    
    
    /// <summary>
    /// CrossPage
    /// </summary>
    public partial class CrossPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 55 "..\..\..\..\Views\CrossPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Views\CrossPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button printButton;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Views\CrossPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchByFio;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Views\CrossPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reloadButton;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Views\CrossPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendMessageButton;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Views\CrossPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox studentsCount;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\Views\CrossPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox facultyFilter;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Views\CrossPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox genderFilter;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Views\CrossPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox distanceFilter;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\Views\CrossPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewMembers;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SokBotApp;V1.1;component/views/crosspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\CrossPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\Views\CrossPage.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.printButton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\Views\CrossPage.xaml"
            this.printButton.Click += new System.Windows.RoutedEventHandler(this.printButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.searchByFio = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\..\Views\CrossPage.xaml"
            this.searchByFio.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Filter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.reloadButton = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\Views\CrossPage.xaml"
            this.reloadButton.Click += new System.Windows.RoutedEventHandler(this.reloadButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.sendMessageButton = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\Views\CrossPage.xaml"
            this.sendMessageButton.Click += new System.Windows.RoutedEventHandler(this.sendMessage_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.studentsCount = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 9:
            this.facultyFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 85 "..\..\..\..\Views\CrossPage.xaml"
            this.facultyFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Filter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.genderFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 97 "..\..\..\..\Views\CrossPage.xaml"
            this.genderFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Filter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.distanceFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 109 "..\..\..\..\Views\CrossPage.xaml"
            this.distanceFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Filter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ListViewMembers = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 1:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 23 "..\..\..\..\Views\CrossPage.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ListViewItem_MouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 2:
            
            #line 30 "..\..\..\..\Views\CrossPage.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.LinkVk_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


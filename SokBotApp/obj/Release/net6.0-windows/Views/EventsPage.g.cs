﻿#pragma checksum "..\..\..\..\Views\EventsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E827E9614E7E5E816245F04DA6D1494F2C1B1856"
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
    /// EventsPage
    /// </summary>
    public partial class EventsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\Views\EventsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Dod;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Views\EventsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CupFirstCourse;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Views\EventsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label StatsFirstCourse;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Views\EventsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Cross;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Views\EventsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Cross_More;
        
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
            System.Uri resourceLocater = new System.Uri("/SokBotApp;V1.1;component/views/eventspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\EventsPage.xaml"
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
            case 1:
            this.Dod = ((System.Windows.Controls.Label)(target));
            
            #line 39 "..\..\..\..\Views\EventsPage.xaml"
            this.Dod.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ViewEventMembers);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CupFirstCourse = ((System.Windows.Controls.Label)(target));
            
            #line 48 "..\..\..\..\Views\EventsPage.xaml"
            this.CupFirstCourse.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ViewEventMembers);
            
            #line default
            #line hidden
            return;
            case 3:
            this.StatsFirstCourse = ((System.Windows.Controls.Label)(target));
            
            #line 50 "..\..\..\..\Views\EventsPage.xaml"
            this.StatsFirstCourse.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ViewEventMembers);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Cross = ((System.Windows.Controls.Label)(target));
            
            #line 60 "..\..\..\..\Views\EventsPage.xaml"
            this.Cross.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ViewEventMembers);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Cross_More = ((System.Windows.Controls.Label)(target));
            
            #line 62 "..\..\..\..\Views\EventsPage.xaml"
            this.Cross_More.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ViewEventMembers);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


#pragma checksum "..\..\..\..\Views\DodPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21739E9991E9E0D2FE0D2509F4D1F596A065DE5B"
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
    /// DodPage
    /// </summary>
    public partial class DodPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 42 "..\..\..\..\Views\DodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button printButton;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Views\DodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchByFio;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Views\DodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reloadButton;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Views\DodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendMessageButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Views\DodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox facultyFilter;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Views\DodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox genderFilter;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Views\DodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox profFilter;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\Views\DodPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SokBotApp;V1.1;component/views/dodpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\DodPage.xaml"
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
            case 2:
            this.printButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Views\DodPage.xaml"
            this.printButton.Click += new System.Windows.RoutedEventHandler(this.printButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.searchByFio = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\..\Views\DodPage.xaml"
            this.searchByFio.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Filter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.reloadButton = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\Views\DodPage.xaml"
            this.reloadButton.Click += new System.Windows.RoutedEventHandler(this.reloadButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.sendMessageButton = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\Views\DodPage.xaml"
            this.sendMessageButton.Click += new System.Windows.RoutedEventHandler(this.sendMessage_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.facultyFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 64 "..\..\..\..\Views\DodPage.xaml"
            this.facultyFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Filter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.genderFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 76 "..\..\..\..\Views\DodPage.xaml"
            this.genderFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Filter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.profFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 88 "..\..\..\..\Views\DodPage.xaml"
            this.profFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Filter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
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
            
            #line 23 "..\..\..\..\Views\DodPage.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ListViewItem_MouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}


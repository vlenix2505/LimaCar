﻿#pragma checksum "..\..\ReporteVehiculo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "69D2C26B71CABCB45BA5608A162DBD769E8B0024CBB1B90B30CECB7C9D8B2C17"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Presentacion;
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


namespace Presentacion {
    
    
    /// <summary>
    /// ReporteVehiculo
    /// </summary>
    public partial class ReporteVehiculo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ReporteVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalir;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ReporteVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLimpiar;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ReporteVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBuscar;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ReporteVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgVehiculos;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ReporteVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTipoVehiculo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ReporteVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMayorReservas;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ReporteVehiculo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMenorReservas;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentacion;component/reportevehiculo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReporteVehiculo.xaml"
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
            this.btnSalir = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\ReporteVehiculo.xaml"
            this.btnSalir.Click += new System.Windows.RoutedEventHandler(this.btnSalir_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnLimpiar = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ReporteVehiculo.xaml"
            this.btnLimpiar.Click += new System.Windows.RoutedEventHandler(this.btnLimpiar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnBuscar = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ReporteVehiculo.xaml"
            this.btnBuscar.Click += new System.Windows.RoutedEventHandler(this.btnBuscar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dgVehiculos = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.cbTipoVehiculo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnMayorReservas = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\ReporteVehiculo.xaml"
            this.btnMayorReservas.Click += new System.Windows.RoutedEventHandler(this.btnMayorReservas_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnMenorReservas = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\ReporteVehiculo.xaml"
            this.btnMenorReservas.Click += new System.Windows.RoutedEventHandler(this.btnMenorReservas_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


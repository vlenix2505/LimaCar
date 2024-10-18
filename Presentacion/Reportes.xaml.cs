using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class Reportes : Window
    {
        public Reportes()
        {
            InitializeComponent();
        }

        

        private void btnReporteCliente_Click(object sender, RoutedEventArgs e)
        {
            ReporteCliente wdReporteCliente = new ReporteCliente();
            wdReporteCliente.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin wdmenuAdmin = new MenuAdmin();
            wdmenuAdmin.Show();
            this.Close();
        }

        private void btnReporteVehiculo_Click(object sender, RoutedEventArgs e)
        {
            ReporteVehiculo wdreporteVehiculo = new ReporteVehiculo();
            wdreporteVehiculo.Show();
            this.Close();
        }

        private void btnReportePago_Click(object sender, RoutedEventArgs e)
        {
            ReportePagos wdreportePagos = new ReportePagos();
            wdreportePagos.Show();
            this.Close();
        }

        private void btnReporteReserva_Click(object sender, RoutedEventArgs e)
        {
            ReporteReserva wdreporteReserva = new ReporteReserva();
            wdreporteReserva.Show();
            this.Close();
        }
    }
}

using Datos;
using Negocio;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para ReporteVehiculo.xaml
    /// </summary>
    public partial class ReporteVehiculo : Window
    {
        private NTipovehiculo nTipo = new NTipovehiculo();
        private NDisponibilidad nDisponibilidad = new NDisponibilidad();
        private NVehiculo nVehiculo = new NVehiculo();
        public ReporteVehiculo()
        {
            InitializeComponent();
            MostrarTiposVehiculo(nTipo.ListarTodo());
            Mostrar(nVehiculo.ListarTodo());

        }
        private void Mostrar(List<Vehiculo> lista)
        {
            dgVehiculos.ItemsSource = new List<Cliente>();
            dgVehiculos.ItemsSource = lista;
        }
        private void MostrarTiposVehiculo(List<Tipovehiculo> tipoVehiculos)
        {
            this.cbTipoVehiculo.ItemsSource = new List<Tipovehiculo>();
            this.cbTipoVehiculo.ItemsSource = tipoVehiculos;
            this.cbTipoVehiculo.DisplayMemberPath = "TipoVehiculo";
            this.cbTipoVehiculo.SelectedValuePath = "CodigoTipoVehiculo";


        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Reportes wdReportes = new Reportes();
            wdReportes.Show();
            this.Close();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

            Mostrar(nVehiculo.ListarTodo());

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if(cbTipoVehiculo.Text=="")
            {
                MessageBox.Show("Selecciona un tipo");
                return;
            }
            Mostrar(nVehiculo.ListarPorTipo((int)cbTipoVehiculo.SelectedValue));

            //Mostrar(nDisponibilidad.ListarPorTipo((int)cbTipoVehiculo.SelectedValue));

        }

        private void btnMayorReservas_Click(object sender, RoutedEventArgs e)
        {
            Mostrar(nVehiculo.ListarMayorReservas());
        }

        private void btnMenorReservas_Click(object sender, RoutedEventArgs e)
        {
     
            Mostrar(nVehiculo.ListarMenosReservas());
            

        }
    }
}

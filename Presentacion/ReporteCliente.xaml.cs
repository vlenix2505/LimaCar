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
    /// Lógica de interacción para ReporteCliente.xaml
    /// </summary>
    public partial class ReporteCliente : Window
    {
        NCliente nCliente =new NCliente();
        NReserva nReserva = new NReserva();
        public ReporteCliente()
        {
            InitializeComponent();
            Mostrar(nCliente.ListarTodo());
        }
        private void Mostrar(List<Cliente> lista)
        {
            dgClientes.ItemsSource = new List<Cliente>();
            dgClientes.ItemsSource = lista;
            lblCantidad.Content=nReserva.CantidadReservas(lista);
            lblPromedioEdad.Content=nCliente.PromedioEdad(lista);
        }
        private void btnBuscarSexo_Click(object sender, RoutedEventArgs e)
        {
            if(cbBuscarSexo.Text=="")
            {
                MessageBox.Show("Elijan un Sexo");
                return;
            }
            Mostrar(nCliente.ListarPorGenero(cbBuscarSexo.Text));
            
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Mostrar(nCliente.ListarTodo());

        }

        private void btnClienteMasReservas_Click(object sender, RoutedEventArgs e)
        {
            Mostrar(nCliente.ListarMayorReservas());
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Reportes wdReportes = new Reportes();
            wdReportes.Show();
            this.Close();
        }

        private void btnClienteMenosReservas_Click(object sender, RoutedEventArgs e)
        {
            Mostrar(nCliente.ListarMenosReservas());

        }
    }
}

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
    /// Lógica de interacción para MenuUsuario.xaml
    /// </summary>
    public partial class MenuUsuario : Window
    {
        private int idCliente;
        private NCliente nCliente = new NCliente();

        public MenuUsuario(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            String nombreUser= nCliente.ListarTodo().Find(x => x.CodigoCliente == idCliente).Nombre_usuario;
            lblUsuario.Content = "Bienvenido " + nombreUser;
        }

        private void btnRealizarReserva_Click(object sender, RoutedEventArgs e)
        {
            SolicitudReserva wdSolicitudReserva = new SolicitudReserva(idCliente);
            wdSolicitudReserva.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sesión finalizada en LimaCar. ¡Vuelve pronto!");
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnVerDatos_Click(object sender, RoutedEventArgs e)
        {
            MisDatos wdMisDatos = new MisDatos(idCliente);
            wdMisDatos.Show();
            this.Close();

        }

        private void btnEstadoReserva_Click(object sender, RoutedEventArgs e)
        {
            Estado wdEstadoReserva = new Estado(idCliente);
            wdEstadoReserva.Show();
            this.Close();

        }
    }
}

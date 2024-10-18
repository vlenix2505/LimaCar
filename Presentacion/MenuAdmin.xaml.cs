using Negocio;
using Datos;
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
using System.Runtime.Remoting.Contexts;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        NReserva nReserva= new NReserva();
        public MenuAdmin()
        {
            InitializeComponent();
            
            Cancelar();

        }
        private void Cancelar()
        {
            foreach (Reserva r in nReserva.ListarTodo())
            {
                
                if (r.i_fechaCreacion.AddMinutes(4) < DateTime.Now&&r.CodigoEstadoReserva==2)
                {
                    r.CodigoEstadoReserva = 3;
                    nReserva.Modificar(r);
                }

            }
        }
        private void btnRegistroUsuario_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuario wdUsuariosAdmin = new RegistroUsuario();
            wdUsuariosAdmin.Show();
            this.Close();

        }

        private void btnRegistroVehiculos_Click(object sender, RoutedEventArgs e)
        {
            RegistroVehiculo wdRegistroVehiculo = new RegistroVehiculo();
            wdRegistroVehiculo.Show();
            this.Close();

        }

        private void btnSalir1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wdMainWindow = new MainWindow();
            wdMainWindow.Show();
            this.Close();
        }

        private void btnRegistroReservas_Click(object sender, RoutedEventArgs e)
        {
            RegistroReserva wdRegistroReserva = new RegistroReserva();
            wdRegistroReserva.Show();
                        this.Close();

        }

        private void btnReportes_Click(object sender, RoutedEventArgs e)
        {
            Reportes wdReportes = new Reportes();
            wdReportes.Show();
            this.Close();
        }
    }
}

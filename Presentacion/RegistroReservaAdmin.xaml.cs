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
    /// Lógica de interacción para RegistroReserva.xaml
    /// </summary>
    public partial class RegistroReserva : Window
    {
        private NReserva nReserva = new NReserva();
        private NVehiculo nVehiculo = new NVehiculo();
        public RegistroReserva()
        {
            InitializeComponent();
            Mostrar(nReserva.ListarTodo());
            MostrarVehiculos(nVehiculo.ListarTodo());           

        }
        private void Cancelar()
        {
            foreach (Reserva r in nReserva.ListarTodo())
            {

                if (r.i_fechaCreacion.AddMinutes(4) < DateTime.Now && r.CodigoEstadoReserva == 2)
                {
                    r.CodigoEstadoReserva = 3;
                    nReserva.Modificar(r);
                }

            }
        }
        private void Mostrar(List<Reserva> lista)
        {
            dgReservas.ItemsSource = new List<Reserva>();
            dgReservas.ItemsSource = lista;
            Cancelar();
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menuAdmin = new MenuAdmin();
            menuAdmin.Show();
            this.Close();
        }
        
        private void MostrarVehiculos(List<Vehiculo> lista)
        {
            this.cbPlaca.ItemsSource = new List<Vehiculo>();
            this.cbPlaca.ItemsSource = lista;
            this.cbPlaca.DisplayMemberPath = "Placa";
            this.cbPlaca.SelectedValuePath = "CodigoVehiculo";
        }

        private void btnBuscarDni_Click(object sender, RoutedEventArgs e)
        {
            if(tbBuscarDni.Text=="")
            {
                MessageBox.Show("Ingrese un DNI para realizar la búsqueda");
                return;
            }

            Mostrar(nReserva.ListarReservasPorDni(tbBuscarDni.Text));



        }

        private void btnBuscarPlaca_Click(object sender, RoutedEventArgs e)
        {
            if (cbPlaca.Text == "")
            {

                MessageBox.Show("Ingrese un DNI para realizar la búsqueda");
                return;
            }
            Mostrar(nReserva.ListarReservasPorPlaca((int)cbPlaca.SelectedValue));
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Mostrar(nReserva.ListarTodo());
        }
    }
}

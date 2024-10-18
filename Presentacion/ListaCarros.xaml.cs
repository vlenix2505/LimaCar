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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para ListaCarros.xaml
    /// </summary>
    public partial class ListaCarros : Window
    {
        private Vehiculo vehiculoSelec = null;
        private int idCliente;
        private int idTipo;
        private DateTime FechaInicio;
        private DateTime FechaFin;
        private List<Vehiculo> vehiculosTemp = null;
        private NVehiculo nVehiculo = new NVehiculo();
        private NDisponibilidad nDisponibilidad = new NDisponibilidad();
        private NReserva nReserva = new NReserva();
        private NPago nPago = new NPago();
        private NMarca nMarca = new NMarca();
        public ListaCarros(int idCliente, List<Vehiculo>vehiculosTemp, DateTime fInicio, DateTime fFin, int idTipoVehiculo)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            this.vehiculosTemp = vehiculosTemp;
            this.FechaInicio = fInicio;
            this.FechaFin = fFin;
            this.idTipo = idTipoVehiculo;
            Mostrar(vehiculosTemp);
            MostrarMarcas(nMarca.ListarTodo());
            dpFechaFin.SelectedDate = FechaFin;
            dpFechaFin.IsEnabled = false;
            dpFechaInicio.SelectedDate = FechaInicio;
            dpFechaInicio.IsEnabled = false;

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            SolicitudReserva wdSolicitudReserva = new SolicitudReserva(idCliente);
            wdSolicitudReserva.Show();
            this.Close();
        }

        private void Mostrar(List<Vehiculo> lista)
        {
            dgListasCarros.ItemsSource = new List<Vehiculo>();
            dgListasCarros.ItemsSource = lista;
        }

        private void MostrarMarcas(List<Marca>marcas)
        {
            cbMarca.ItemsSource = new List<Marca>();
            cbMarca.ItemsSource = marcas;
            cbMarca.DisplayMemberPath = "Nombre";
            cbMarca.SelectedValuePath = "CodigoMarca";
        }
        private void btnElegir_Click(object sender, RoutedEventArgs e)
        {
            if(vehiculoSelec == null)
            {
                MessageBox.Show("Seleccione un vehiculo!");
                return;
            }
            Random random = new Random();
            int galones = 0;

            if (vehiculoSelec.CodigoTipoVehiculo == 1) galones = random.Next(10, 16);
            if (vehiculoSelec.CodigoTipoVehiculo == 2) galones = random.Next(15, 21);



            Reserva reserva = new Reserva();
            reserva.FechaInicio = FechaInicio;
            reserva.FechaFin = FechaFin;
            reserva.Galones = galones;
            reserva.CodigoEstadoReserva = 2; //En proceso
            reserva.i_creadoPor = Environment.UserName;
            reserva.i_fechaCreacion = DateTime.Now;
            reserva.CodigoCliente = idCliente;
            reserva.CodigoVehiculo = vehiculoSelec.CodigoVehiculo;
            nReserva.Registrar(reserva);


            Disponibilidad disponibilidad = new Disponibilidad();
            disponibilidad.FechaInicio = FechaInicio;
            disponibilidad.FechaFin = FechaFin;
            disponibilidad.CodigoVehiculo = vehiculoSelec.CodigoVehiculo;
            nDisponibilidad.Registrar(disponibilidad);
            

            MessageBox.Show("Su reserva de N° "+ reserva.CodigoReserva.ToString()+ " fue enviada." +
                "Realice el pago en Estado de Reserva");

            MenuUsuario wdMenuUser = new MenuUsuario(idCliente);
            wdMenuUser.Show();
            this.Close();
        }

        private void dgListasCarros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vehiculoSelec = dgListasCarros.SelectedItem as Vehiculo;
            wrapPanel1.Children.Clear();
            if (vehiculoSelec != null)
            {
                var image = new Image();
                var fullFilePath = vehiculoSelec.ImagenVehiculo;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();
                image.Source = bitmap;
                wrapPanel1.Children.Add(image);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (cbMarca.Text == "")
            {
                MessageBox.Show("Debe seleccionar una marca!");
                return;
            }
            
            Mostrar(nVehiculo.ListarVehiculosXMarca((int)cbMarca.SelectedValue, this.idTipo, this.vehiculosTemp));
        }

        private void btnOrdenar_Click(object sender, RoutedEventArgs e)
        {
            if (raMayorMenor.IsChecked ==false && raMenorMayor.IsChecked == false)
            {
                MessageBox.Show("Debe seleccionar una opción");
                return;
            }

            if (raMayorMenor.IsChecked == true)
            {
                Mostrar(nVehiculo.ListarPrecioPorDescendente(this.vehiculosTemp, this.idTipo));
            }

            if (raMenorMayor.IsChecked == true)
            {
                
                Mostrar(nVehiculo.ListarPrecioPorAscendente(this.vehiculosTemp,this.idTipo));
            }

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Mostrar(vehiculosTemp);

        }
    }
}

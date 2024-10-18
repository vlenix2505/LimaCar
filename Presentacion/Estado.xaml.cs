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
    /// Interaction logic for Estado.xaml
    /// </summary>
    public partial class Estado : Window
    {
        private Reserva reservaSelec = null;
        private int idCliente;
        private DateTime Hora;
        private int idReserva;
        private NReserva nReserva = new NReserva();
        private NVehiculo nVehiculo = new NVehiculo();  
        public Estado(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            Mostrar(nReserva.ListarReservasPorCliente(idCliente));
            Cancelar();

        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuUsuario wdMenuUsuario = new MenuUsuario(idCliente);
            wdMenuUsuario.Show();
            this.Close();
        }

        private void dgEstadosReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            reservaSelec = dgEstadosReservas.SelectedItem as Reserva;

            tbCodigoReserva.Text = reservaSelec.CodigoReserva.ToString();
            this.Hora = reservaSelec.i_fechaCreacion;

            if (Hora.AddMinutes(4) < DateTime.Now && reservaSelec.CodigoEstadoReserva == 2)
            {
                reservaSelec.CodigoEstadoReserva = 3;
                nReserva.Modificar(reservaSelec);
            }
            
            tbCodigoReserva.Text = reservaSelec.CodigoReserva.ToString();
            if (reservaSelec.CodigoEstadoReserva == 1) { 
            lblEstado.Content = "Aprobada";
            }
            else if (reservaSelec.CodigoEstadoReserva == 2) { lblEstado.Content = "En Proceso"; }
            else if (reservaSelec.CodigoEstadoReserva == 3) { lblEstado.Content = "Cancelada"; }


            wrapPanel1.Children.Clear();
            var image = new Image();
            String LinkVehiculo = nVehiculo.RegresarLink(reservaSelec.CodigoVehiculo);
            var fullFilePath = LinkVehiculo;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            image.Source = bitmap;
            wrapPanel1.Children.Add(image);
        }
        private void Mostrar(List<Reserva> lista)
        {
            dgEstadosReservas.ItemsSource = new List<Reserva>();
            dgEstadosReservas.ItemsSource = lista;
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
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (Hora.AddMinutes(4) < DateTime.Now)
            {
                MessageBox.Show("Su reserva fue cancelada por demora en el pago");

                    return;
            }

            if (reservaSelec == null)
            {
                MessageBox.Show("Seleccione una reserva para realizar el pago!");
                return;
            }
            /*this.Hora = reservaSelec.i_fechaCreacion;

            if (Hora.AddMinutes(4) < DateTime.Now && reservaSelec.CodigoEstadoReserva == 2)
            {
                reservaSelec.CodigoEstadoReserva = 3;
                nReserva.Modificar(reservaSelec);
            }*/
            Cancelar();
            if (reservaSelec.CodigoEstadoReserva != 2)
            {
                MessageBox.Show("Esta reserva ya fue procesada, elija una que se encuentre " +
                    "en proceso!");
                return;
            }
            Pagos wdPagos = new Pagos(reservaSelec);
            wdPagos.Show();
            this.Close();
        }
    }
}

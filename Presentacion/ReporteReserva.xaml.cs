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
    /// Lógica de interacción para ReporteReserva.xaml
    /// </summary>
    public partial class ReporteReserva : Window
    {
        private NTipovehiculo nTipovehiculo = new NTipovehiculo();
        private NReserva nReserva = new NReserva();
        private NEstadoReserva nEstado = new NEstadoReserva();

        public ReporteReserva()
        {
            InitializeComponent();
            MostrarTiposVehiculo(nTipovehiculo.ListarTodo());
            MostrarEstado(nEstado.ListarTodo());
            lblMontoAcumulado.IsEnabled = false;
        }
        private void MostrarTiposVehiculo(List<Tipovehiculo> tipoVehiculos)
        {
            this.cbTipoVehiculo.ItemsSource = new List<Tipovehiculo>();
            this.cbTipoVehiculo.ItemsSource = tipoVehiculos;
            this.cbTipoVehiculo.DisplayMemberPath = "TipoVehiculo";
            this.cbTipoVehiculo.SelectedValuePath = "CodigoTipoVehiculo";

        }
        private void MostrarEstado(List<EstadoReserva> estados)
        {
            this.cbEstado.ItemsSource = new List<EstadoReserva>();
            this.cbEstado.ItemsSource = estados;
            this.cbEstado.DisplayMemberPath = "Descripcion";
            this.cbEstado.SelectedValuePath = "CodigoEstadoReserva";
        }


        private void btnBuscarPorEstadoTipo_Click(object sender, RoutedEventArgs e)
        {
            if (cbEstado.Text == "" && cbTipoVehiculo.Text=="")
            {
                MessageBox.Show("Debe seleccionar por lo menos una opción!");
                return;
            }

            int codigoEstado, codigoTipo;

            if (cbEstado.Text == "") {
                codigoEstado = 0;
            }
            else{
                codigoEstado = (int)cbEstado.SelectedValue;
            }

            if (cbTipoVehiculo.Text == "") { 
                codigoTipo = 0;
            }
            else{
                codigoTipo = (int)cbTipoVehiculo.SelectedValue;
            }

            Mostrar(nReserva.ListarReservasPorEstadoTipo(codigoEstado,codigoTipo));
            Limpiar();            

        }

        private void Mostrar(List<Reserva> lista)
        {
            dgReservas.ItemsSource = new List<Reserva>();
            dgReservas.ItemsSource = lista;
            lblMontoAcumulado.Content = Math.Round(nReserva.MontoPorReporte(lista),2).ToString();
            Cancelar();

        }

        private void btnReservasPorRango_Click(object sender, RoutedEventArgs e)
        {

            if (dpFechaInicio.SelectedDate > dpFechaFin.SelectedDate)
            {
                MessageBox.Show("La fecha de inicio no puede ser menor a la fecha Fin!");
                return;
            }

            if (dpFechaInicio.Text=="" || dpFechaFin.Text == "")
            {
                MessageBox.Show("No puedes dejar campos vacíos en el rango de fechas!");
                return;
            }
            DateTime fechaInicio = Convert.ToDateTime(dpFechaInicio.SelectedDate);
            DateTime fechaFin = Convert.ToDateTime(dpFechaFin.SelectedDate);
            Mostrar(nReserva.ListarReservasPorRango(fechaInicio.AddDays(-1), fechaFin.AddDays(1)));
            Limpiar();

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
        private void Limpiar()
        {
            cbEstado.Text = "";
            cbTipoVehiculo.Text = "";
            dpFechaFin.Text = "";
            dpFechaInicio.Text = "";
            
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Reportes wdReportes = new Reportes();
            wdReportes.Show();
            this.Close();
        }
    }
}

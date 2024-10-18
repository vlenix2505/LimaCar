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
    /// Lógica de interacción para ReportePagos.xaml
    /// </summary>
    public partial class ReportePagos : Window
    {
        private NPago nPago = new NPago();
        private NCliente nCliente = new NCliente();
        private NTipoPago nTipo = new NTipoPago();
        public ReportePagos()
        {
            InitializeComponent();
            MostrarTiposPago(nTipo.ListarTodo());
            MostrarClientes(nCliente.ListarTodo());
        }
        private void Mostrar(List<Pago> lista)
        {
            dgPagos.ItemsSource = new List<Pago>();
            dgPagos.ItemsSource = lista;
        }
        private void MostrarTiposPago(List<TipoPago> tipos)
        {
            this.cbTipoPago.ItemsSource = new List<TipoPago>();
            this.cbTipoPago.ItemsSource = tipos;
            this.cbTipoPago.DisplayMemberPath = "NombreTipo";
            this.cbTipoPago.SelectedValuePath = "CodigoTipoPago";
        }
        private void MostrarClientes(List<Cliente> clientes)
        {
            this.cbCliente.ItemsSource = new List<Cliente>();
            this.cbCliente.ItemsSource = clientes;
            this.cbCliente.DisplayMemberPath = "Nombre";
            this.cbCliente.SelectedValuePath = "CodigoCliente";
        }
        private void Limpiar()
        {
            cbTipoPago.Text = "";
            dpFechaMin.Text = "";
            tbMontoMin.Text = "";
            tbMontoMax.Text = "";
            cbCliente.Text = "";
        }
        private void btnBuscarPorMonto_Click(object sender, RoutedEventArgs e)
        {
            Mostrar(nPago.ListarPorMayorMonto());
            Limpiar();
        }

        private void btnBuscarPorCliente_Click(object sender, RoutedEventArgs e)
        {
            if (cbCliente.Text == "")
            {
                MessageBox.Show("Debe seleccionar a un  cliente!");
                return;
            }
            Mostrar(nPago.ListarPorCliente((int)cbCliente.SelectedValue));
            Limpiar();
        }

        private void btnBuscarPorTipoFecha_Click(object sender, RoutedEventArgs e)
        {
            if (cbTipoPago.Text == "" && dpFechaMin.Text == "")
            {
                MessageBox.Show("Debe seleccionar por lo menos una opción!");
                return;
            }

            int codigoTipo;
            int isNull = 0;
            DateTime fechaMin = DateTime.Now;

            if (cbTipoPago.Text == "")
            {
                codigoTipo = 0;
            }
            else
            {
                codigoTipo = (int)cbTipoPago.SelectedValue;
            }

            if (dpFechaMin.Text != "")
            {
                fechaMin = Convert.ToDateTime(dpFechaMin.SelectedDate);
                isNull = 1;
            }


            Mostrar(nPago.ListarPorTipoFecha(codigoTipo, fechaMin, isNull));
            Limpiar();
        }

        private void btnBuscarRangoMonto_Click(object sender, RoutedEventArgs e)
        {
            if (tbMontoMin.Text == "" || tbMontoMax.Text == "")
            {
                MessageBox.Show("Debe ingresar un rango de monto para filtrar!");
                return;
            }

            Decimal montoMin = decimal.Parse(tbMontoMin.Text);
            Decimal montoMax = decimal.Parse(tbMontoMax.Text);

            Mostrar(nPago.ListarPorRangoMonto(montoMin, montoMax));
            Limpiar();
        }

        

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Reportes wdReportes = new Reportes();
            wdReportes.Show();
            this.Close();
        }
    }
}

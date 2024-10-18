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
    /// Lógica de interacción para Pagos.xaml
    /// </summary>
    public partial class Pagos : Window
    {
        private Reserva reserva = null;
        private NVehiculo nVehiculo = new NVehiculo();
        private NTipoPago nTipoPago = new NTipoPago();
        private NReserva nReserva = new NReserva();
        private NPago nPago = new NPago();
        private int idCliente;
        private DateTime Hora;

        public Pagos(Reserva reserva)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.idCliente = reserva.CodigoCliente;
            this.Hora = reserva.i_fechaCreacion;

            MostrarTiposPago(nTipoPago.ListarTodo());
            CompletarCampos();

        }

        private void btnSalir_Copiar_Click(object sender, RoutedEventArgs e)
        {
            Estado wdEstados = new Estado(reserva.CodigoCliente);
            wdEstados.Show();
            this.Close();
        }

        private void MostrarTiposPago(List<TipoPago> tipos)
        {
            this.cbTipoPago.ItemsSource = new List<TipoPago>();
            this.cbTipoPago.ItemsSource = tipos;
            this.cbTipoPago.DisplayMemberPath = "NombreTipo";
            this.cbTipoPago.SelectedValuePath = "CodigoTipoPago";
        }
        private void CompletarCampos()
        {
            TimeSpan tSpan = reserva.FechaFin - reserva.FechaInicio;
            int dias = (tSpan.Days) + 1;
            Decimal monto = nVehiculo.ListarTodo().Find(x => x.CodigoVehiculo == reserva.CodigoVehiculo).Precio * dias;
            tbMontoTotal.Text = monto.ToString();
            tbMontoTotal.IsReadOnly = true;
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {


            if (Hora.AddMinutes(4) < DateTime.Now)
            {
                MessageBox.Show("Su reserva fue cancelada por demora en el pago");
                Estado wdEstadoReserva = new Estado(idCliente);
                wdEstadoReserva.Show();
                this.Close();
            }
                if (tbNumeroTarjeta.Text == "" || tbFechaV.Text == "" || tbCodigoSeguridad.Text == "")
                {
                    MessageBox.Show("Complete los datos de su tarjeta correctamente");
                    return;
                }

                Random random = new Random();
                Decimal saldo = new Decimal(random.NextDouble() + random.Next(400, 2100));
                saldo = Math.Round(saldo, 2);

                if (saldo >= Decimal.Parse(tbMontoTotal.Text))
                {
                    Pago pago = new Pago();
                    pago.Monto = Decimal.Parse(tbMontoTotal.Text);
                    pago.CodigoTipoPago = (int)cbTipoPago.SelectedValue;
                    pago.FechaPago = DateTime.Now;
                    nPago.Registrar(pago);


                    reserva.CodigoEstadoReserva = 1;
                    reserva.CodigoPago = pago.CodigoPago;
                    nReserva.Modificar(reserva);


                    MessageBox.Show("El pago de la reserva N° " + reserva.CodigoReserva.ToString() + " fue aprobado");
                }
                else
                {
                    MessageBox.Show("Saldo insuficiente, el pago de la reserva N° " + reserva.CodigoReserva.ToString() +
                        " no fue aprobado. Por favor, verificar datos");

                }

            MenuUsuario wdmenuUsuario = new MenuUsuario(idCliente);
            wdmenuUsuario.Show();
            this.Close();


        }
    }
}

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
    /// Lógica de interacción para SolicitudReserva.xaml
    /// </summary>
    public partial class SolicitudReserva : Window
    {
        private int idCliente;
        private NTipovehiculo nTipo = new NTipovehiculo();
        private NVehiculo nVehiculo = new NVehiculo();
        private NDisponibilidad nDisponibilidad = new NDisponibilidad();
        
        public SolicitudReserva(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            MostrarTiposVehiculo(nTipo.ListarTodo());
            dpFechaInicio.SelectedDate = DateTime.Now;
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
            MenuUsuario wdMenuUsuario = new MenuUsuario(idCliente);
            wdMenuUsuario.Show();
            this.Close();
        }

        private void btnVer_Click(object sender, RoutedEventArgs e)
        {
            if (dpFechaInicio.Text == "" || dpFechaFin.Text == "" || cbTipoVehiculo.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            if(dpFechaInicio.SelectedDate < DateTime.Now)
            {
                dpFechaInicio.DisplayDate = DateTime.Now;
                MessageBox.Show("La fecha de inicio no puede ser menor a la fecha actual!");
                return;
            }

            if (dpFechaInicio.SelectedDate > dpFechaFin.SelectedDate)
            {
                MessageBox.Show("La fecha de inicio no puede ser menor a la fecha Fin!");
                return;
            }

           DateTime fechaInicio = Convert.ToDateTime(dpFechaInicio.SelectedDate);
            DateTime fechaFin = Convert.ToDateTime(dpFechaFin.SelectedDate);
            if(fechaFin<fechaInicio)
            {
                MessageBox.Show("Elija una fecha fin posterior a la de inicio");
                return;
            }

            //Saber si vehiculo tiene su codigo en al menos una disponibilidad
            //Caso 1:
            //Si lo tiene, verificar que rango de fechas NO ESTEN DENTRO DE LAS REFERENCIADAS
            //Caso2:
            //Si vehiculo no tiene su codigo en ninguna,  se agrega a lista temporal 
            //Caso3:
            //Si vehiculo tiene su codigo en alguna, pero no esta dentro del rango,  se agrega a lista temporal 

            int idTipoVehiculo = (int)cbTipoVehiculo.SelectedValue;
            
            List<Vehiculo> vehiculosTemp = nVehiculo.ListarVehiculosSolicitud(idTipoVehiculo, fechaInicio, fechaFin);
            ListaCarros wdListaCarros = new ListaCarros(idCliente,vehiculosTemp,fechaInicio,fechaFin,idTipoVehiculo);
            wdListaCarros.Show();
            this.Close();

        }

      
    }
}

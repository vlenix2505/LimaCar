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
    /// Lógica de interacción para MisDatos.xaml
    /// </summary>
    public partial class MisDatos : Window
    {
        private NCliente nC = new NCliente();
        private int idCliente;
        public MisDatos(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            Mostrar();
        }

        private void Mostrar()
        {
            Cliente cliente = nC.ListarTodo().Find(elem=>elem.CodigoCliente==idCliente);
            tbCodigo.Text = cliente.CodigoCliente.ToString();
            tbCodigo.IsReadOnly = true;
            tbDni.Text = cliente.Dni;
            tbDni.IsReadOnly = true;
            tbNombre.Text = cliente.Nombre;
            tbApellidos.Text = cliente.Apellidos;
            cbSexo.Text = cliente.Sexo;
            tbTelefono.Text = cliente.Telefono;
            tbCorreo.Text = cliente.Correo;            
            tbPais.Text = cliente.Pais;          
            dpFechaNacimiento.SelectedDate = Convert.ToDateTime(cliente.FechaNacimiento);              
            dpFechaNacimiento.IsEnabled = false;
           
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuUsuario wdMenuUsuario = new MenuUsuario(idCliente);
            wdMenuUsuario.Show();
            this.Close();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = nC.ListarTodo().Find(elem => elem.CodigoCliente == idCliente);
            cliente.Dni = tbDni.Text;
            cliente.Nombre = tbNombre.Text;
            cliente.Sexo = cbSexo.Text;
            cliente.Pais = tbPais.Text;
            cliente.Telefono = tbTelefono.Text;
            cliente.Apellidos = tbApellidos.Text;
            cliente.FechaNacimiento = Convert.ToDateTime(dpFechaNacimiento.SelectedDate);
            cliente.Correo = tbCorreo.Text;
            cliente.i_fechaModificado = DateTime.Now;
            cliente.i_modificadoPor = Environment.UserName;
            String mensaje = nC.Modificar(cliente);
            MessageBox.Show(mensaje);
            Mostrar();
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sesión finalizada en LimaCar. ¡Vuelve pronto!");
            MainWindow main = new MainWindow(); 
            main.Show();
            this.Close();

        }
    }
}

using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
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
    /// Lógica de interacción para Registro_Usuario.xaml
    /// </summary>
    public partial class Registro_Usuario : Window
    {
        
        private NCliente nC = new NCliente();
        public Registro_Usuario()
        {
            InitializeComponent();
            dpFechaNacimiento.SelectedDate= DateTime.Now.AddYears(-18);
        }

        private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            if (tbDni.Text == "" || tbNombre.Text == "" || tbApellidos.Text == "" ||
                tbPais.Text == "" || cbSexo.Text == "" || tbCorreo.Text == "" || tbTelefono.Text==""||
                tbUsuario.Text =="" || tbClave.Password.ToString() =="" || dpFechaNacimiento.Text =="")
            {
                MessageBox.Show("Debe completar los campos vacíos!");
                return;               
            }
            if (tbDni.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe ser de 8 dígitos");
                return;
            }
            if (dpFechaNacimiento.SelectedDate>DateTime.Now.AddYears(-18))
            {
                MessageBox.Show("Tiene que tener más de 18 para estar registrado");
                return;
            }
            bool existe = nC.ListarTodo().Exists(x => x.Nombre_usuario.Equals(tbUsuario.Text));
            if (existe)
            {
                MessageBox.Show("Usuario ya en uso. Por favor, ingrese uno diferente");
                return;
            }

            Cliente cliente = new Cliente();
            cliente.Dni = tbDni.Text;
            cliente.Nombre = tbNombre.Text;
            cliente.Sexo = cbSexo.Text;
            cliente.Pais = tbPais.Text;
            cliente.Telefono = tbTelefono.Text;
            cliente.Apellidos = tbApellidos.Text;
            cliente.FechaNacimiento = Convert.ToDateTime(dpFechaNacimiento.SelectedDate);
            cliente.Correo = tbCorreo.Text;           
            cliente.Nombre_usuario = tbUsuario.Text;
            cliente.Clave = tbClave.Password.ToString();
            cliente.i_fechaCreacion = DateTime.Now;
            cliente.i_fechaModificado = DateTime.Now;
            cliente.i_modificadoPor = Environment.UserName;
            cliente.i_creadoPor = Environment.UserName;
            String mensaje = nC.Registrar(cliente);
            MessageBox.Show(mensaje);
            InicioSesion wdInicioSesion = new InicioSesion();
            wdInicioSesion.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

            
            MainWindow wdMain = new MainWindow();
            wdMain.Show();
            this.Close();
        }
    }
}

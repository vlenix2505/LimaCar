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
    /// Lógica de interacción para InicioSesion.xaml
    /// </summary>
    public partial class InicioSesion : Window
    {
        private NCliente nC = new NCliente();        
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsuario.Text == "" || tbClave.Password.ToString() == "")
            {
                MessageBox.Show("Debe completar los campos vacíos!");
                return;
            }

            List<Cliente> clientesTemp = nC.ListarTodo();          
            

            switch(nC.ExistePorUsuarioClave(tbUsuario.Text,tbClave.Password.ToString()))
            {
                case 0:
                    MessageBox.Show("Usuario no registrado. ¡Registrate para disfrutar LimaCar!");
                    return; 
                case 1:
                    Cliente cliente = clientesTemp.Find(elem => elem.Nombre_usuario.Equals(tbUsuario.Text) && elem.Clave.Equals(tbClave.Password.ToString()));
                    if (tbUsuario.Text == "admin" && tbClave.Password.ToString() == "admin")
                    {
                        MenuAdmin wdMenuAdmin = new MenuAdmin();
                        wdMenuAdmin.Show();
                    }
                    else
                    {
                        MenuUsuario wdMenuUsuario = new MenuUsuario(cliente.CodigoCliente);
                        wdMenuUsuario.Show(); 
                    }
                    break;
                case 2:
                    MessageBox.Show("Clave incorrecta. Por favor, verifica tus datos para acceder!");
                    return; 
            }           
            this.Close();
      
        


        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wdMainWindow = new MainWindow();
            wdMainWindow.Show();
            this.Close();
        }
    }
}

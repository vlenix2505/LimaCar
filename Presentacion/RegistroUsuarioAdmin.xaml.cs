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
    /// Lógica de interacción para RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        private NCliente nC = new NCliente();
        public RegistroUsuario()
        {
            InitializeComponent();
            Mostrar(nC.ListarTodo());
            
        }
        private void Mostrar(List<Cliente> lista)
        {
            dgUsuario.ItemsSource = new List<Cliente>();
            dgUsuario.ItemsSource = lista;
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin wdMenuAdmin = new MenuAdmin();
            wdMenuAdmin.Show();
            this.Close();
        }

        private void btnBuscarDni_Click(object sender, RoutedEventArgs e)
        {
            if (tbBuscarDni.Text == "")
            {
                MessageBox.Show("Ingrese un DNI a buscar");
            }
            Mostrar(nC.ListarPorDni(tbBuscarDni.Text));
        }

        private void btnBuscarNombre_Click(object sender, RoutedEventArgs e)
        {
            if (tbBuscarNombre.Text == "")
            {
                MessageBox.Show("Ingrese un Nombre a buscar");
            }
            Mostrar(nC.ListarPorNombre(tbBuscarNombre.Text));
        }

        private void btnBuscarPais_Click(object sender, RoutedEventArgs e)
        {
            if (tbBuscarPais.Text == "")
            {
                MessageBox.Show("Ingrese un Pais a buscar");
            }
            Mostrar(nC.ListarPorPais(tbBuscarPais.Text));
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Mostrar(nC.ListarTodo());

        }
    }
}

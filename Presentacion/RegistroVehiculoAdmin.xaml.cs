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
    /// Lógica de interacción para RegistroVehiculo.xaml
    /// </summary>
    public partial class RegistroVehiculo : Window
    {
        private NMarca nMarca= new NMarca();
        private NModelo nModelo = new NModelo();
        private NTipovehiculo nTipo = new NTipovehiculo();
        private NVehiculo nVehiculo = new NVehiculo();
        private Vehiculo vehiculoSelec = null;

        
        
        public RegistroVehiculo()
        {
            InitializeComponent();
            MostrarTiposVehiculo(nTipo.ListarTodo());
            MostrarMarcas(nMarca.ListarTodo());
            Mostrar(nVehiculo.ListarTodo());            
            //MostrarPrueba(nVehiculo.ListarVehiculosCliente());
        }
        private void MostrarPrueba(List<usp_ListarVehiculosCliente_Result> lista)
        {
            dgVehiculos.ItemsSource = new List<usp_ListarVehiculosCliente_Result>();
            dgVehiculos.ItemsSource = lista;
        }
        private void MostrarMarcas(List<Marca> marcas)
        {
            this.cbMarca.ItemsSource = new List<Marca>();
            this.cbMarca.ItemsSource = marcas;
            this.cbMarca.DisplayMemberPath = "Nombre";
            this.cbMarca.SelectedValuePath = "CodigoMarca";                   
           
        }

        private void MostrarTiposVehiculo(List<Tipovehiculo> tipoVehiculos)
        {
            this.cbTipoVehiculo.ItemsSource = new List<Tipovehiculo>();
            this.cbTipoVehiculo.ItemsSource = tipoVehiculos;
            this.cbTipoVehiculo.DisplayMemberPath = "TipoVehiculo";
            this.cbTipoVehiculo.SelectedValuePath = "CodigoTipoVehiculo";
            

        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (tbPlaca.Text.Length != 6)
            {
                MessageBox.Show("La placa debe ser de 6 dígitos");
                return;
            }
            if (tbColor.Text==""||tbAnio.Text==""||cbCombustible.Text==""||tbPrecio.Text==""
                ||tbCapacidad.Text==""||cbTipoVehiculo.Text==""||cbMarca.Text==""||
                    cbModelo.Text==""||tbPlaca.Text==""||tbLink.Text=="")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (nVehiculo.ExistePlaca(tbPlaca.Text))
            {
                MessageBox.Show("La placa ingresada ya existe");
                return;
            }
            
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Placa = tbPlaca.Text;
            vehiculo.Capacidad = int.Parse(tbCapacidad.Text);
            vehiculo.TipoCombustible = cbCombustible.Text;
            vehiculo.Color = tbColor.Text;
            vehiculo.Precio = decimal.Parse(tbPrecio.Text);
            vehiculo.Anio = int.Parse(tbAnio.Text);
            vehiculo.CodigoModelo = (int)cbModelo.SelectedValue;
            vehiculo.CodigoTipoVehiculo = (int)cbTipoVehiculo.SelectedValue;
            vehiculo.ImagenVehiculo = tbLink.Text;
            vehiculo.i_fechaCreacion = DateTime.Now;
            vehiculo.i_fechaModificado = DateTime.Now;
            vehiculo.i_modificadoPor = Environment.UserName;
            vehiculo.i_creadoPor = Environment.UserName;

            String mensaje = nVehiculo.Registrar(vehiculo);
            MessageBox.Show(mensaje);
            Mostrar(nVehiculo.ListarTodo());

        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin wdMenuAdmin = new MenuAdmin();
            wdMenuAdmin.Show();
            this.Close();            
        }

        private void cbModelo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Modelo> modelos = nModelo.ListarTodo();
            List<Modelo> modelosTemp = new List<Modelo>();
            if(cbMarca.Text!= "")
            {
                foreach (Modelo modelo in modelos)
                {
                    if (modelo.CodigoMarca == (int)cbMarca.SelectedValue)
                    {
                        modelosTemp.Add(modelo);
                    }
                }

                this.cbModelo.ItemsSource = modelosTemp;
                this.cbModelo.DisplayMemberPath = "Nombre";
                this.cbModelo.SelectedValuePath = "CodigoModelo";
            }
            
            
        }

        private void dgVehiculos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vehiculoSelec = dgVehiculos.SelectedItem as Vehiculo;
            if (vehiculoSelec != null)
            {

                tbPlaca.Text=vehiculoSelec.Placa;
                tbPlaca.IsReadOnly=true;
                tbCapacidad.Text=vehiculoSelec.Capacidad.ToString();
                cbCombustible.Text=vehiculoSelec.TipoCombustible;
                tbColor.Text=vehiculoSelec.Color;
                tbPrecio.Text=vehiculoSelec.Precio.ToString();
                tbAnio.Text=vehiculoSelec.Anio.ToString();                
                int Codigo_marca = nModelo.RegresarMarcaId(vehiculoSelec.CodigoModelo);
                cbMarca.SelectedValue = Codigo_marca;
                cbModelo.SelectedValue = vehiculoSelec.CodigoModelo;
                cbTipoVehiculo.SelectedValue=vehiculoSelec.CodigoTipoVehiculo;
                tbLink.Text=vehiculoSelec.ImagenVehiculo;
                wrapPanel1.Children.Clear();
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

        private void Mostrar(List<Vehiculo> lista)
        {
            dgVehiculos.ItemsSource = new List<Vehiculo>();
            dgVehiculos.ItemsSource = lista;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (tbColor.Text == "" || tbAnio.Text == "" || cbCombustible.Text == "" || tbPrecio.Text == ""
        || tbCapacidad.Text == "" || cbTipoVehiculo.Text == "" || cbMarca.Text == "" ||
            cbModelo.Text == "" || tbPlaca.Text == "" || tbLink.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            if (vehiculoSelec == null)
            {
                MessageBox.Show("Seleccione un vehículo para modificar");
                return;
            }
            if (vehiculoSelec != null)
            {
                Vehiculo vehiculo = new Vehiculo();
                {
                    vehiculo.CodigoVehiculo = vehiculoSelec.CodigoVehiculo;
                    vehiculo.Placa = tbPlaca.Text;
                    vehiculo.Capacidad = int.Parse(tbCapacidad.Text);
                    vehiculo.TipoCombustible = cbCombustible.Text;
                    vehiculo.Color = tbColor.Text;
                    vehiculo.Precio = decimal.Parse(tbPrecio.Text);
                    vehiculo.Anio = int.Parse(tbAnio.Text);
                    vehiculo.CodigoModelo = (int)cbModelo.SelectedValue;
                    vehiculo.CodigoTipoVehiculo = (int)cbTipoVehiculo.SelectedValue;
                    vehiculo.ImagenVehiculo = tbLink.Text;
                    vehiculo.i_fechaCreacion = DateTime.Now;
                    vehiculo.i_fechaModificado = DateTime.Now;
                    vehiculo.i_modificadoPor = Environment.UserName;
                    vehiculo.i_creadoPor = Environment.UserName;
                }


                String mensaje = nVehiculo.Modificar(vehiculo);
                MessageBox.Show(mensaje);
                Mostrar(nVehiculo.ListarTodo());
            }

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (vehiculoSelec == null)
            {
                MessageBox.Show("Seleccione un vehiculo ");
                return;
            }
            String mensaje = nVehiculo.Eliminar(vehiculoSelec.CodigoVehiculo);
            MessageBox.Show(mensaje);
            Mostrar(nVehiculo.ListarTodo());

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if(tbBuscarPlaca.Text=="")
            {
                MessageBox.Show("Ingrese una placa a buscar");
                return;
            }
            Mostrar(nVehiculo.ListarPorPlaca(tbBuscarPlaca.Text));
            

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Mostrar(nVehiculo.ListarTodo());
            tbAnio.Text = "";
            tbPlaca.IsReadOnly = false;
            tbPlaca.Text = "";
            tbLink.Text="";
            tbPrecio.Text = "";
            
            cbTipoVehiculo.Text = "";
            tbColor.Text = "";
            tbAnio.Text = "";
            tbCapacidad.Text = "";
            cbCombustible.Text = "";
            cbModelo.Text = "";
            cbMarca.Text = "";
            wrapPanel1.Children.Clear();
        }
    }
}

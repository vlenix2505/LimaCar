using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCliente
    {
        public String Registrar(Cliente cliente)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Cliente.Add(cliente);
                    context.SaveChanges();
                }
                return "Cliente registrado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public int ExistePorUsuarioClave(String usuario, String clave)
        {
            int result = 0;
            List<Cliente> clientesTemp = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    if (context.Cliente.Where(x => x.Nombre_usuario.Equals(usuario) && x.Clave.Equals(clave)).Count() > 0) result = 1;
                    if (context.Cliente.Where(x => x.Nombre_usuario.Equals(usuario) && !x.Clave.Equals(clave)).Count() > 0) result = 2;
                }
                return result;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public String Modificar(Cliente cliente)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(cliente.CodigoCliente);
                    clienteTemp.Dni = cliente.Dni;
                    clienteTemp.Nombre = cliente.Nombre;
                    clienteTemp.Apellidos = cliente.Apellidos;
                    clienteTemp.Telefono = cliente.Telefono;
                    clienteTemp.Correo = cliente.Correo;
                    clienteTemp.FechaNacimiento = cliente.FechaNacimiento;
                    clienteTemp.Pais = cliente.Pais;
                    clienteTemp.Sexo = cliente.Sexo;
                    clienteTemp.Nombre_usuario = cliente.Nombre_usuario;
                    clienteTemp.Clave = cliente.Clave;
                    clienteTemp.i_fechaCreacion = cliente.i_fechaCreacion; ;
                    clienteTemp.i_fechaModificado = cliente.i_fechaModificado;
                    clienteTemp.i_creadoPor = cliente.i_creadoPor;
                    clienteTemp.i_modificadoPor = cliente.i_modificadoPor;
                    context.SaveChanges();

                }
                return "Cliente modificado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public String Eliminar(int id)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente peliculaTemp = context.Cliente.Find(id);
                    context.Cliente.Remove(peliculaTemp);
                    context.SaveChanges();
                }
                return "Cliente eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public List<Cliente> ListarTodo()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    clientes = context.Cliente.Where(x=>x.Nombre_usuario!="admin").ToList();
                }
                return clientes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Cliente> ListarPorGenero(String sexo)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    clientes = context.Cliente.Where(x => x.Sexo.Equals(sexo)).ToList();
                }
                return clientes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Cliente> ListarPorDni(String dni)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    clientes = context.Cliente.Where(x => x.Dni.Contains(dni)).ToList();
                }
                return clientes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Cliente> ListarPorNombre(String nombre)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    clientes = context.Cliente.Where(x => x.Nombre.Contains(nombre) && x.Nombre_usuario != "admin").ToList();
                }
                return clientes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Cliente> ListarPorPais(String pais)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    clientes = context.Cliente.Where(x => x.Pais.Contains(pais)).ToList();
                }
                return clientes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Cliente> ListarMayorReservas()
        {
            int maximo=0;

            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    //clientes = context.Cliente.Where(x => x.Nombre_usuario != "admin").ToList();

                    maximo = context.Cliente.Max(x => x.Reserva.Count);
                    clientes=context.Cliente.Where(x=>x.Reserva.Count.Equals(maximo)&& x.Nombre_usuario != "admin").ToList();



                }
                
                return clientes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Cliente> ListarMenosReservas()
        {
           int minimo=0;

            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    minimo = context.Cliente.Min(x => x.Reserva.Count);
                    clientes=context.Cliente.Where(x=>x.Reserva.Count.Equals(minimo) && x.Nombre_usuario != "admin").ToList();
                }
                
                return clientes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public double PromedioEdad (List<Cliente> clientesTemp)
        {
            double promedio = 0;
            double total = 0;
            try
            {
                using (var context = new BDEFEntities())
                {
                    foreach(Cliente cliente in clientesTemp)

                    {
                        int edad=DateTime.Now.Year- cliente.FechaNacimiento.Year;
                        total += edad;   
                        //clientes = context.Cliente.Where(x => x.Pais.Contains(pais)).ToList();

                    }
                    promedio=total/clientesTemp.Count;
                }
                return Math.Round(promedio,2);
            }
            catch (Exception ex)
            {
                return promedio;
            }

        }

    }
}

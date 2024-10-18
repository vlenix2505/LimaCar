using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCliente
    {
        private DCliente dC = new DCliente();
        public NCliente() { }

        public String Registrar(Cliente cliente)
        {
            return dC.Registrar(cliente);
        }

        public String Modificar(Cliente cliente) { 
        
            return dC.Modificar(cliente);
        }

        public String Eliminar(int id)
        {
            return dC.Eliminar(id);
        }

        public List<Cliente> ListarTodo()
        {
            return dC.ListarTodo();
        }
        public List<Cliente> ListarPorDni(String dni)
        {
            return dC.ListarPorDni(dni);

        }

        public List<Cliente> ListarPorNombre(string nombre)
        {
            return dC.ListarPorNombre(nombre);
        }

        public List<Cliente> ListarPorPais(string pais)
        {
            return dC.ListarPorPais(pais);

        }
        public List<Cliente> ListarMayorReservas()
        {
            return dC.ListarMayorReservas();
        }
        public List<Cliente> ListarMenosReservas()
        {
            return dC.ListarMenosReservas();
        }

        public int ExistePorUsuarioClave(String usuario, String clave)
        {
            return dC.ExistePorUsuarioClave(usuario, clave);
        }
        public List<Cliente> ListarPorGenero(String sexo)
        {
            return dC.ListarPorGenero(sexo);
        }
        public double PromedioEdad(List<Cliente> clientesTemp)
        {
            return dC.PromedioEdad(clientesTemp);
        }

    }
}

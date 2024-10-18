using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NDisponibilidad
    {
        private DDisponibilidad dDisponibilidad = new DDisponibilidad();

        public NDisponibilidad() { }

        public List<Disponibilidad> ListarTodo()
        {
            return dDisponibilidad.ListarTodo();
        }

        public String Registrar(Disponibilidad disponibilidad)
        {
            return dDisponibilidad.Registrar(disponibilidad);
        }
        public String Eliminar(int id)
        {
            return dDisponibilidad.Eliminar(id);
        }
        public List<Disponibilidad> ListarPorTipo(int codigoTipo)
        {
            return dDisponibilidad.ListarPorTipo(codigoTipo);
        }

    }
}

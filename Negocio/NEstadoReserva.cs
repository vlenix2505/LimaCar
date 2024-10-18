using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEstadoReserva
    {

        private DEstadoReserva dE = new DEstadoReserva();
        public NEstadoReserva() { }

        public List<EstadoReserva> ListarTodo()
        {
            return dE.ListarTodo();
        }
    }
    
}

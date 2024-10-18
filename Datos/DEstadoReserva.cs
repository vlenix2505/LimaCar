using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DEstadoReserva
    {
        public List<EstadoReserva> ListarTodo()
        {
            List<EstadoReserva> estados = new List<EstadoReserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    estados = context.EstadoReserva.ToList();
                }
                return estados;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

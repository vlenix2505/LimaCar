using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NTipovehiculo
    {
        private DTipovehiculo dT = new DTipovehiculo();

        public NTipovehiculo() { }

        public List<Tipovehiculo> ListarTodo()
        {
            return dT.ListarTodo();
        }

    }
}

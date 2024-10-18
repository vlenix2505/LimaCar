using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NModelo
    {
        private DModelo dModelo = new DModelo();

        public NModelo() { }

        public List<Modelo> ListarTodo()
        {
            return dModelo.ListarTodo();
        }
        public int RegresarMarcaId(int idModelo)
        {
            return dModelo.RegresarMarcaId(idModelo);

        }
    }
}

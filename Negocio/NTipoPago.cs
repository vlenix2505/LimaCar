using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    
    public class NTipoPago
    {
        private DTipoPago dTipo = new DTipoPago();
        public NTipoPago() { }
        public String Registrar(TipoPago tipo)
        {
            return dTipo.Registrar(tipo);
        }
        public List<TipoPago> ListarTodo()
        {
            return dTipo.ListarTodo();
        }
    }
}

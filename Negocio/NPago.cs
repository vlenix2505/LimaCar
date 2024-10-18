using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NPago
    {   
        private DPago dPago = new DPago();
        public NPago() { }
        public List<Pago> ListarTodo()
        {
            return dPago.ListarTodo();
        }

        public String Registrar(Pago pago)
        {
            return dPago.Registrar(pago);
        }
        public String Eliminar(int id)
        {
            return dPago.Eliminar(id);
        }
         public List<Pago> ListarPorTipoFecha(int codigoTipo, DateTime fechaMinima, int isNull)
        {
            return dPago.ListarPorTipoFecha(codigoTipo, fechaMinima,isNull);
        }

        public List<Pago> ListarPorRangoMonto(Decimal montoMin, Decimal montoMax)
        {
            return dPago.ListarPorRangoMonto(montoMin, montoMax);
        }
        
        public List<Pago> ListarPorCliente(int codigoCliente)
        {
            return dPago.ListarPorCliente(codigoCliente);
        }
        public List<Pago> ListarPorMayorMonto()
        {
            return dPago.ListarPorMayorMonto();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DTipoPago
    {
        public DTipoPago() { }
        public String Registrar(TipoPago tipo)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.TipoPago.Add(tipo);
                    context.SaveChanges();
                }
                return "Tipo de Pago registrado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }                

        public List<TipoPago> ListarTodo()
        {
            List<TipoPago> tipos = new List<TipoPago>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    tipos = context.TipoPago.ToList();
                }
                return tipos;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
      


    }
}


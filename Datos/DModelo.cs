using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DModelo
    {
        public List<Modelo> ListarTodo()
        {
            List<Modelo> modelos = new List<Modelo>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    modelos = context.Modelo.ToList();
                }
                return modelos;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public int RegresarMarcaId(int idModelo)
        {
            using (var context = new BDEFEntities())
            {
                var modelo = context.Modelo.Find(idModelo);

                return modelo.CodigoMarca;
            }
        }
    }
}

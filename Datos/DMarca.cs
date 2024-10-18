using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DMarca
    {
        public List<Marca> ListarTodo()
        {
            List<Marca> marcas = new List<Marca>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    marcas = context.Marca.ToList();
                }
                return marcas;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

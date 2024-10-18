using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DTipovehiculo
    {
        public List<Tipovehiculo> ListarTodo()
        {
            List<Tipovehiculo> tipoVehiculos = new List<Tipovehiculo>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    tipoVehiculos = context.Tipovehiculo.ToList();
                }
                return tipoVehiculos;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NMarca
    {
        private DMarca dMarca = new DMarca();
        public NMarca() { }
        public List<Marca> ListarTodo()
        {
            return dMarca.ListarTodo();
        }


    }
}   

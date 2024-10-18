using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DDisponibilidad
    {
        public String Registrar(Disponibilidad disponibilidad)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Disponibilidad.Add(disponibilidad);
                    context.SaveChanges();
                }
                return "Disponibilidad registrada correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public String Eliminar(int codigo)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Disponibilidad disponibilidadTemp = context.Disponibilidad.Find(codigo);
                    context.Disponibilidad.Remove(disponibilidadTemp);
                    context.SaveChanges();
                }
                return "Disponibilidad eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public List<Disponibilidad> ListarTodo()
        {
            List<Disponibilidad> disponibilidades = new List<Disponibilidad>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    disponibilidades = context.Disponibilidad.ToList();
                }
                return disponibilidades;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Disponibilidad> ListarPorTipo(int codigoTipo)
        {
            List<Disponibilidad> disponibilidadesTemp = new List<Disponibilidad>();
            List<Disponibilidad> disponibilidades = new List<Disponibilidad>();

            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Tipovehiculo> tipoTemp = new List<Tipovehiculo>();

            try
            {
                using (var context = new BDEFEntities())
                {
                    //disponibilidades = context.Disponibilidad.Where(d=>d.).ToList();
                    tipoTemp = context.Tipovehiculo.Where(x => x.CodigoTipoVehiculo == codigoTipo).ToList();
                    vehiculos=context.Vehiculo.ToList();
                    disponibilidadesTemp = context.Disponibilidad.ToList();
                    foreach (Tipovehiculo tipo in tipoTemp)
                    {
                        foreach (Vehiculo vehiculo in vehiculos)
                        {
                            if(tipo.CodigoTipoVehiculo==vehiculo.CodigoTipoVehiculo)
                            {
                                foreach (Disponibilidad dispo in disponibilidadesTemp)
                                {
                                    if (dispo.CodigoVehiculo == vehiculo.CodigoVehiculo)
                                    {
                                        disponibilidades.Add(dispo);

                                    }//codigovehiculo d vehiculos con codvehi de disponi y codtipo de vehi con cod tipo de tipo
                                }
                            }
                            
                            
                        }

                    }
                }
                return disponibilidades;
                

            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

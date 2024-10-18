using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DVehiculo
    {
        public String Registrar(Vehiculo vehiculo)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Vehiculo.Add(vehiculo);
                    context.SaveChanges();
                }
                return "Vehiculo registrado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public String Modificar(Vehiculo vehiculo)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Vehiculo vehiculoTemp = context.Vehiculo.Find(vehiculo.CodigoVehiculo);
                    vehiculoTemp.Color = vehiculo.Color;
                    vehiculoTemp.Anio = vehiculo.Anio;
                    vehiculoTemp.TipoCombustible = vehiculo.TipoCombustible;
                    vehiculoTemp.Precio = vehiculo.Precio;
                    vehiculoTemp.Capacidad = vehiculo.Capacidad;
                    vehiculoTemp.Placa = vehiculo.Placa;
                    vehiculoTemp.CodigoTipoVehiculo = vehiculo.CodigoTipoVehiculo;
                    vehiculoTemp.CodigoModelo = vehiculo.CodigoModelo;
                    vehiculoTemp.ImagenVehiculo = vehiculo.ImagenVehiculo;
                    vehiculoTemp.i_fechaCreacion = vehiculo.i_fechaCreacion; ;
                    vehiculoTemp.i_fechaModificado = vehiculo.i_fechaModificado;
                    vehiculoTemp.i_creadoPor = vehiculo.i_creadoPor;
                    vehiculoTemp.i_modificadoPor = vehiculo.i_modificadoPor;
                    context.SaveChanges();

                }
                return "Vehiculo modificado correctamente";
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
                    Vehiculo vehiculoTemp = context.Vehiculo.Find(codigo);
                    context.Vehiculo.Remove(vehiculoTemp);
                    context.SaveChanges();
                }
                return "Vehiculo eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public List<Vehiculo> ListarTodo()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    vehiculos = context.Vehiculo.ToList();
                }
                return vehiculos;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Vehiculo> ListarPorPlaca(String placa)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    vehiculos = context.Vehiculo.Where(v=>v.Placa.Contains(placa)).ToList();
                }
                return vehiculos;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Vehiculo> ListarPorTipo(int codigoTipo)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    vehiculos = context.Vehiculo.Where(v => v.CodigoTipoVehiculo==codigoTipo).ToList();
                }
                return vehiculos;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Vehiculo> ListarVehiculosSolicitud(int idTipoVehiculo, DateTime fechaInicio, DateTime fechaFin)
        {

            List<Vehiculo> vehiculosSinDisp = new List<Vehiculo>();
            List<Vehiculo> vehiculosDispFuera = new List<Vehiculo>();
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Reserva> reservas = new List<Reserva>();
            List<Vehiculo> vehiculosFinal = new List<Vehiculo>();
            List<Vehiculo> vehiculosLast= new List<Vehiculo>();
            List<Vehiculo> vehiculosReal= new List<Vehiculo>();

            try
            {//|| r.CodigoEstadoReserva != 2 ||(elem.CodigoTipoVehiculo == idTipoVehiculo && elem.Reserva.Any(r => r.CodigoEstadoReserva == 3 ))
                using (var context = new BDEFEntities())
                {
                    /*
                    vehiculosSinDisp = context.Vehiculo.Where(elem => elem.CodigoTipoVehiculo == idTipoVehiculo && elem.Disponibilidad.Count == 0
                     ).ToList();
                    vehiculosDispFuera = context.Vehiculo.Where(elem => elem.CodigoTipoVehiculo == idTipoVehiculo
                     && elem.Disponibilidad.Any(d => d.FechaFin < fechaInicio ||
                    d.FechaInicio > fechaFin || (d.FechaInicio == fechaInicio && d.FechaFin == fechaFin))).ToList();
                    reservas = context.Reserva.ToList();
                    foreach (Vehiculo ve in vehiculosDispFuera)
                    {
                        foreach(Reserva res in reservas)
                        {
                            if (res.CodigoEstadoReserva!=2)
                            {
                                if (!vehiculosFinal.Exists(x=>x.CodigoVehiculo==ve.CodigoVehiculo))
                                { 
                                    vehiculosFinal.Add(ve);
                                }
                            }
                            
                        }    
                        
                    }
                    vehiculos = vehiculosSinDisp.Concat(vehiculosFinal).ToList();*/
                    vehiculosSinDisp = context.Vehiculo.Where(elem => elem.CodigoTipoVehiculo == idTipoVehiculo && elem.Disponibilidad.Count == 0
                     ).ToList();//sin disponibilidad

                   vehiculosDispFuera = context.Vehiculo.Where(elem => elem.CodigoTipoVehiculo == idTipoVehiculo
                     && elem.Disponibilidad.All(d => d.FechaFin < fechaInicio ||
                    d.FechaInicio > fechaFin )).ToList();
                    /*
                    foreach (Vehiculo v in context.Vehiculo.ToList())
                    {
                        int cantidadDisp = v.Disponibilidad.Count;
                        int cont = 0;
                        foreach (Disponibilidad d in context.Disponibilidad.Where(x => x.CodigoVehiculo == v.CodigoVehiculo).ToList())
                        {
                            if (v.CodigoTipoVehiculo == idTipoVehiculo)
                            {
                                if (d.FechaFin < fechaInicio || d.FechaInicio > fechaFin)
                                {
                                    cont++;
                                }
                            }
                        }
                        if (cont == cantidadDisp)
                        {
                            vehiculosDispFuera.Add(v);
                        }
                    }*/
                    vehiculos = vehiculosSinDisp.Concat(vehiculosDispFuera).ToList();
                    vehiculosLast = context.Vehiculo.Where(elem => elem.Reserva.Any(r => r.CodigoEstadoReserva == 3) && elem.CodigoTipoVehiculo ==
                    idTipoVehiculo && elem.Disponibilidad.Any(d => d.FechaFin > fechaInicio ||
                    d.FechaInicio < fechaFin)).ToList();
                    vehiculos = vehiculosSinDisp.Concat(vehiculosDispFuera).ToList();
                    vehiculosFinal = vehiculos.Concat(vehiculosLast).ToList();
                    foreach (Vehiculo v in vehiculosFinal)
                    {
                        if (!vehiculosReal.Exists(elem => elem.CodigoVehiculo == v.CodigoVehiculo))
                        {
                            vehiculosReal.Add(v);
                        }
                    }

                }
                return vehiculosReal; 
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Vehiculo> ListarPrecioPorAscendente(List<Vehiculo>vehiculosTemp, int codigoTipo)
        {
            
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Tipovehiculo> tipoTemp = new List<Tipovehiculo>();

            try
            {

                using (var context = new BDEFEntities())
                {

                    tipoTemp = context.Tipovehiculo.Where(x => x.CodigoTipoVehiculo == codigoTipo).ToList();
                    foreach (Tipovehiculo tipo in tipoTemp)
                    {
                        foreach (Vehiculo vehiculo in vehiculosTemp)

                        {
                            if (vehiculo.CodigoTipoVehiculo == codigoTipo)
                            {
                                vehiculos.Add(vehiculo);

                            }
                        }

                    }
                    


                }
                return vehiculos.OrderBy(x => x.Precio).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public List<Vehiculo> ListarPrecioPorDescendente(List<Vehiculo> vehiculosTemp, int codigoTipo)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Tipovehiculo> tipoTemp = new List<Tipovehiculo>();

            try
            {

                using (var context = new BDEFEntities())
                {

                    tipoTemp = context.Tipovehiculo.Where(x => x.CodigoTipoVehiculo == codigoTipo).ToList();
                    foreach (Tipovehiculo tipo in tipoTemp)
                    {
                        foreach (Vehiculo vehiculo in vehiculosTemp)
                        {
                            if (vehiculo.CodigoTipoVehiculo == codigoTipo)
                            {
                                vehiculos.Add(vehiculo);

                            }
                        }

                    }



                }
                return vehiculos.OrderByDescending(x => x.Precio).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Vehiculo> ListarVehiculosXMarca(int codigoMarca, int codigoTipo, List<Vehiculo> vehiculosTemp)
        {
        List<Vehiculo> vehiculos1 = new List<Vehiculo>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Modelo> modelosTemp = new List<Modelo>();

        List<Tipovehiculo> tipoTemp = new List<Tipovehiculo>();
        


        try
        {

            using (var context = new BDEFEntities())
            {
                   
                modelosTemp= context.Modelo.Where(x=>x.CodigoMarca==codigoMarca).ToList();
                tipoTemp=context.Tipovehiculo.Where(x => x.CodigoTipoVehiculo == codigoTipo).ToList();
                foreach(Tipovehiculo tipo in tipoTemp)
                {
                    foreach(Vehiculo vehiculo in vehiculosTemp)
                            
                    {
                        if (vehiculo.CodigoTipoVehiculo == codigoTipo)
                        {
                            vehiculos.Add(vehiculo);

                        }
                    }
                        
                }
                if(vehiculos.Count > 0)
                {
                    foreach (Modelo modelo in modelosTemp)
                    {
                        foreach (Vehiculo vehiculo in vehiculos)

                        {
                            if (modelo.CodigoModelo == vehiculo.CodigoModelo)
                            {
                                vehiculos1.Add(vehiculo);

                            }
                        }
                    }
                }
                    
                
            }
                    return vehiculos1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<usp_ListarVehiculosCliente_Result> ListarVehiculosCliente()
        {

            try
            {
                using (var context = new BDEFEntities())
                {
                    return context.Database.SqlQuery<usp_ListarVehiculosCliente_Result>("EXEC usp_ListarVehiculosCliente").ToList();
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public String RegresarLink(int idVehiculo)
        {
            using (var context = new BDEFEntities())
            {
                var vehiculo = context.Vehiculo.Find(idVehiculo);

                return vehiculo.ImagenVehiculo;
            }
        }
        public int RegresarTipoVehiculo(int codigoVehiculo)
        {
            using (var context = new BDEFEntities())
            {
                var vehiculo = context.Vehiculo.Find(codigoVehiculo);

                return vehiculo.CodigoTipoVehiculo;
            }
        }
        public bool ExistePlaca(String placa)
        {           
        
            
                using (var context = new BDEFEntities())
                {
                    bool vehiculo = context.Vehiculo.Any(ve=>ve.Placa.Equals(placa));
                    return  vehiculo;

                }

        }
        public List<Vehiculo> ListarMayorReservas()
        {
            /*
            int maximo = 0;

            List<Vehiculo> vehiculos = new List< Vehiculo>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    maximo = context.Vehiculo.Max(x => x.Reserva.Count);
                    vehiculos = context.Vehiculo.Where(x => x.Reserva.Count.Equals(maximo)).ToList();
                }

                return vehiculos;
            }
            catch (Exception ex)
            {
                return null;
            }*/
            int minimo = 0;
            List<Reserva> reservas = new List<Reserva>();
            List<Vehiculo> vehiculosTemp = new List<Vehiculo>();
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Vehiculo> vehiculosFinal = new List<Vehiculo>();

            try
            {

                int maxCantidad = 0;
                using (var context = new BDEFEntities())
                {

                    reservas = context.Reserva.Where(x => x.CodigoEstadoReserva == 1).ToList();
                    vehiculos = context.Vehiculo.ToList();

                    foreach (Vehiculo v in vehiculos)
                    {
                        int cantidad = 0;
                        foreach (Reserva r in reservas)
                        {
                            if (v.CodigoVehiculo == r.CodigoVehiculo) cantidad++;
                        }
                        if (maxCantidad <= cantidad && cantidad != 0)
                        {
                            maxCantidad = cantidad;
                        }
                    }

                    foreach (Vehiculo v in vehiculos)
                    {
                        int cantidad = 0;
                        foreach (Reserva r in reservas)
                        {
                            if (v.CodigoVehiculo == r.CodigoVehiculo) cantidad++;
                        }
                        if (maxCantidad == cantidad)
                        {
                            if (vehiculosTemp.Exists(x => x.CodigoVehiculo == v.CodigoVehiculo) == false)
                            {
                                vehiculosTemp.Add(v);
                            }
                        }
                    }



                }

                return vehiculosTemp;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Vehiculo>ListarMenosReservas()
        {
            int minimo = 0;
            List<Reserva> reservas = new List<Reserva>();
            List<Vehiculo> vehiculosTemp = new List<Vehiculo>();
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Vehiculo> vehiculosFinal = new List<Vehiculo>();

            try
            { 
                 
                 int minCantidad=100000;
                 using (var context = new BDEFEntities())
                 {

                    reservas = context.Reserva.Where(x=>x.CodigoEstadoReserva==1).ToList();
                    vehiculos = context.Vehiculo.ToList();

                    foreach(Vehiculo v in vehiculos){
                        int cantidad = 0;
                        foreach(Reserva r in reservas){
                            if(v.CodigoVehiculo == r.CodigoVehiculo) cantidad++;                                                                               
                        }
                        if(minCantidad>=cantidad&&cantidad!=0){
                          minCantidad = cantidad;
                        }
                    }

                    foreach(Vehiculo v in vehiculos){
                        int cantidad = 0;
                        foreach(Reserva r in reservas){
                            if(v.CodigoVehiculo == r.CodigoVehiculo) cantidad++;                                                                               
                        }
                       if(minCantidad==cantidad)
                       {
                            if (vehiculosTemp.Exists(x => x.CodigoVehiculo == v.CodigoVehiculo) == false)
                            {
                                vehiculosTemp.Add(v);
                            }
                       }
                    }                                       

                    
                
                 }

                return vehiculosTemp;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}

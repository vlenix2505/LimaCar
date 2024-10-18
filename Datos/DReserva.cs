using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DReserva
    {
        public String Registrar(Reserva reserva)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Reserva.Add(reserva);
                    context.SaveChanges();
                }
                return "Reserva registrada correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public String Modificar(Reserva reserva)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Reserva reservaTemp = context.Reserva.Find(reserva.CodigoReserva);
                    reservaTemp.FechaInicio = reserva.FechaInicio;
                    reservaTemp.FechaFin = reserva.FechaFin;
                    reservaTemp.Galones = reserva.Galones;
                    reservaTemp.CodigoPago = reserva.CodigoPago;
                    reservaTemp.CodigoEstadoReserva = reserva.CodigoEstadoReserva;
                    reservaTemp.i_creadoPor = reserva.i_creadoPor;
                    reservaTemp.i_fechaCreacion = reserva.i_fechaCreacion;
                    reservaTemp.CodigoCliente = reserva.CodigoCliente;
                    reservaTemp.CodigoVehiculo = reserva.CodigoVehiculo;

                    context.SaveChanges();

                }
                return "Reserva modificada correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public String Eliminar(int id)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Reserva reservaTemp = context.Reserva.Find(id);
                    context.Reserva.Remove(reservaTemp);
                    context.SaveChanges();
                }
                return "Reserva eliminada correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public List<Reserva> ListarTodo()
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    reservas = context.Reserva.ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Reserva> ListarReservasPorCliente(int idCliente)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    reservas = context.Reserva.Where(x => x.CodigoCliente == idCliente).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public int CantidadReservas(List<Cliente> clientesTemp)
        {
            int cantidad = 0;
            int total = 0;
            try
            {
                using (var context = new BDEFEntities())
                {
                    List<Reserva> reservas = context.Reserva.ToList();

                    foreach (Reserva r in reservas)
                    {
                        foreach (Cliente c in clientesTemp)
                        {
                            if (r.CodigoCliente.Equals(c.CodigoCliente))
                            {
                                cantidad += 1;
                            }
                        }
                        total += cantidad;
                        cantidad = 0;
                    }

                }


                return total;
            }
            catch (Exception ex)
            {
                return total;
            }
        
        }
        public List<Reserva>ListarReservasPorDni(String Dni)
        {

            List<Reserva> reservas = new List<Reserva>();
            List<Reserva> reservasFinal = new List<Reserva>();

            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente = new Cliente();
            try
            {
                using (var context = new BDEFEntities())
                {
                    clientes=context.Cliente.ToList();
                    reservas = context.Reserva.ToList();
                    foreach (Cliente c in clientes)
                    {
                        if (c.Dni.Equals(Dni))
                        {
                            cliente = c;
                        }

                    }
                    foreach (Reserva r in reservas)
                    {
                        if (cliente.CodigoCliente == r.CodigoCliente)
                        {
                            reservasFinal.Add(r);
                        }
                        
                    }



                }
                return reservasFinal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Reserva> ListarReservasPorEstadoTipo(int codigoEstado, int codigoTipo)
        {
            if (codigoEstado != 0 && codigoTipo ==0)
            {
                List<Reserva> reservas = new List<Reserva>();
                try
                {
                    using (var context = new BDEFEntities())
                    {
                        reservas = context.Reserva.Where(x => x.CodigoEstadoReserva == codigoEstado).ToList();
                    }
                    return reservas;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
            else if (codigoEstado == 0 && codigoTipo != 0)
            {
                List<Reserva> reservas = new List<Reserva>();
                List<Vehiculo> vehiculos = new List<Vehiculo>();
                try
                {
                    using (var context = new BDEFEntities())
                    {
                        vehiculos = context.Vehiculo.Where(x => x.CodigoTipoVehiculo == codigoTipo).ToList();
                        foreach (Vehiculo v in vehiculos)
                        {
                            foreach (Reserva r in context.Reserva.ToList())
                            {
                                if (r.CodigoVehiculo == v.CodigoVehiculo) reservas.Add(r);
                            }
                        }
                    }
                    return reservas;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else if(codigoEstado != 0 && codigoTipo != 0)
            {
                List<Reserva> reservas = new List<Reserva>();
                List<Vehiculo> vehiculos = new List<Vehiculo>();
                try
                {
                    using (var context = new BDEFEntities())
                    {
                        vehiculos = context.Vehiculo.Where(x => x.CodigoTipoVehiculo == codigoTipo).ToList();
                        foreach (Vehiculo v in vehiculos)
                        {
                            foreach (Reserva r in context.Reserva.ToList())
                            {
                                if (r.CodigoVehiculo == v.CodigoVehiculo && r.CodigoEstadoReserva==codigoEstado) reservas.Add(r);
                            }
                        }
                    }
                    return reservas;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }

        public List<Reserva> ListarReservasPorRango(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                reservas = context.Reserva.Where(x=>x.FechaInicio > fechaInicio && 
                x.FechaFin<fechaFin).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        
        public List<Reserva> ListarReservasPorPlaca(int id)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    Vehiculo vehiculo = context.Vehiculo.Find(id);
                    reservas = context.Reserva.Where(x => x.CodigoVehiculo == id).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public Decimal MontoPorReporte(List<Reserva>reservas)
        {
            List<Pago> pagos = new List<Pago>();           
            Decimal montoRango = 0;
            if (reservas != null)
            {
                try
                {
                    using (var context = new BDEFEntities())
                    {
                        foreach (Reserva r in reservas)
                        {
                            Pago pago = context.Pago.Find(r.CodigoPago);
                            if(pago!=null) montoRango += pago.Monto;
                        }
                    }
                    return montoRango;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            return montoRango;
        }
        
        
    }
}

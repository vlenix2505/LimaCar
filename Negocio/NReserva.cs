using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NReserva
    {
        private DReserva dReserva = new DReserva();
        public NReserva() { }

        public List<Reserva> ListarTodo()
        {
            return dReserva.ListarTodo();
        }
        
        public List<Reserva> ListarReservasPorCliente(int idCliente)
        {
            return dReserva.ListarReservasPorCliente(idCliente);
        }

        public String Registrar(Reserva reserva)
        {
            return dReserva.Registrar(reserva);
        }
        public String Eliminar(int id)
        {
            return dReserva.Eliminar(id);
        }
        public String Modificar(Reserva reserva)
        {
            return dReserva.Modificar(reserva);
        }

        public int CantidadReservas(List<Cliente> clientestemp)
        {
            return dReserva.CantidadReservas(clientestemp);
        }
        public List<Reserva> ListarReservasPorEstadoTipo(int codigoEstado, int codigoTipo)
        {
            return dReserva.ListarReservasPorEstadoTipo(codigoEstado, codigoTipo);
        }

        public List<Reserva> ListarReservasPorRango(DateTime fechaInicio, DateTime fechaFin)
        {
            return dReserva.ListarReservasPorRango(fechaInicio,fechaFin);
        }

        public Decimal MontoPorReporte(List<Reserva>reservas)
        {
            return dReserva.MontoPorReporte(reservas);
        }
        public List<Reserva> ListarReservasPorDni(String Dni)
        {
            return dReserva.ListarReservasPorDni(Dni);
        }
        public List<Reserva> ListarReservasPorPlaca(int id)
        {
          return dReserva.ListarReservasPorPlaca(id);
        }


    }
}

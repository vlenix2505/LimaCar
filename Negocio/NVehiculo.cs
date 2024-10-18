using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NVehiculo
    {
        private DVehiculo dV = new DVehiculo();

        public NVehiculo() { }

        public String Registrar(Vehiculo vehiculo)
        {
            return dV.Registrar(vehiculo);
        }

        public String Modificar(Vehiculo Vehiculo)
        {

            return dV.Modificar(Vehiculo);
        }

        public String Eliminar(int id)
        {
            return dV.Eliminar(id);
        }

        public List<Vehiculo> ListarTodo()
        {
            return dV.ListarTodo();
        }
        public List <Vehiculo> ListarVehiculosSolicitud(int idTipoVehiculo, DateTime fechaInicio, DateTime fechaFin)
        {
            return dV.ListarVehiculosSolicitud(idTipoVehiculo, fechaInicio, fechaFin);
        }
        public List<Vehiculo> ListarPrecioPorAscendente(List<Vehiculo> vehiculosTemp, int codigoTipo)
        {
            return dV.ListarPrecioPorAscendente(vehiculosTemp,codigoTipo);
        }
        public List<Vehiculo> ListarPrecioPorDescendente(List<Vehiculo> vehiculosTemp, int codigoTipo)
        {
            return dV.ListarPrecioPorDescendente(vehiculosTemp, codigoTipo);

        }
        public List<Vehiculo> ListarVehiculosXMarca(int codigoMarca, int codigoTipo, List<Vehiculo> vehiculosTemp)
        {
            return dV.ListarVehiculosXMarca(codigoMarca, codigoTipo, vehiculosTemp);
        }
        public List<usp_ListarVehiculosCliente_Result> ListarVehiculosCliente()
        {

            return dV.ListarVehiculosCliente();
        }
        public String RegresarLink(int idVehiculo)
        {
            return dV.RegresarLink(idVehiculo);
        }
         public bool ExistePlaca(String placa)
        {
            return dV.ExistePlaca(placa);
        }
        public int RegresarTipoVehiculo(int codigoVehiculo)
        {
            return dV.RegresarTipoVehiculo(codigoVehiculo);

        }
        public List<Vehiculo> ListarPorPlaca(String placa)
        {
            return dV.ListarPorPlaca(placa);
        }
        public List<Vehiculo> ListarPorTipo(int codigoTipo)
        {
            return dV.ListarPorTipo(codigoTipo);
        }
        public List<Vehiculo> ListarMayorReservas()
        {
            return dV.ListarMayorReservas();


        }

        public List<Vehiculo> ListarMenosReservas()
        {
            return dV.ListarMenosReservas();
        }
    }
}

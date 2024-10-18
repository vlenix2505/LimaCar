using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DPago
    {
        public DPago() { }
        public String Registrar(Pago pago)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Pago.Add(pago);
                    context.SaveChanges();
                }
                return "Pago registrado correctamente";
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
                    Pago pagoTemp = context.Pago.Find(codigo);
                    context.Pago.Remove(pagoTemp);
                    context.SaveChanges();
                }
                return "Pago eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public List<Pago> ListarTodo()
        {
            List<Pago> pagos = new List<Pago>();
            try
            {
                using (var context = new BDEFEntities())
                {
                   pagos = context.Pago.ToList();
                }
                return pagos;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Pago> ListarPorTipoFecha(int codigoTipo, DateTime fechaMinima, int isNull)
        {
            List<Pago> pagos = new List<Pago>();
            if(codigoTipo!=0 && isNull==0)
            {
                try
                {
                    using (var context = new BDEFEntities())
                    {
                        pagos = context.Pago.Where(x => x.CodigoTipoPago == codigoTipo).ToList();

                    }
                    return pagos;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }else if(codigoTipo == 0 && isNull != 0)
            {
                try
                {
                    using (var context = new BDEFEntities())
                    {
                        pagos = context.Pago.Where(x => x.FechaPago>=fechaMinima).ToList();

                    }
                    return pagos;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else if(codigoTipo != 0 &&  isNull!=0)
            {
                try
                {
                    using (var context = new BDEFEntities())
                    {
                        pagos = context.Pago.Where(x => x.FechaPago >= fechaMinima && x.CodigoTipoPago==codigoTipo).ToList(); 

                    }
                    return pagos;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;

        }

        public List<Pago> ListarPorRangoMonto(Decimal montoMin, Decimal montoMax)
        {
            List<Pago> pagos = new List<Pago>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    pagos = context.Pago.Where(x => x.Monto>=montoMin && x.Monto<=montoMax).ToList();

                }
                return pagos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

      
        public List<Pago> ListarPorMayorMonto()
        {
            List<Pago> pagos = new List<Pago>();
            try
            {
                using (var context = new BDEFEntities())
                {           
                    Decimal montoMayor = context.Pago.Max(x => x.Monto);
                    pagos = context.Pago.Where(x => x.Monto == montoMayor).ToList();                    

                }
                return pagos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Pago> ListarPorCliente(int codigoCliente)
        {
            List<Pago> pagos = new List<Pago>();
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    reservas = context.Reserva.Where(x => x.CodigoCliente == codigoCliente).ToList();
                    foreach(Reserva r in reservas)
                    {
                        if (r.CodigoPago != null)
                        {
                            Pago pago = context.Pago.Find(r.CodigoPago);
                            pagos.Add(pago);
                        }
                    }

                }
                return pagos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}

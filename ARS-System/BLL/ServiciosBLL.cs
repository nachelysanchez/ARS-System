using ARS_System.DAL;
using ARS_System.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.BLL
{
    public class ServiciosBLL
    {
        public static Servicios Buscar(int id)
        {
            Servicios servicios;

            Contexto contexto = new Contexto();

            try
            {
                servicios = contexto.Servicios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return servicios;
        }

        public static List<Servicios> GetList(Expression<Func<Servicios, bool>> criterio)
        {
            List<Servicios> Lista = new List<Servicios>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Servicios.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static List<Servicios> GetOcupaciones()
        {
            List<Servicios> Lista = new List<Servicios>();

            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Servicios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}

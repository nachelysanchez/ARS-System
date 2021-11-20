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
    public class OcupacionesBLL
    {
        public static Ocupaciones Buscar(int id)
        {
            Ocupaciones ocupaciones;
            Contexto contexto = new Contexto();

            try
            {
                ocupaciones = contexto.Ocupaciones.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ocupaciones;
        }

        public static List<Ocupaciones> GetList(Expression<Func<Ocupaciones, bool>> criterio)
        {
            List<Ocupaciones> Lista = new List<Ocupaciones>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Ocupaciones.Where(criterio).ToList();
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

        public static List<Ocupaciones> GetOcupaciones()
        {
            List<Ocupaciones> Lista = new List<Ocupaciones>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Ocupaciones.ToList();
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

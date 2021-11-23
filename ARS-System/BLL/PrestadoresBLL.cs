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
    public class PrestadoresBLL
    {
        public static Prestadores Buscar(int id)
        {
            Prestadores prestador;
            Contexto contexto = new Contexto();

            try
            {
                prestador = contexto.Prestadores.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return prestador;
        }

        public static List<Prestadores> GetList(Expression<Func<Prestadores, bool>> criterio)
        {
            List<Prestadores> Lista = new List<Prestadores>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Prestadores.Where(criterio).ToList();
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

        public static List<Prestadores> GetPrestadores()
        {
            List<Prestadores> Lista = new List<Prestadores>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Prestadores.ToList();
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

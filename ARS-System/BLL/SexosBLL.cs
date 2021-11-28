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
    public class SexosBLL
    {
        public static Sexos Buscar(int id)
        {
            Sexos sexo;
            Contexto contexto = new Contexto();

            try
            {
                sexo = contexto.Sexos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return sexo;
        }

        public static List<Sexos> GetList(Expression<Func<Sexos, bool>> criterio)
        {
            List<Sexos> Lista = new List<Sexos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Sexos.Where(criterio).ToList();
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

        public static List<Sexos> GetSexos()
        {
            List<Sexos> Lista = new List<Sexos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Sexos.ToList();
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

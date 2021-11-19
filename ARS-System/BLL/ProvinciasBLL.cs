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
    public class ProvinciasBLL
    {
        public static Provincias Buscar(int id)
        {
            Provincias provincia;
            Contexto contexto = new Contexto();

            try
            {
                provincia = contexto.Provincias.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return provincia;
        }

        public static List<Provincias> GetList(Expression<Func<Provincias, bool>> criterio)
        {
            List<Provincias> Lista = new List<Provincias>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Provincias.Where(criterio).ToList();
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

        public static List<Provincias> GetProvincias()
        {
            List<Provincias> Lista = new List<Provincias>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Provincias.ToList();
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

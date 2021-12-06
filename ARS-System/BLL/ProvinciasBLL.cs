using ARS_System.DAL;
using ARS_System.Entidades;
using Microsoft.EntityFrameworkCore;
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
        public static bool Guardar(Provincias provincias)
        {
            if (!Existe(provincias.ProvinciaId))
            {
                return Insertar(provincias);
            }
            else
            {
                return Modificar(provincias);
            }
        }

        private static bool Insertar(Provincias provincias)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Provincias.Add(provincias);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Provincias provincias)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(provincias).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Provincias.Any(e => e.ProvinciaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static bool ExisteNombre(string nombre)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Provincias.Any(e => e.Nombres == nombre);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var provincia = contexto.Provincias.Find(id);
                if (provincia != null)
                {
                    contexto.Provincias.Remove(provincia);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
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

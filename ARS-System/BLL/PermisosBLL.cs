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
    public class PermisosBLL
    {
        public static bool Guardar(Permisos permisos)
        {
            if (!Existe(permisos.PermisoId))
            {
                return Insertar(permisos);
            }
            else
            {
                return Modificar(permisos);
            }
        }

        private static bool Insertar(Permisos permisos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Permisos.Add(permisos);
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
        public static bool Modificar(Permisos permisos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(permisos).State = EntityState.Modified;
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
                encontrado = contexto.Permisos.Any(e => e.PermisoId == id);
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

        public static Permisos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Permisos permisos;

            try
            {
                permisos = contexto.Permisos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return permisos;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var permisos = contexto.Permisos.Find(id);
                if (permisos != null)
                {
                    contexto.Permisos.Remove(permisos);
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

        public static List<Permisos> GetList(Expression<Func<Permisos, bool>> criterio)
        {
            List<Permisos> lista = new List<Permisos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Permisos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static List<Permisos> GetPermisos()
        {
            List<Permisos> lista = new List<Permisos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Permisos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}

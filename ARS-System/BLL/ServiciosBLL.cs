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
    public class ServiciosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();

            bool encontrado = false;

            try
            {
                encontrado = contexto.Servicios.Any(e => e.ServicioId == id);
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
        public static bool Guardar(Servicios servicio)
        {
            if (!Existe(servicio.ServicioId))
            {
                return Insertar(servicio);
            }
            else
            {
                return Modificar(servicio);
            }
        }


        private static bool Insertar(Servicios servicio)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Servicios.Add(servicio);
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

        public static bool Modificar(Servicios servicio)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(servicio).State = EntityState.Modified;
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

        public static Servicios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Servicios servicio;

            try
            {
                servicio = contexto.Servicios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return servicio;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var servicio = contexto.Servicios.Find(id);

                if (servicio != null)
                {
                    contexto.Servicios.Remove(servicio);
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

        public static List<object> GetList(string criterio, string valor, DateTime? desde, DateTime? hasta)
        {
            List<object> lista;
            Contexto contexto = new Contexto();

            try
            {
                var query = (
                    from s in contexto.Servicios
                    select new
                    {
                        s.ServicioId,
                        s.Fecha,
                        s.Descripcion,
                        s.VecesAsignado

                    }
                );

                if (criterio.Length != 0)
                {
                    switch (criterio)
                    {
                        case "ServicioId":
                            query = query.Where(c => c.ServicioId == Utilidades.ToInt(valor));
                            break;

                        case "Descripcion":
                            query = query.Where(c => c.Descripcion.ToLower().Contains(valor.ToLower()));
                            break;

                    }
                }

                if (desde != null && hasta != null)
                {
                    query = query.Where(c => c.Fecha >= desde && c.Fecha <= hasta);
                }
                else if (desde != null)
                {
                    query = query.Where(c => c.Fecha >= desde);
                }
                else if (hasta != null)
                {
                    query = query.Where(c => c.Fecha <= hasta);
                }

                lista = query.ToList<object>();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static List<Servicios> GetServicios()
        {
            List<Servicios> lista = new List<Servicios>();

            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Servicios.ToList();
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

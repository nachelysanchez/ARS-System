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
    public class ReclamacionesBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();

            bool encontrado = false;

            try
            {
                encontrado = contexto.Reclamaciones.Any(e => e.ReclamacionId == id);
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
        public static bool Guardar(Reclamaciones reclamacion)
        {
            if (!Existe(reclamacion.ReclamacionId))
            {
                return Insertar(reclamacion);
            }
            else
            {
                return Modificar(reclamacion);
            }
        }
        public static bool Insertar(Reclamaciones reclamacion)
        {

            Contexto contexto = new Contexto();

            bool paso = false;

            try
            {
                contexto.Reclamaciones.Add(reclamacion);

                foreach (var detalle in reclamacion.RDetalle)
                {
                    contexto.Entry(detalle.Servicio).State = EntityState.Modified;
                    contexto.Entry(detalle.Diagnostico).State = EntityState.Modified;
                }
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

        public static bool Modificar(Reclamaciones reclamacion)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                var reclamacionAnterior = contexto.Reclamaciones
                     .Where(x => x.ReclamacionId == reclamacion.ReclamacionId)
                     .Include(x => x.RDetalle)
                     .ThenInclude(x => x.Servicio)
                     .AsNoTracking()
                     .SingleOrDefault();

                contexto.Database.ExecuteSqlRaw($"Delete FROM Reclamaciones Where ReclamacionId={reclamacion.ReclamacionId}");

                foreach (var item in reclamacion.RDetalle)
                {

                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(reclamacion).State = EntityState.Modified;

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
        public static Reclamaciones Buscar(int id)
        {
            Reclamaciones reclamacion = new Reclamaciones();

            Contexto contexto = new Contexto();

            try
            {
                reclamacion = contexto.Reclamaciones.Include(x => x.RDetalle)
                   .Where(x => x.ReclamacionId == id)
                   .Include(x => x.RDetalle)
                   .ThenInclude(x => x.Servicio)
                   .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return reclamacion;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {

                var reclamacion = Buscar(id);

                if (reclamacion != null)
                {

                    foreach (var detalle in reclamacion.RDetalle)
                    {
                        contexto.Entry(detalle.Servicio).State = EntityState.Modified;

                    }

                    contexto.Reclamaciones.Remove(reclamacion);

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
        public static List<Reclamaciones> GetList(Expression<Func<Reclamaciones, bool>> criterio)
        {
            List<Reclamaciones> Lista = new List<Reclamaciones>();

            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Reclamaciones.Where(criterio).ToList();
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

        public static List<Reclamaciones> GetReclamaciones()
        {
            List<Reclamaciones> lista = new List<Reclamaciones>();

            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Reclamaciones.ToList();
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

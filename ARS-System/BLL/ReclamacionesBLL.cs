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
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.Servicio).State = EntityState.Modified;
                    contexto.Entry(detalle.Afiliado).State = EntityState.Modified;
                    detalle.Servicio.VecesAsignado += 1;
                    detalle.Afiliado.ValorReclamado += detalle.ValorReclamado;
                    reclamacion.Total += detalle.ValorReclamado;
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
                     .AsNoTracking()
                     .SingleOrDefault();

                Servicios servicio;
                Afiliados afiliado;

                foreach (var detalle in reclamacionAnterior.RDetalle)
                {
                    afiliado = contexto.Afiliados.Find(detalle.AfiliadoId);
                    servicio = contexto.Servicios.Find(detalle.ServicioId);
                    servicio.VecesAsignado -= 1;
                    afiliado.ValorReclamado -= detalle.ValorReclamado;
                    reclamacion.Total -= detalle.ValorReclamado;
                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM ReclamacionesDetalle Where ReclamacionId={reclamacion.ReclamacionId}");

                foreach (var item in reclamacion.RDetalle)
                {
                    afiliado = contexto.Afiliados.Find(item.AfiliadoId);
                    servicio = contexto.Servicios.Find(item.ServicioId);
                    servicio.VecesAsignado += 1;
                    afiliado.ValorReclamado += item.ValorReclamado;
                    reclamacion.Total += item.ValorReclamado;

                    contexto.Entry(servicio).State = EntityState.Modified;
                    contexto.Entry(afiliado).State = EntityState.Modified;
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
                   .Include(x => x.RDetalle)
                   .ThenInclude(x => x.Afiliado)
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
                        contexto.Entry(detalle.Afiliado).State = EntityState.Modified;
                        detalle.Servicio.VecesAsignado -= 1;
                        reclamacion.Total -= detalle.ValorReclamado;
                        detalle.Afiliado.ValorReclamado -= detalle.ValorReclamado;
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

        public static List<object> GetList(string criterio, string valor, DateTime? desde, DateTime? hasta)
        {
            List<object> lista;
            Contexto contexto = new Contexto();

            try
            {
                var query = (
                    from u in contexto.Reclamaciones
                    join r in contexto.Doctores on u.DoctorId equals r.DoctorId
                    join a in contexto.Afiliados on u.AfiliadoId equals a.AfiliadoId
                    join s in contexto.Prestadores on u.PrestadorId equals s.PrestadorId
                    select new
                    {
                        u.ReclamacionId,
                        u.Fecha,
                        u.NoAutorizacion,
                        u.NAF,
                        Doctor = (r.Nombres),
                        Afiliado = (a.Nombres),
                        Prestador = (s.Nombres),
                        u.Total
                    }
                );

                if (criterio.Length != 0)
                {
                    switch (criterio)
                    {
                        case "ReclamacionId":
                            query = query.Where(c => c.ReclamacionId == Utilidades.ToInt(valor));
                            break;
                        case "NoAutorizacion":
                            query = query.Where(c => c.NoAutorizacion == Utilidades.ToInt(valor));
                            break;
                        case "NAF":
                            query = query.Where(c => c.NAF == Utilidades.ToInt(valor));
                            break;
                        case "Doctor":
                            query = query.Where(c => c.Doctor.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Afiliado":
                            query = query.Where(c => c.Afiliado.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Prestador":
                            query = query.Where(c => c.Prestador.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Total":
                            query = query.Where(c => c.Total == Utilidades.ToFloat(valor));
                            break;
                        
                    }
                }

                if (desde != null && hasta != null)
                {
                    query = query.Where(c => c.Fecha >= desde && c.Fecha <= hasta);
                }
                else if(desde != null)
                {
                    query = query.Where(c => c.Fecha >= desde);
                }
                else if(hasta != null)
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

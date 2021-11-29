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
    public class DoctoresBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();

            bool encontrado = false;

            try
            {
                encontrado = contexto.Doctores.Any(e => e.DoctorId == id);

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
        public static bool Guardar(Doctores doctores)
        {
            if (!Existe(doctores.DoctorId))
            {
                return Insertar(doctores);
            }
            else
            {
                return Modificar(doctores);
            }
        }
        public static bool Insertar(Doctores doctores)
        {

            Contexto contexto = new Contexto();

            bool paso = false;

            try
            {
                contexto.Doctores.Add(doctores);

                foreach (var detalle in doctores.Detalle)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.Especialidades).State = EntityState.Modified;
                    detalle.Especialidades.VecesAsignado += 1;
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
        public static bool Modificar(Doctores doctores)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                var doctorAnterior = contexto.Doctores
                     .Where(x => x.DoctorId == doctores.DoctorId)
                     .Include(x => x.Detalle)
                     .ThenInclude(x => x.Especialidades)
                     .AsNoTracking()
                     .SingleOrDefault();

                foreach (var detalle in doctorAnterior.Detalle)
                {
                    detalle.Especialidades.VecesAsignado -= 1;
                    //contexto.Entry(detalle.Especialidades).State = EntityState.Modified;
                }
                contexto.Database.ExecuteSqlRaw($"Delete FROM DoctoresDetalle Where DoctorId={doctores.DoctorId}");

                foreach (var item in doctores.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                    item.Especialidades.VecesAsignado += 1;
                }

                contexto.Entry(doctores).State = EntityState.Modified;

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

        public static Doctores Buscar(int id)
        {
            Doctores doctores = new Doctores();

            Contexto contexto = new Contexto();

            try
            {
                doctores = contexto.Doctores.Include(x => x.Detalle)
                   .Where(x => x.DoctorId == id)
                   .Include(x => x.Detalle)
                   .ThenInclude(x => x.Especialidades)
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
            return doctores;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {

                var doctor = DoctoresBLL.Buscar(id);

                if (doctor != null)
                {

                    foreach (var detalle in doctor.Detalle)
                    {
                        contexto.Entry(detalle.Especialidades).State = EntityState.Modified;
                        detalle.Especialidades.VecesAsignado -= 1;
                    }

                    contexto.Doctores.Remove(doctor);

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

        public static List<Doctores> GetList(Expression<Func<Doctores, bool>> criterio)
        {
            List<Doctores> Lista = new List<Doctores>();

            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Doctores.Where(criterio).ToList();
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

        public static List<Doctores> GetDoctores()
        {
            List<Doctores> lista = new List<Doctores>();

            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Doctores.ToList();
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

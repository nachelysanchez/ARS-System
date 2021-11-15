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
    public class EspecialidadesBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Especialidades.Any(e => e.EspecialidadId == id);
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
        public static bool Guardar(Especialidades especialidad)
        {
            if (!Existe(especialidad.EspecialidadId))
            {
                return Insertar(especialidad);
            }
            else
            {
                return Modificar(especialidad);
            }
        }

        private static bool Insertar(Especialidades especialidad)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Especialidades.Add(especialidad);
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

        public static bool Modificar(Especialidades especialidad)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(especialidad).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var especialidad = contexto.Especialidades.Find(id);

                if (especialidad != null)
                {
                    contexto.Especialidades.Remove(especialidad);
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

        public static Especialidades Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Especialidades especialidad;

            try
            {
                especialidad = contexto.Especialidades.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return especialidad;
        }

        public static List<Especialidades> GetList(Expression<Func<Especialidades, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Especialidades> lista = new List<Especialidades>();

            try
            {
                lista = contexto.Especialidades.Where(criterio).ToList();
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

        public static List<Especialidades> GetEspecialidades()
        {
            Contexto contexto = new Contexto();
            List<Especialidades> lista = new List<Especialidades>();

            try
            {
                lista = contexto.Especialidades.ToList();
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

        public static bool ExisteNombre(string nombre)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Especialidades.Any(e => e.NombreEspecialidad == nombre);
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
    }
}

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
    public class RolesBLL
    {
        public static bool Guardar(Roles rol)
        {
            if (!Existe(rol.RolId))
                return Insertar(rol);
            else
                return Modificar(rol);
        }
        private static bool Insertar(Roles rol)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Roles.Add(rol) != null)
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
        private static bool Modificar(Roles rol)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(rol).State = EntityState.Modified;
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
        public static Roles Buscar(int id)
        {
            Roles rol = new Roles();

            Contexto contexto = new Contexto();

            try
            {
                rol = contexto.Roles.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return rol;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                var roles = contexto.Roles.Find(id);
                if (roles != null)
                {
                    contexto.Roles.Remove(roles);

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
        public static List<Roles> GetList(Expression<Func<Roles, bool>> criterio)
        {
            List<Roles> Lista = new List<Roles>();

            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Roles.Where(criterio).ToList();
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
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();

            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.RolId == id);
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
        public static List<Roles> GetRoles()
        {
            List<Roles> lista = new List<Roles>();

            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Roles.ToList();
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

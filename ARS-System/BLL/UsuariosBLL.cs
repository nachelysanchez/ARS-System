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
    public class UsuariosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Usuarios.Any(e => e.UsuarioId == id);

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
        public static bool Guardar(Usuarios usuarios)
        {
            if (!Existe(usuarios.UsuarioId))
            {
                return Insertar(usuarios);
            }
            else
            {
                return Modificar(usuarios);
            }
        }
        public static bool Insertar(Usuarios usuarios)
        {

            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Usuarios.Add(usuarios);

                foreach (var detalle in usuarios.DetalleUsuario)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.Permisos).State = EntityState.Modified;
                    detalle.Permisos.CantidadPermisos += 1;

                    //usuarios.TotalAsignado += detalle.Permisos.CantidadPermisos;
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
        public static bool Modificar(Usuarios usuarios)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                var usuarioAnterior = contexto.Usuarios
                     .Where(x => x.UsuarioId == usuarios.UsuarioId)
                     .Include(x => x.DetalleUsuario)
                     .ThenInclude(x => x.Permisos)
                     .AsNoTracking()
                     .SingleOrDefault();

                foreach (var detalle in usuarioAnterior.DetalleUsuario)
                {
                    usuarioAnterior.TotalAsignado -= 1;
                    detalle.Permisos.CantidadPermisos -= 1;
                }
                contexto.Database.ExecuteSqlRaw($"Delete FROM UsuariosDetalle Where UsuarioId={usuarios.UsuarioId}");

                foreach (var item in usuarios.DetalleUsuario)
                {

                    usuarioAnterior.TotalAsignado += 1;
                    item.Permisos.CantidadPermisos += 1;
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(usuarios).State = EntityState.Modified;

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

        public static Usuarios Buscar(int id)
        {
            Usuarios usuarios = new Usuarios();

            Contexto contexto = new Contexto();

            try
            {
                usuarios = contexto.Usuarios.Include(x => x.DetalleUsuario)
                   .Where(x => x.UsuarioId == id)
                   .Include(x => x.DetalleUsuario)
                   .ThenInclude(x => x.Permisos)
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
            return usuarios;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {

                var usuario = UsuariosBLL.Buscar(id);

                if (usuario != null)
                {

                    foreach (var detalle in usuario.DetalleUsuario)
                    {
                        contexto.Entry(detalle.Permisos).State = EntityState.Modified;

                    }

                    contexto.Usuarios.Remove(usuario);

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

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> criterio)
        {
            List<Usuarios> Lista = new List<Usuarios>();

            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Usuarios.Where(criterio).ToList();
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

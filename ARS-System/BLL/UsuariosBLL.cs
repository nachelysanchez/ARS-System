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
        public static bool ExisteUsername(string username)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Usuarios.Any(e => e.Username == username);

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
                     .AsNoTracking()
                     .SingleOrDefault();

                Permisos permiso;

                foreach (var detalle in usuarioAnterior.DetalleUsuario)
                {
                    permiso = contexto.Permisos.Find(detalle.PermisoId);
                    permiso.CantidadPermisos += 1;
                }
                contexto.Database.ExecuteSqlRaw($"Delete FROM UsuariosDetalle Where UsuarioId={usuarios.UsuarioId}");

                foreach (var item in usuarios.DetalleUsuario)
                {
                    permiso = contexto.Permisos.Find(item.PermisoId);
                    permiso.CantidadPermisos -= 1;
                    contexto.Entry(item.Permisos).State = EntityState.Modified;
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

                var usuario = Buscar(id);

                if (usuario != null)
                {

                    foreach (var detalle in usuario.DetalleUsuario)
                    {
                        contexto.Entry(detalle.Permisos).State = EntityState.Modified;
                        detalle.Permisos.CantidadPermisos -= 1;

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
        public static List<object> GetList(string criterio, string valor)
        {
            List<object> lista;
            Contexto contexto = new Contexto();

            try
            {
                var query = (
                    from u in contexto.Usuarios
                    join r in contexto.Roles on u.RolId equals r.RolId
                    select new
                    {
                        u.UsuarioId,
                        u.Nombres,
                        u.Username,
                        u.Contrasena,
                        Role = (r.Nombre)
                    }
                );

                if (criterio.Length != 0)
                {
                    switch (criterio)
                    {
                        case "UsuarioId":
                            query = query.Where(c => c.UsuarioId == Utilidades.ToInt(valor));
                            break;
                        case "Nombres":
                            query = query.Where(c => c.Nombres.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Username":
                            query = query.Where(c => c.Username.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Contrasena":
                            query = query.Where(c => c.Contrasena.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Role":
                            query = query.Where(c => c.Role.ToLower().Contains(valor.ToLower()));
                            break;
                       
                    }
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

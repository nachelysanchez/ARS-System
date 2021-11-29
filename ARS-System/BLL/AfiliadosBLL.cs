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
    public class AfiliadosBLL
    {
        /// <summary>
        /// Permite verificar si existe la entidad por id
        /// </summary>
        /// <param name="id">El id de la entidad que se desea verificar</param>
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Afiliados.Any(e => e.AfiliadoId == id);
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
        /// <summary>
        /// Permite insertar o modificar una entidad en la base de datos
        /// </summary>
        /// <param name="afiliado">La entidad que se desea guardar</param>
        public static bool Guardar(Afiliados afiliado)
        {
            if (!Existe(afiliado.AfiliadoId))
            {
                return Insertar(afiliado);
            }
            else
            {
                return Modificar(afiliado);
            }
        }
        /// <summary>
        /// Permite insertar una entidad en la base de datos
        /// </summary>
        /// <param name="afiliado">La entidad que se desea guardar</param>
        private static bool Insertar(Afiliados afiliado)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Afiliados.Add(afiliado);
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
        /// <summary>
        /// Permite modificar una entidad en la base de datos
        /// </summary>
        /// <param name="afiliado">La entidad que se desea guardar</param>
        public static bool Modificar(Afiliados afiliado)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(afiliado).State = EntityState.Modified;
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
        /// <summary>
        /// Permite eliminar una entidad en la base de datos
        /// </summary>
        /// <param name="id">El id de la entidad que se desea eliminar</param>

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var afiliado = contexto.Afiliados.Find(id);

                if (afiliado != null)
                {
                    contexto.Afiliados.Remove(afiliado);
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
        /// <summary>
        /// Permite buscar una entidad en la base de datos
        /// </summary>
        /// <param name="id">El id de la entidad que se desea buscar</param>
        public static Afiliados Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Afiliados afiliado;

            try
            {
                afiliado = contexto.Afiliados.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return afiliado;
        }
        /// <summary>
        /// Permite obtener una lista filtrada por un criterio de busqueda
        /// </summary>
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<Afiliados> GetList(Expression<Func<Afiliados, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Afiliados> lista = new List<Afiliados>();

            try
            {
                lista = contexto.Afiliados.Where(criterio).ToList();
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

        public static List<object> GetList(string criterio, string valor, DateTime? nacimiento)
        {
            List<object> lista;
            Contexto contexto = new Contexto();

            try
            {
                var query = (
                    from u in contexto.Afiliados
                    join r in contexto.Ciudades on u.CiudadId equals r.CiudadId
                    join a in contexto.Aseguradoras on u.AseguradoraId equals a.AseguradoraId
                    join s in contexto.Sexos on u.SexoId equals s.SexoId
                    join o in contexto.Ocupaciones on u.OcupacionId equals o.OcupacionId
                    select new
                    {
                        u.AfiliadoId,
                        u.Nombres,
                        u.FechaNacimiento,
                        u.Cedula,
                        Sexo = (s.Nombres),
                        u.NSS,
                        u.Telefono,
                        u.Celular,
                        u.Email,
                        u.Direccion,
                        Ciudad = (r.Nombres),
                        u.ValorReclamado,
                        Aseguradora = (a.Nombres),
                        Ocupacion = (o.Nombre)
                    }
                );

                if (criterio.Length != 0)
                {
                    switch (criterio)
                    {
                        case "AfiliadoId":
                            query = query.Where(c => c.AfiliadoId == Utilidades.ToInt(valor));
                            break;
                        case "Nombres":
                            query = query.Where(c => c.Nombres.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Cedula":
                            query = query.Where(c => c.Cedula.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Sexo":
                            query = query.Where(c => c.Sexo.ToLower().Contains(valor.ToLower()));
                            break;
                        case "NSS":
                            query = query.Where(c => c.NSS == Utilidades.ToInt(valor));
                            break;
                        case "Telefono":
                            query = query.Where(c => c.Telefono.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Celular":
                            query = query.Where(c => c.Celular.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Email":
                            query = query.Where(c => c.Email.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Direccion":
                            query = query.Where(c => c.Direccion.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Ciudad":
                            query = query.Where(c => c.Ciudad.ToLower().Contains(valor.ToLower()));
                            break;
                        case "ValorReclamado":
                            query = query.Where(c => c.ValorReclamado == Utilidades.ToFloat(valor));
                            break;
                        case "Aseguradora":
                            query = query.Where(c => c.Aseguradora.ToLower().Contains(valor.ToLower()));
                            break;
                        case "Ocupacion":
                            query = query.Where(c => c.Ocupacion.ToLower().Contains(valor.ToLower()));
                            break;
                    }
                }

                if (nacimiento != null)
                {
                    query = query.Where(c => c.FechaNacimiento >= nacimiento);
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
        /// <summary>
        /// Permite obtener una lista
        /// </summary>
        /// <returns></returns>
        public static List<Afiliados> GetAfiliados()
        {
            Contexto contexto = new Contexto();
            List<Afiliados> lista = new List<Afiliados>();

            try
            {
                lista = contexto.Afiliados.ToList();
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
        /// <summary>
        /// Permite verificar si existe la entidad por string
        /// </summary>
        /// <param name="nombre">El id de la entidad que se desea verificar</param>

        public static bool ExisteNombre(string nombre)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Afiliados.Any(e => e.Nombres == nombre);
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

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

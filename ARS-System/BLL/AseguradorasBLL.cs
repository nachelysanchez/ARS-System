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
    public class AseguradorasBLL
    {
        public static bool Guardar(Aseguradoras aseguradora)
        {
            if (!Existe(aseguradora.AseguradoraId))
                return Insertar(aseguradora);
            else
                return Modificar(aseguradora);
        }
        private static bool Insertar(Aseguradoras aseguradora)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Aseguradoras.Add(aseguradora) != null)
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
        private static bool Modificar(Aseguradoras aseguradora)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(aseguradora).State = EntityState.Modified;
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
        public static Aseguradoras Buscar(int id)
        {
            Aseguradoras aseguradora = new Aseguradoras();

            Contexto contexto = new Contexto();

            try
            {
                aseguradora = contexto.Aseguradoras.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return aseguradora;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                var aseguradoras = contexto.Aseguradoras.Find(id);
                if (aseguradoras != null)
                {
                    contexto.Aseguradoras.Remove(aseguradoras);

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
        public static List<Aseguradoras> GetList(Expression<Func<Aseguradoras, bool>> criterio)
        {
            List<Aseguradoras> Lista = new List<Aseguradoras>();

            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Aseguradoras.Where(criterio).ToList();
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
                encontrado = contexto.Aseguradoras.Any(e => e.AseguradoraId == id);
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
        public static List<Aseguradoras> GetAseguradoras()
        {
            List<Aseguradoras> lista = new List<Aseguradoras>();

            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Aseguradoras.ToList();
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

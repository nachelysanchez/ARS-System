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
    public class DiagnosticosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Diagnosticos.Any(e => e.DiagnosticoId == id);
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
        public static bool Guardar(Diagnosticos diagnostico)
        {
            if (!Existe(diagnostico.DiagnosticoId))
            {
                return Insertar(diagnostico);
            }
            else
            {
                return Modificar(diagnostico);
            }
        }
        private static bool Insertar(Diagnosticos diagnosticos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Diagnosticos.Add(diagnosticos);
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
        public static bool Modificar(Diagnosticos diagnosticos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(diagnosticos).State = EntityState.Modified;
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
                var diagnostico = contexto.Diagnosticos.Find(id);

                if (diagnostico != null)
                {
                    contexto.Diagnosticos.Remove(diagnostico);
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
        public static Diagnosticos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Diagnosticos diagnostico;

            try
            {
                diagnostico = contexto.Diagnosticos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return diagnostico;
        }

        public static List<Diagnosticos> GetList(Expression<Func<Diagnosticos, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Diagnosticos> lista = new List<Diagnosticos>();

            try
            {
                lista = contexto.Diagnosticos.Where(criterio).ToList();
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

        public static List<Diagnosticos> GetDiagnosticos()
        {
            Contexto contexto = new Contexto();
            List<Diagnosticos> lista = new List<Diagnosticos>();

            try
            {
                lista = contexto.Diagnosticos.ToList();
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
                encontrado = contexto.Diagnosticos.Any(e => e.Nombres == nombre);
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

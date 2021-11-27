using ARS_System.DAL;
using ARS_System.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.BLL
{
    public class SexosBLL
    {
        public static Sexos Buscar(int id)
        {
            Sexos sexo;
            Contexto contexto = new Contexto();

            try
            {
                sexo = contexto.Sexos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return sexo;
        }
    }
}

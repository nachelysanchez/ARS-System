using ARS_System.BLL;
using ARS_System.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ARS_System.UI.Registros
{
    /// <summary>
    /// Interaction logic for rServicios.xaml
    /// </summary>
    public partial class rServicios : Window
    {
        private Servicios servicio = new Servicios();
        public rServicios()
        {
            InitializeComponent();
            this.DataContext = servicio;
        }
        private void Cargar()
        {
            this.DataContext = null;

            this.DataContext = servicio;
        }
        private void Limpiar()
        {
            this.servicio = new Servicios();

            this.DataContext = servicio;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Servicios esValido = ServiciosBLL.Buscar(servicio.ServicioId);

            return (esValido != null);
        }
        private bool Validar()
        {
            bool esValido = true;

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Complete el campo faltante", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Servicios encontrado = ServiciosBLL.Buscar(servicio.ServicioId);

            if (encontrado != null)
            {
                servicio = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("El Servicio no existe en la Base de Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (servicio.ServicioId == 0)
            {
                paso = ServiciosBLL.Guardar(servicio);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = ServiciosBLL.Guardar(servicio);
                }
                else
                {
                    MessageBox.Show("No existe en la Base de Datos", "Error");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("¡Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("¡Fallo al guardar!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Servicios existe = ServiciosBLL.Buscar(servicio.ServicioId);

            if (existe == null)
            {
                MessageBox.Show("No existe el Servicio en la Base de Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                ServiciosBLL.Eliminar(servicio.ServicioId);
                MessageBox.Show("¡Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }
    }
}

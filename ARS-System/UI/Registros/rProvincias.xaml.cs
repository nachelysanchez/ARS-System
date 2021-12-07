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
    /// Interaction logic for rProvincias.xaml
    /// </summary>
    public partial class rProvincias : Window
    {
        private static bool MPaso = true;
        private Provincias provincias = new Provincias();
        public rProvincias()
        {
            InitializeComponent();
            this.DataContext = provincias;
        }
        private void Limpiar()
        {
            this.provincias = new Provincias();
            this.DataContext = provincias;
        }
        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = provincias;
        }
        private bool Validar()
        {
            bool esValido = true;
            if (NombreProvinciaTextBox.Text.Length == 0)
            {
                esValido = false;

                NombreProvinciaTextBox.Focus();
                MessageBox.Show("Debe ingresar un nombre", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var provincia = ProvinciasBLL.Buscar(Utilidades.ToInt(ProvinciaIdTextBox.Text));

            if (provincia != null)
            {
                provincias = provincia;
                MPaso = false;
                Actualizar();

            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                MPaso = true;
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            MPaso = true;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            if (!Validar())
                return;

            if (MPaso)
            {
                if (ProvinciasBLL.ExisteNombre(NombreProvinciaTextBox.Text))
                {
                    MessageBox.Show("Esta provincia ya Existe", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;

                }
                MPaso = true;
            }


            var paso = ProvinciasBLL.Guardar(provincias);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con exito!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Guardado Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            MPaso = true;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProvinciasBLL.Eliminar(Utilidades.ToInt(ProvinciaIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            MPaso = true;
        }
    }
}

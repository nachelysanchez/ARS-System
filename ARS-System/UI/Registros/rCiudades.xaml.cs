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
    /// Interaction logic for rCiudades.xaml
    /// </summary>
    public partial class rCiudades : Window
    {
        private Ciudades ciudades = new Ciudades();
        public rCiudades()
        {
            InitializeComponent();
            this.DataContext = ciudades;
        }
        private void Limpiar()
        {
            this.ciudades = new Ciudades();
            this.DataContext = ciudades;
        }
        private bool Validar()
        {
            bool esValido = true;
            if(CiudadIdTextBox.Text.Length == 0 || NombreCiudadTextBox.Text.Length == 0 || ProvinciaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese El campo faltante", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var ciudad = CiudadesBLL.Buscar(Utilidades.ToInt(CiudadIdTextBox.Text));

            if(ciudades != null)
            {
                this.ciudades = ciudad;
            }
            else
            {
                this.ciudades = new Ciudades();
            }
            this.DataContext = this.ciudades;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = CiudadesBLL.Guardar(ciudades);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Guardado Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CiudadesBLL.Eliminar(Utilidades.ToInt(CiudadIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

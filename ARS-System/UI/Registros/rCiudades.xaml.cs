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
        private static bool Mpaso = true;
        private Ciudades ciudades = new Ciudades();
        public rCiudades()
        {
            InitializeComponent();

            this.DataContext = ciudades;
            ProvinciaComboBox.ItemsSource = ProvinciasBLL.GetProvincias();
            ProvinciaComboBox.SelectedValuePath = "ProvinciaId";
            ProvinciaComboBox.DisplayMemberPath = "Nombres";
        }
        private void Limpiar()
        {
            this.ciudades = new Ciudades();
            this.DataContext = ciudades;
        }
        private bool Validar()
        {
            bool esValido = true;
            if (NombreCiudadTextBox.Text.Length == 0 || ProvinciaComboBox.SelectedIndex < 0)
            {
                esValido = false;
                if (NombreCiudadTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese un nombre de ciudad", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombreCiudadTextBox.Focus();
                }
                else if (ProvinciaComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione una provincia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    ProvinciaComboBox.Focus();
                }

            }
            return esValido;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = ciudades;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var ciudad = CiudadesBLL.Buscar(Utilidades.ToInt(CiudadIdTextBox.Text));


            if (ciudad != null)
            {
                ciudades = ciudad;
                Mpaso = false;
                Actualizar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            Mpaso = true;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            if (Mpaso)
            {
                if (CiudadesBLL.ExisteNombre(NombreCiudadTextBox.Text))
                {
                    MessageBox.Show("Esta Ciudad ya Existe", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Mpaso = true;
            }

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
            Mpaso = true;
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
            Mpaso = true;
        }
    }
}

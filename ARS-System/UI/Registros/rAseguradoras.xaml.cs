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
    /// Interaction logic for rAseguradoras.xaml
    /// </summary>
    public partial class rAseguradoras : Window
    {
        private Aseguradoras aseguradoras = new Aseguradoras();
        public rAseguradoras()
        {
            InitializeComponent();
            this.DataContext = aseguradoras;

            CiudadComboBox.ItemsSource = CiudadesBLL.GetCiudades();
            CiudadComboBox.SelectedValuePath = "CiudadId";
            CiudadComboBox.DisplayMemberPath = "Nombres";
        }

        private void Limpiar()
        {
            this.aseguradoras = new Aseguradoras();
            this.DataContext = aseguradoras;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Completa el campo que está vacio!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
                return esValido;
            }

            if (RNCTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Completa el campo que está vacio!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                RNCTextBox.Focus();
                return esValido;

            }

            if (RNCTextBox.Text.Length < 9)
            {
                esValido = false;
                MessageBox.Show("Número de RNC incompleto! Debe de tener 9 dígitos numéricos.", "Error"
                    , MessageBoxButton.OK, MessageBoxImage.Warning);
                RNCTextBox.Focus();
                return esValido;
            }

            if (DireccionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Completa el campo que está vacío!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DireccionTextBox.Focus();
                return esValido;
            }

            if (CiudadComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Selecciona una Ciudad!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CiudadComboBox.Focus();
                return esValido;
            }

            if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Completa el campo que está vacío!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();
                return esValido;
            }

            if (TelefonoTextBox.Text.Length < 10)
            {
                esValido = false;
                MessageBox.Show("Número de Teléfono incompleto! Debe de tener 10 dígitos numéricos.", "Error"
                    , MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();
                return esValido;
            }

            return esValido;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = aseguradoras;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var aseguradora = AseguradorasBLL.Buscar(Utilidades.ToInt(AseguradoraIdTextBox.Text));

            if (aseguradora != null)
            {
                aseguradoras = aseguradora;
                Actualizar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la Base de Datos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = AseguradorasBLL.Guardar(aseguradoras);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con Exito!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AseguradorasBLL.Eliminar(Utilidades.ToInt(AseguradoraIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible Eliminar!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

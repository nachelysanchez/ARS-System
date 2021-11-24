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
            if (AseguradoraIdTextBox.Text.Length == 0 || NombresTextBox.Text.Length == 0 || RNCTextBox.Text.Length == 0 || DireccionTextBox.Text.Length == 0 || TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese El campo faltante", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var aseguradora = AseguradorasBLL.Buscar(Utilidades.ToInt(AseguradoraIdTextBox.Text));

            if (aseguradora != null)
            {
                this.aseguradoras = aseguradora;
            }
            else
            {
                this.aseguradoras = new Aseguradoras();
            }
            this.DataContext = this.aseguradoras;
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
                MessageBox.Show("Guardado con exito!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Guardado Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AseguradorasBLL.Eliminar(Utilidades.ToInt(AseguradoraIdTextBox.Text)))
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

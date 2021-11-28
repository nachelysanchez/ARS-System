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
    /// Interaction logic for rAfiliados.xaml
    /// </summary>
    public partial class rAfiliados : Window
    {
        public class DateFormat : System.Windows.Data.IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null) return null;

                return ((DateTime)value).ToString("dd/MM/yyyy");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        private Afiliados afiliado = new Afiliados(); 
        public rAfiliados()
        {
            InitializeComponent();
            this.DataContext = afiliado;

            SexoComboBox.ItemsSource = SexosBLL.GetSexos();
            SexoComboBox.SelectedValuePath = "SexoId";
            SexoComboBox.DisplayMemberPath = "Nombres";

            OcupacionComboBox.ItemsSource = OcupacionesBLL.GetOcupaciones();
            OcupacionComboBox.SelectedValuePath = "OcupacionId";
            OcupacionComboBox.DisplayMemberPath = "Nombres";

            AseguradoraComboBox.ItemsSource = AseguradorasBLL.GetAseguradoras();
            AseguradoraComboBox.SelectedValuePath = "AseguradoraId";
            AseguradoraComboBox.DisplayMemberPath = "Nombres";

            CiudadComboBox.ItemsSource = CiudadesBLL.GetCiudades();
            CiudadComboBox.SelectedValuePath = "CiudadId";
            CiudadComboBox.DisplayMemberPath = "Nombres";
        }
        private void Limpiar()
        {
            this.afiliado = new Afiliados();
            this.DataContext = afiliado;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (FechaDatePicker.Text.Length == 0 || NombresTextBox.Text.Length == 0 || CedulaTextBox.Text.Length == 0
                || SexoComboBox.SelectedIndex < 0 || SexoTextBox.Text.Length == 0 || NSSTextBox.Text.Length == 0
                || TelefonoTextBox.Text.Length == 0 || CelularTextBox.Text.Length == 0 || EmailTextBox.Text.Length == 0
                || OcupacionComboBox.SelectedIndex < 0 || OcupacionTextBox.Text.Length == 0 || AseguradoraComboBox.SelectedIndex < 0
                || AseguradoraTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte el campo faltante", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void BuscarButton_Click_1(object sender, RoutedEventArgs e)
        {
            var afiliado = AfiliadosBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));
            if (afiliado != null)
                this.afiliado = afiliado;
            else
            {
                this.afiliado = new Afiliados();
                MessageBox.Show("No se ha Encontrado", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.DataContext = this.afiliado;
        }
        //SEXO
        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            afiliado.Sexo.Nombres = SexoComboBox.SelectedValuePath;
            SexoTextBox.Text = afiliado.Sexo.Nombres;
        }
        //CIUDAD
        private void Agregar1Button_Click(object sender, RoutedEventArgs e)
        {
            if (CiudadComboBox.SelectedIndex >= 0)
            {
                afiliado.Ciudad.Nombres = CiudadComboBox.SelectedValuePath;
                CiudadTextBox.Text = afiliado.Ciudad.Nombres;
            }
            else
            {
                MessageBox.Show("Debe de elegir una opción de la lista desplegable de Ciudades");
            }
            
        }
        //OCUPACION
        private void Agregar2Button_Click(object sender, RoutedEventArgs e)
        {
            afiliado.Ocupacion.Nombre = OcupacionComboBox.SelectedValuePath;
            OcupacionTextBox.Text = afiliado.Ocupacion.Nombre;
        }
        //Aseguradora
        private void Agregar3Button_Click(object sender, RoutedEventArgs e)
        {
            afiliado.Aseguradora.Nombres = AseguradoraComboBox.SelectedValuePath;
            AseguradoraTextBox.Text = afiliado.Aseguradora.Nombres;
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            if (AfiliadosBLL.ExisteNombre(NombresTextBox.Text))
            {
                MessageBox.Show("Ya existe este afiliado. Ingrese otro", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var paso = AfiliadosBLL.Guardar(this.afiliado);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AfiliadosBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))
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

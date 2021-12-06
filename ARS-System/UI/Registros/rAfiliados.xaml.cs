using ARS_System.BLL;
using ARS_System.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static bool verifica = true;
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

        private bool VerificarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
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
            OcupacionComboBox.DisplayMemberPath = "Nombre";

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

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
            }
            else if (FechaDatePicker.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione una fecha", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                FechaDatePicker.Focus();
            }
            else if (CedulaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese la cedula", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                CedulaTextBox.Focus();
            }
            else if (SexoComboBox.SelectedIndex < 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione el sexo", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                SexoComboBox.Focus();
            }
            else if (NSSTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el NSS", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                NSSTextBox.Focus();
            }
            else if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el telefono", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();
            }
            else if (CelularTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el celular", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                CelularTextBox.Focus();
            }
            else if (EmailTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el email", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
            }
            else if (OcupacionComboBox.SelectedIndex < 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione la Ocupacion", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                OcupacionComboBox.Focus();
            }
            else if (AseguradoraComboBox.SelectedIndex < 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione la Aseguradora", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                AseguradoraComboBox.Focus();
            }

            if (!(VerificarEmail(EmailTextBox.Text)))
            {
                esValido = false;
                MessageBox.Show("El email fue introducido de manera erronea. Recuerda que el email lleva un @", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
            }

            return esValido;
        }
        private void BuscarButton_Click_1(object sender, RoutedEventArgs e)
        {
            verifica = false;

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
        
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            verifica = true;
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            if (verifica)
            {
                if (AfiliadosBLL.ExisteNombre(NombresTextBox.Text))
                {
                    MessageBox.Show("Ya existe este afiliado. Ingrese otro", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                verifica = true;
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
            verifica = true;
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
            verifica = true;
        }

        
    }
}

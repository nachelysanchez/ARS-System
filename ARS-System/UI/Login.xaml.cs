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

namespace ARS_System.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Usuarios usuarios = new Usuarios();

        MainWindow Principal = new MainWindow();
        public Login()
        {
            InitializeComponent();
        }
        private bool Validar()
        {
            bool esValido = true;
            if (NombreUsuarioTextBox.Text.Length == 0 || ContrasenaPasswordBox.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("No puede Ddejar campos vacios", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = LoginBLL.Validar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

            if (!Validar())
                return;

            if (paso)
            {
                this.Close();
                Principal.Show();
            }
            else
            {
                MessageBox.Show("Nombre Usuario o Contraseña incorrecta!", "Error!");
                ContrasenaPasswordBox.Clear();
                NombreUsuarioTextBox.Focus();
            }
        }
        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

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
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {

        private Roles rol = new Roles();
        private static bool sigte = true;
        public rRoles()
        {
            InitializeComponent();

            this.DataContext = rol;
        }

        private void Limpiar()
        {
            this.rol = new Roles();

            this.DataContext = rol;
        }
        private bool Validar()
        {

            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;

                MessageBox.Show("Completa el campo de Nombre!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextBox.Focus();
            }
            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var roles = RolesBLL.Buscar(Utilidades.ToInt(RolIdTextBox.Text));

            if (roles != null)
                this.rol = roles;

            else
            {
                this.rol = new Roles();

                MessageBox.Show("No se ha Encontrado!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            sigte = false;
            this.DataContext = this.rol;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            sigte = true;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            if(sigte)
            {
                if(RolesBLL.ExisteNombre(NombreTextBox.Text))
                {
                    MessageBox.Show("Este Rol ya Existe!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                sigte = true;
            }
            var paso = RolesBLL.Guardar(this.rol);

            if (paso)
            {
                Limpiar();

                MessageBox.Show("Se ha guardado el Rol!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se guardó el Rol!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            sigte = true;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Utilidades.ToInt(RolIdTextBox.Text)))
            {
                Limpiar();

                MessageBox.Show("Rol Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible Eliminar!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            sigte = true;
        }
    }
}

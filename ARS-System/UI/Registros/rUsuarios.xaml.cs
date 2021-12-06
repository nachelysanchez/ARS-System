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
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Usuarios usuarios = new Usuarios();
        private UsuariosDetalle UsuariosDetalle = new UsuariosDetalle();
        private static bool MPaso = true;
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;

            RolComboBox.ItemsSource = RolesBLL.GetRoles();
            RolComboBox.SelectedValuePath = "RolId";
            RolComboBox.DisplayMemberPath = "Nombre";

            PermisoComboBox.ItemsSource = PermisosBLL.GetPermisos();
            PermisoComboBox.SelectedValuePath = "PermisoId";
            PermisoComboBox.DisplayMemberPath = "Nombre";
        }

        private void Limpiar()
        {
            usuarios = new Usuarios();
            ContraseniaPasswordBox.Password = string.Empty;
            ConfirmarContraseniaPasswordBox.Password = string.Empty;
            this.DataContext = usuarios;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0 || UsernameTextBox.Text.Length == 0 ||
                ContraseniaPasswordBox.Password.Length == 0 || ConfirmarContraseniaPasswordBox.Password.Length == 0)
            {
                esValido = false;

                GuardarButton.IsEnabled = false;
                if (NombresTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese su nombre", "Fallo",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombresTextBox.Focus();
                }
                else if (UsernameTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese un username", "Fallo",
                       MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsernameTextBox.Focus();
                }
                else if (ContraseniaPasswordBox.Password.Length == 0)
                {
                    MessageBox.Show("Ingrese Una contraseña", "Fallo",
                       MessageBoxButton.OK, MessageBoxImage.Warning);
                    ContraseniaPasswordBox.Focus();
                }
                else if (RolComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione un Rol", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Warning);
                    RolComboBox.Focus();
                }
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarContraseniaPasswordBox.Password != ContraseniaPasswordBox.Password)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Las contraseñas no coiciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarContraseniaPasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            return esValido;
        }
        private bool ValidarDetalle()
        {
            bool esValido = true;

            if (ObservacionTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Ingrese Una observacion", "Fallo",
                      MessageBoxButton.OK, MessageBoxImage.Warning);
                GuardarButton.IsEnabled = true;
            }

            return esValido;
        }
        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = usuarios;
        }
        private bool ExisteenBD()
        {
            Usuarios esValido = UsuariosBLL.Buscar(usuarios.UsuarioId);
            return (esValido != null);
        }
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarDetalle())
                return;
            usuarios.DetalleUsuario.Add(new UsuariosDetalle(Utilidades.ToInt(UsuarioIdTextBox.Text), (int)PermisoComboBox.SelectedValue,
                ObservacionTextBox.Text, (Permisos)PermisoComboBox.SelectedItem));

        
            Actualizar();
        }
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarDetalle())
                return;
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                usuarios.DetalleUsuario.RemoveAt(DetalleDataGrid.SelectedIndex);
                Actualizar();
            }
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var usuario = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIdTextBox.Text));

            if (usuario != null)
            {
                usuarios = usuario;
                MPaso = false;
                Actualizar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            MPaso = true;
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (!Validar())
                return;
            if (MPaso)
            {
                if (UsuariosBLL.ExisteUsername(UsernameTextBox.Text))
                {
                    MessageBox.Show("Este Username ya Existe", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                MPaso = true;
            }
            if (usuarios.UsuarioId == 0)
            {
                paso = UsuariosBLL.Guardar(usuarios);
            }
            else
            {
                if (ExisteenBD())
                {
                    paso = UsuariosBLL.Guardar(usuarios);

                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "Error");
                }

                
            }
            if (paso)
            {
                
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Transaccion Fallida", "Fallo",
                   MessageBoxButton.OK, MessageBoxImage.Error);
                Limpiar();
            }
            MPaso = true;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Utilidades.ToInt(UsuarioIdTextBox.Text)))
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

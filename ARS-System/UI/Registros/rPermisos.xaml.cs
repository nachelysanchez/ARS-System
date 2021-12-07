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
    /// Interaction logic for rPermisos.xaml
    /// </summary>
    public partial class rPermisos : Window
    {
        private Permisos permisos = new Permisos();
        private static bool Mpaso = true;
        public rPermisos()
        {
            InitializeComponent();
            this.DataContext = permisos;
        }

        private void Limpiar()
        {
            this.permisos = new Permisos();
            this.DataContext = permisos;
        }
        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = permisos;
        }
        private bool Validar()
        {
            bool esValido = true;
            if (NombrePermisoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese un nombre ", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var permiso = PermisosBLL.Buscar(Utilidades.ToInt(PermisoIdTextBox.Text));

            if (permiso != null)
            {
                permisos = permiso;
                Mpaso = false;
                Actualizar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Mpaso = true;
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
                if (PermisosBLL.ExisteNombre(NombrePermisoTextBox.Text))
                {
                    MessageBox.Show("Este Permiso ya Existe", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Mpaso = true;
            }
            var paso = PermisosBLL.Guardar(permisos);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con exito!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Guardado Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            Mpaso = true;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PermisosBLL.Eliminar(Utilidades.ToInt(PermisoIdTextBox.Text)))
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

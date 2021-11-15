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
    /// Interaction logic for rEspecialidades.xaml
    /// </summary>
    public partial class rEspecialidades : Window
    {
        private Especialidades especialidad = new Especialidades();
        public rEspecialidades()
        {
            InitializeComponent();
            this.DataContext = especialidad;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = especialidad;
        }

        private void Limpiar()
        {
            this.especialidad = new Especialidades();
            this.DataContext = especialidad;
        }

        private bool Validar()
        {
            bool esValido = true;
            if (NombreEspecialidadTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe de completar el campo Nombre de Especialidad", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreEspecialidadTextBox.Focus();
            }
            return esValido;
        }

        private void BuscarButton_Click_1(object sender, RoutedEventArgs e)
        {
            var especialidad = EspecialidadesBLL.Buscar(Utilidades.ToInt(EspecialidadIdTextBox.Text));
            if (especialidad != null)
            {
                this.especialidad = especialidad;
            }
            else
            {
                this.especialidad = new Especialidades();
                MessageBox.Show("No se ha encontrado la Especialidad", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.DataContext = this.especialidad;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            if (EspecialidadesBLL.ExisteNombre(NombreEspecialidadTextBox.Text))
            {
                MessageBox.Show("Ya existe esta especialidad. Ingrese otra", "Informacion",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var paso = EspecialidadesBLL.Guardar(this.especialidad);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("La especialidad se guardó correctamente", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("La especialidad no se guardó", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EspecialidadesBLL.Eliminar(Utilidades.ToInt(EspecialidadIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Especialidad eliminada", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("La especialidad no se logró eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

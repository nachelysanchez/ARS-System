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
    /// Interaction logic for rDiagnosticos.xaml
    /// </summary>
    public partial class rDiagnosticos : Window
    {
        private Diagnosticos diagnostico = new Diagnosticos();
        public rDiagnosticos()
        {
            InitializeComponent();
            this.DataContext = diagnostico;
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = diagnostico;
        }
        private void Limpiar()
        {
            this.diagnostico = new Diagnosticos();
            this.DataContext = diagnostico;
        }
        private bool Validar()
        {
            bool esValido = true;
            if (NombreDiagnosticoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe de completar el campo Nombre de Diagnóstico", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreDiagnosticoTextBox.Focus();
            }
                
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var diagnostico = DiagnosticosBLL.Buscar(Utilidades.ToInt(DiagnosticoIdTextBox.Text));
            if (diagnostico != null)
            {
                this.diagnostico = diagnostico;
            }
            else
            {
                this.diagnostico = new Diagnosticos();
                MessageBox.Show("No se ha encontrado el Diagnostico", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.DataContext = this.diagnostico;
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
            if (DiagnosticosBLL.ExisteNombre(NombreDiagnosticoTextBox.Text))
            {
                MessageBox.Show("Ya existe este diagnóstico. Ingrese otra", "Informacion",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var paso = DiagnosticosBLL.Guardar(this.diagnostico);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("El diagnóstico se guardó correctamente", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("El diagnóstico no se guardó", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DiagnosticosBLL.Eliminar(Utilidades.ToInt(DiagnosticoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Diagnóstico eliminada", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("El diagnóstico no se logró eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

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
    /// Interaction logic for rDoctores.xaml
    /// </summary>
    public partial class rDoctores : Window
    {
        private Doctores doctores = new Doctores();

        private DoctoresDetalle DoctoresDetalle = new DoctoresDetalle();
        public rDoctores()
        {
            InitializeComponent();

            this.DataContext = doctores;

            CiudadComboBox.ItemsSource = CiudadesBLL.GetCiudades();
            CiudadComboBox.SelectedValuePath = "CiudadId";
            CiudadComboBox.DisplayMemberPath = "Nombres";

            EspecialidadComboBox.ItemsSource = EspecialidadesBLL.GetEspecialidades();
            EspecialidadComboBox.SelectedValuePath = "EspecialidadId";
            EspecialidadComboBox.DisplayMemberPath = "Nombres";
        }

        private void Limpiar()
        {
            doctores = new Doctores();
            this.DataContext = doctores;
        }

        private bool ExisteenBD()
        {
            Doctores esValido = DoctoresBLL.Buscar(doctores.DoctorId);
            return (esValido != null);
        }
        private bool Validar()
        {
            bool esValido = true;

            if (DoctorIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Completa el campo que está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DoctorIdTextBox.Focus();
                return esValido;
            }

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Completa el campo que está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextBox.Focus();
                return esValido;
            }

            if (CelularTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Completa el campo que está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CelularTextBox.Focus();
                return esValido;
            }

            if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Completa el campo que está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();
                return esValido;
            }

            if (DireccionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Completa el campo que está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DireccionTextBox.Focus();
                return esValido;
            }

            if (CiudadComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione una ciudad", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CiudadComboBox.Focus();
                return esValido;

            }

            if (ExequaturTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Completa el campo que está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ExequaturTextBox.Focus();
                return esValido;

            }

            return esValido;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = doctores;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DoctorIdTextBox.Text.Length == 0 || Utilidades.ToInt(DoctorIdTextBox.Text) == 0)
            {
                MessageBox.Show("Transaccion fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var doctor = DoctoresBLL.Buscar(doctores.DoctorId);

            if (doctor != null)
            {
                doctores = doctor;
                Actualizar();
            }

            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            this.DataContext = this.doctores;
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            doctores.Detalle.Add(new DoctoresDetalle(Utilidades.ToInt(DoctorIdTextBox.Text), (int)EspecialidadComboBox.SelectedValue,
                ObservacionTextBox.Text, (Especialidades)EspecialidadComboBox.SelectedItem));
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                doctores.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Actualizar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (!Validar())
                return;

            if (doctores.DoctorId == 0)
            {
                paso = DoctoresBLL.Guardar(doctores);
            }
            else
            {
                if (ExisteenBD())
                {
                    paso = DoctoresBLL.Guardar(doctores);

                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "Error");
                }
            }

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
            if (DoctoresBLL.Eliminar(Utilidades.ToInt(DoctorIdTextBox.Text)))
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

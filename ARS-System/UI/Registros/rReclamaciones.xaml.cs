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
    /// Interaction logic for rReclamaciones.xaml
    /// </summary>
    public partial class rReclamaciones : Window
    {
        private Reclamaciones reclamacion = new Reclamaciones();
        public rReclamaciones()
        {
            InitializeComponent();
            this.DataContext = reclamacion;

            DoctorComboBox.ItemsSource = DoctoresBLL.GetDoctores();
            DoctorComboBox.SelectedValuePath = "DoctorId";
            DoctorComboBox.DisplayMemberPath = "Nombres";

            AfiliadoComboBox.ItemsSource = AfiliadosBLL.GetAfiliados();
            AfiliadoComboBox.SelectedValuePath = "AfiliadoId";
            AfiliadoComboBox.DisplayMemberPath = "Nombres";

            ServicioComboBox.ItemsSource = ServiciosBLL.GetServicios();
            ServicioComboBox.SelectedValuePath = "ServicioId";
            ServicioComboBox.DisplayMemberPath = "Descripcion";

        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = reclamacion;
        }
        private void Limpiar()
        {
            this.reclamacion = new Reclamaciones();
            this.DataContext = reclamacion;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Reclamaciones esValido = ReclamacionesBLL.Buscar(reclamacion.ReclamacionId);

            return (esValido != null);
        }
        private bool Validar()
        {
            bool esValido = true;

            if (Utilidades.ToInt(NoAutorizacionTextBox.Text) == 0)
            {
                esValido = false;
                MessageBox.Show("Complete el numero de autorización", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NoAutorizacionTextBox.Focus();
            }
            else if (Utilidades.ToInt(NAFTextBox.Text) == 0)
            {
                esValido = false;
                MessageBox.Show("Complete el NAF", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NAFTextBox.Focus();
            }
            else if (DoctorComboBox.SelectedIndex < 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione un doctor", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DoctorComboBox.Focus();
            }
            else if (AfiliadoComboBox.SelectedIndex < 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione un afiliado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NoAutorizacionTextBox.Focus();
            }

            return esValido;
        }

        private bool ValidarDetalle()
        {
            bool esValido = true;

            if (ServicioComboBox.SelectedIndex < 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione un Servicio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ServicioComboBox.Focus();
            }
            else if (NoProcedeTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Complete el No Procede", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NoProcedeTextBox.Focus();
            }
            else if (ValorTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Complete el Monto", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ValorTextBox.Focus();
            }
            else if (ValorRTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Complete el Valor Reclamado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ValorRTextBox.Focus();
            }
            else if (CopagoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Complete el CoPago", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CopagoTextBox.Focus();
            }

            return esValido;
        }
        private void BuscarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Reclamaciones encontrado = ReclamacionesBLL.Buscar(reclamacion.ReclamacionId);

            if (encontrado != null)
            {
                reclamacion = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("La reclamación no existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarDetalle())
            {
                return;
            }
            float total = 0;
            reclamacion.RDetalle.Add(new ReclamacionesDetalle(Utilidades.ToInt(IdTextBox.Text), (int)ServicioComboBox.SelectedValue, (int)AfiliadoComboBox.SelectedValue,
                Utilidades.ToFloat(ValorTextBox.Text), Utilidades.ToFloat(NoProcedeTextBox.Text),
                Utilidades.ToFloat(ValorRTextBox.Text), Utilidades.ToFloat(CopagoTextBox.Text), (Servicios)ServicioComboBox.SelectedItem,
                (Afiliados)AfiliadoComboBox.SelectedItem));

            total += Utilidades.ToFloat(ValorRTextBox.Text);
            TotalTextBox.Text = total.ToString();

            ValorRTextBox.Text = string.Empty;
            ValorTextBox.Text = string.Empty;
            CopagoTextBox.Text = string.Empty;
            NoProcedeTextBox.Text = string.Empty;

            Cargar();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Debe de elegir alguna fila del detalle para poder removerla", "Observación",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                reclamacion.RDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                reclamacion.Total -= Utilidades.ToFloat(TotalTextBox.Text);
                Cargar();
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

            if (reclamacion.ReclamacionId == 0)
            {
                paso = ReclamacionesBLL.Guardar(reclamacion);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = ReclamacionesBLL.Guardar(reclamacion);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "Error");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("¡Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("¡Fallo al guardar!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Reclamaciones existe = ReclamacionesBLL.Buscar(reclamacion.ReclamacionId);

            if (existe == null)
            {
                MessageBox.Show("No existe la reclamación en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                ReclamacionesBLL.Eliminar(reclamacion.ReclamacionId);
                MessageBox.Show("¡Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }

        
    }
}

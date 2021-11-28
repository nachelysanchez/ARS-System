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

namespace ARS_System.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cAfiliados.xaml
    /// </summary>
    public partial class cAfiliados : Window
    {
        public cAfiliados()
        {
            InitializeComponent();
        }
        private void BuscarButton_Click_2(object sender, RoutedEventArgs e)
        {
            var listado = new List<Afiliados>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Id
                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker != null)
                        {
                            listado = ProyectosBLL.GetList(x => x.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text)
                            && x.Fecha.Date <= HastaDatePicker.SelectedDate && x.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(x => x.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text)
                            && x.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(x => x.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text)
                            && x.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProyectosBLL.GetList(e => e.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        break;
                    case 1: //Descripcion
                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker != null)
                        {
                            listado = ProyectosBLL.GetList(x => x.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower())
                            && x.Fecha.Date <= HastaDatePicker.SelectedDate && x.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(x => x.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower())
                            && x.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(x => x.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower())
                            && x.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProyectosBLL.GetList(x => x.DescripcionProyecto.Contains(CriterioTextBox.Text.ToLower()));
                        }
                        break;
                    case 2: //Total de Minutos
                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker != null)
                        {
                            listado = ProyectosBLL.GetList(x => x.Total == Utilidades.ToInt(CriterioTextBox.Text)
                            && x.Fecha.Date <= HastaDatePicker.SelectedDate && x.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(x => x.Total == Utilidades.ToInt(CriterioTextBox.Text)
                            && x.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProyectosBLL.GetList(x => x.Total == Utilidades.ToInt(CriterioTextBox.Text)
                            && x.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProyectosBLL.GetList(x => x.Total == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        break;
                }
            }
            else
            {
                listado = ProyectosBLL.GetList(e => true);
            }

            if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0)
            {
                listado = ProyectosBLL.GetList(x => x.Fecha.Date >= DesdeDatePicker.SelectedDate &&
                x.Fecha.Date <= HastaDatePicker.SelectedDate);
            }

            if (HastaDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0)
            {
                listado = ProyectosBLL.GetList(x => x.Fecha.Date >= DesdeDatePicker.SelectedDate &&
                x.Fecha.Date <= HastaDatePicker.SelectedDate);
            }

            if (DesdeDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0)
            {
                listado = ProyectosBLL.GetList(x => x.Fecha.Date >= DesdeDatePicker.SelectedDate);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

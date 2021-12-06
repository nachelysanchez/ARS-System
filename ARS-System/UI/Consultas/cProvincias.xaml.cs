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

namespace ARS_System.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cProvincias.xaml
    /// </summary>
    public partial class cProvincias : Window
    {
        public cProvincias()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Provincias>();



            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProvinciasBLL.GetList(e => e.ProvinciaId == Utilidades.ToInt(CriterioTextBox.Text)
                            && e.Fecha.Date <= HastaDatePicker.SelectedDate && e.Fecha.Date >= DesdeDatePicker.SelectedDate);


                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProvinciasBLL.GetList(e => e.ProvinciaId == Utilidades.ToInt(CriterioTextBox.Text)
                           && e.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProvinciasBLL.GetList(e => e.ProvinciaId == Utilidades.ToInt(CriterioTextBox.Text)
                           && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProvinciasBLL.GetList(e => e.ProvinciaId == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        break;
                    case 1:
                        if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProvinciasBLL.GetList(e => e.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower())
                            && e.Fecha.Date <= HastaDatePicker.SelectedDate && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else if (HastaDatePicker.SelectedDate != null)
                        {
                            listado = ProvinciasBLL.GetList(e => e.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower())
                             && e.Fecha.Date <= HastaDatePicker.SelectedDate);
                        }
                        else if (DesdeDatePicker.SelectedDate != null)
                        {
                            listado = ProvinciasBLL.GetList(e => e.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower())
                            && e.Fecha.Date >= DesdeDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = ProvinciasBLL.GetList(e => e.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        break;
                }
            }
            else
            {
                listado = ProvinciasBLL.GetList(e => true);
            }
            if (DesdeDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0)
            {
                listado = ProvinciasBLL.GetList(e => e.Fecha.Date >= DesdeDatePicker.SelectedDate);
            }
            if (HastaDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0)
            {
                listado = ProvinciasBLL.GetList(e => e.Fecha.Date <= HastaDatePicker.SelectedDate);
            }
            if ((DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0))
            {
                listado = ProvinciasBLL.GetList(e => e.Fecha.Date >= DesdeDatePicker.SelectedDate && e.Fecha.Date <= HastaDatePicker.SelectedDate);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

using ARS_System.BLL;
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
    /// Interaction logic for cReclamaciones.xaml
    /// </summary>
    public partial class cReclamaciones : Window
    {
        public cReclamaciones()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click_3(object sender, RoutedEventArgs e)
        {
            var listado = new List<object>();
            string criterio = CriterioTextBox.Text.Trim();

            DateTime? desde = DesdeDatePicker.SelectedDate;
            DateTime? hasta = HastaDatePicker.SelectedDate;

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Id
                        listado = ReclamacionesBLL.GetList("ReclamacionId", criterio, desde, hasta);
                        break;
                    case 1: //NoAutorizacion
                        listado = ReclamacionesBLL.GetList("NoAutorizacion", criterio, desde, hasta);
                        break;
                    case 2: //NAF
                        listado = ReclamacionesBLL.GetList("NAF", criterio, desde, hasta);
                        break;
                    case 3: //Doctor
                        listado = ReclamacionesBLL.GetList("Doctor", criterio, desde, hasta);
                        break;
                    case 4: //Afiliado
                        listado = ReclamacionesBLL.GetList("Afiliado", criterio, desde, hasta);
                        break;
                    case 5: //Prestador
                        listado = ReclamacionesBLL.GetList("Prestador", criterio, desde, hasta);
                        break;
                    case 6: //Total
                        listado = ReclamacionesBLL.GetList("Total", criterio, desde, hasta);
                        break;
                }
            }
            else
            {
                listado = ReclamacionesBLL.GetList("", "", desde, hasta);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

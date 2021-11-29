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
using ARS_System.BLL;
using ARS_System.Entidades;

namespace ARS_System.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cCiudades.xaml
    /// </summary>
    public partial class cCiudades : Window
    {
        public cCiudades()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<object>();
            string criterio = CriterioTextBox.Text.Trim();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = CiudadesBLL.GetList("", "");
                        break;
                    case 1:
                        listado = CiudadesBLL.GetList("CiudadId", criterio);
                        break;
                    case 2:
                        listado = CiudadesBLL.GetList("Nombres", criterio);
                        break;
                    case 3:
                        listado = CiudadesBLL.GetList("Provincia", criterio);
                        break;
                }
            }
            else
            {
                listado = CiudadesBLL.GetList("", "");
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

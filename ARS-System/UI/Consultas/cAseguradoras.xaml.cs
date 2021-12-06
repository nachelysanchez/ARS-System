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
    /// Interaction logic for cAseguradoras.xaml
    /// </summary>
    public partial class cAseguradoras : Window
    {
        public cAseguradoras()
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
                        listado = AseguradorasBLL.GetList("AseguradoraId", criterio);
                        break;
                    case 1:
                        listado = AseguradorasBLL.GetList("Nombres", criterio);
                        break;
                    case 2:
                        listado = AseguradorasBLL.GetList("RNC", criterio);
                        break;
                    case 3:
                        listado = AseguradorasBLL.GetList("Direccion", criterio);
                        break;
                    case 4:
                        listado = AseguradorasBLL.GetList("Telefono", criterio);
                        break;
                    case 5:
                        listado = DoctoresBLL.GetList("Ciudad", criterio);
                        break;
                }
            }
            else
            {
                listado = AseguradorasBLL.GetList("", "");
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

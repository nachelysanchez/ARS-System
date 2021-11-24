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
            var listado = new List<Aseguradoras>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = AseguradorasBLL.GetAseguradoras();
                        break;
                    case 1:
                        listado = AseguradorasBLL.GetList(e => e.AseguradoraId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 2:
                        listado = AseguradorasBLL.GetList(e => e.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 3:
                        listado = AseguradorasBLL.GetList(e => e.RNC.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 4:
                        listado = AseguradorasBLL.GetList(e => e.Direccion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 5:
                        listado = AseguradorasBLL.GetList(e => e.CiudadId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 6:
                        listado = AseguradorasBLL.GetList(e => e.Telefono.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = AseguradorasBLL.GetList(e => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

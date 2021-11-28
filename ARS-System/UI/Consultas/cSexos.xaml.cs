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
    /// Interaction logic for cSexos.xaml
    /// </summary>
    public partial class cSexos : Window
    {
        public cSexos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click_3(object sender, RoutedEventArgs e)
        {
            var listado = new List<Sexos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = SexosBLL.GetSexos();
                        break;
                    case 1:
                        listado = SexosBLL.GetList(e => e.SexoId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 2:
                        listado = SexosBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = SexosBLL.GetList(e => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

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
    /// Interaction logic for cDiagnosticos.xaml
    /// </summary>
    public partial class cDiagnosticos : Window
    {
        public cDiagnosticos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Diagnosticos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Listado
                        listado = DiagnosticosBLL.GetDiagnosticos();
                        break;
                    case 1: //Id
                        listado = DiagnosticosBLL.GetList(e => e.DiagnosticoId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 2: //Nombre
                        listado = DiagnosticosBLL.GetList(e => e.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = DiagnosticosBLL.GetList(e => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

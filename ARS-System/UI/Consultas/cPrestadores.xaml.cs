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
    /// Interaction logic for cPrestadores.xaml
    /// </summary>
    public partial class cPrestadores : Window
    {
        public cPrestadores()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Prestadores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Listado
                        listado = PrestadoresBLL.GetPrestadores();
                        break;
                    case 1: //Id
                        listado = PrestadoresBLL.GetList(e => e.PrestadorId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 2: //Nombre
                        listado = PrestadoresBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 3: //RNC
                        listado = PrestadoresBLL.GetList(e => e.RNC.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 4: //Direccion
                        listado = PrestadoresBLL.GetList(e => e.Direccion.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 5: //Ciudad
                        listado = PrestadoresBLL.GetList(e => e.Ciudad.Nombres.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 6: //Telefono
                        listado = PrestadoresBLL.GetList(e => e.Telefono.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = PrestadoresBLL.GetList(e => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

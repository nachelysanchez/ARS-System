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
    /// Interaction logic for cPermisos.xaml
    /// </summary>
    public partial class cPermisos : Window
    {
        public cPermisos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Permisos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = PermisosBLL.GetPermisos();
                        break;
                    case 1:
                        listado = PermisosBLL.GetList(e => e.PermisoId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 2:
                        listado = PermisosBLL.GetList(e => e.Nombre.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = PermisosBLL.GetList(e => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

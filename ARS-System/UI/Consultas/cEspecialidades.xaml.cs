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
    /// Interaction logic for cEspecialidades.xaml
    /// </summary>
    public partial class cEspecialidades : Window
    {
        public cEspecialidades()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Especialidades>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Listado
                        listado = EspecialidadesBLL.GetEspecialidades();
                        break;
                    case 1: //Id
                        listado = EspecialidadesBLL.GetList(e => e.EspecialidadId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 2:
                        listado = EspecialidadesBLL.GetList(e => e.NombreEspecialidad.Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = EspecialidadesBLL.GetList(e => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

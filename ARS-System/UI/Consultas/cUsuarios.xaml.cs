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
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public Roles rol = new Roles();
        public cUsuarios()
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
                        listado = UsuariosBLL.GetList("", "");
                        break;
                    case 1:
                        listado = UsuariosBLL.GetList("UsuarioId", criterio);
                        break;
                    case 2:
                        listado = UsuariosBLL.GetList("Nombres", criterio);
                        break;
                    case 3:
                        listado = UsuariosBLL.GetList("Username", criterio);
                        break;
                    case 4:
                        listado = UsuariosBLL.GetList("Role", criterio);
                        break;

                }
            }
            else
            {
                listado = UsuariosBLL.GetList("", "");
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

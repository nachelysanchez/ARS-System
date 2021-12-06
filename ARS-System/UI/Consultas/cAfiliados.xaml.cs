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
    /// Interaction logic for cAfiliados.xaml
    /// </summary>
    public partial class cAfiliados : Window
    {
        public cAfiliados()
        {
            InitializeComponent();
        }
        private void BuscarButton_Click_2(object sender, RoutedEventArgs e)
        {
            var listado = new List<object>();
            string criterio = CriterioTextBox.Text.Trim();

            DateTime? nacimiento = FechaDatePicker.SelectedDate;
            

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Id
                        listado = AfiliadosBLL.GetList("AfiliadoId", criterio, nacimiento);
                        break;
                    case 1: //Nombres
                        listado = AfiliadosBLL.GetList("Nombres", criterio, nacimiento);
                        break;
                    case 2: //Cedula
                        listado = AfiliadosBLL.GetList("Cedula", criterio, nacimiento);
                        break;
                    case 3: //Sexo
                        listado = AfiliadosBLL.GetList("Sexo", criterio, nacimiento);
                        break;
                    case 4: //NSS
                        listado = AfiliadosBLL.GetList("NSS", criterio, nacimiento);
                        break;
                    case 5: //Telefono
                        listado = AfiliadosBLL.GetList("Telefono", criterio, nacimiento);
                        break;
                    case 6: //Celular
                        listado = AfiliadosBLL.GetList("Celular", criterio, nacimiento);
                        break;
                    case 7: //Email
                        listado = AfiliadosBLL.GetList("Email", criterio, nacimiento);
                        break;
                    case 8: //Direccion
                        listado = AfiliadosBLL.GetList("Direccion", criterio, nacimiento);
                        break;
                    case 9: //Ciudad
                        listado = AfiliadosBLL.GetList("Ciudad", criterio, nacimiento);
                        break;
                    case 10: //Aseguradora
                        listado = AfiliadosBLL.GetList("Aseguradora", criterio, nacimiento);
                        break;
                    case 11: //Ocupacion
                        listado = AfiliadosBLL.GetList("Ocupacion", criterio, nacimiento);
                        break;
                    case 12: //Valor Reclamado
                        listado = AfiliadosBLL.GetList("ValorReclamado", criterio, nacimiento);
                        break;
                }
            }
            else
            {
                listado = AfiliadosBLL.GetList("", "", nacimiento);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

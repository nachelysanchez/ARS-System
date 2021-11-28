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
            var listado = new List<Afiliados>();
            //< ComboBoxItem Content = "Afiliado Id" />
 
            //             < ComboBoxItem Content = "Nombre" />
  
            //              < ComboBoxItem Content = "Cedula" />
   
            //               < ComboBoxItem Content = "Sexo" />
    
            //                < ComboBoxItem Content = "NSS" />
     
            //                 < ComboBoxItem Content = "Teléfono" />
      
            //                  < ComboBoxItem Content = "Celular" />
       
            //                   < ComboBoxItem Content = "Email" />
        
            //                    < ComboBoxItem Content = "Dirección" />
         
            //                     < ComboBoxItem Content = "Ciudad" />
          
            //                      < ComboBoxItem Content = "Aseguradora" />
           
            //                       < ComboBoxItem Content = "Ocupación" />
            
            //                        < ComboBoxItem Content = "Valor Reclamado" />

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Id
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.AfiliadoId == Utilidades.ToInt(CriterioTextBox.Text)
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.AfiliadoId == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        break;
                    case 1: //Nombres
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.Nombres.Contains(CriterioTextBox.Text.ToUpper())
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.Nombres.Contains(CriterioTextBox.Text.ToUpper()));
                        }
                        break;
                    case 2: //Sexo
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.Sexo.Nombres.Contains(CriterioTextBox.Text.ToUpper())
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.Sexo.Nombres.Contains(CriterioTextBox.Text.ToUpper()));
                        }
                        break;
                    case 3: //NSS
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.NSS ==  Utilidades.ToInt(CriterioTextBox.Text)
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.NSS == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        break;
                    case 4: //Telefono
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.Telefono.Contains(CriterioTextBox.Text.ToUpper())
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.Telefono.Contains(CriterioTextBox.Text.ToUpper()));
                        }
                        break;
                    case 5: //Celular
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.Celular.Contains(CriterioTextBox.Text.ToUpper())
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.Celular.Contains(CriterioTextBox.Text.ToUpper()));
                        }
                        break;
                    case 6: //Email
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.Email.Contains(CriterioTextBox.Text.ToUpper())
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.Email.Contains(CriterioTextBox.Text.ToUpper()));
                        }
                        break;
                    case 7: //Direccion
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.Direccion.Contains(CriterioTextBox.Text.ToUpper())
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.Direccion.Contains(CriterioTextBox.Text.ToUpper()));
                        }
                        break;
                    case 8: //Ciudad
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.Ciudad.Nombres.Contains(CriterioTextBox.Text.ToUpper())
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.Ciudad.Nombres.Contains(CriterioTextBox.Text.ToUpper()));
                        }
                        break;
                    case 9: //Aseguradora
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.Aseguradora.Nombres.Contains(CriterioTextBox.Text.ToUpper())
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.Aseguradora.Nombres.Contains(CriterioTextBox.Text.ToUpper()));
                        }
                        break;
                    case 10: //Ocupacion
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.Ocupacion.Nombre.Contains(CriterioTextBox.Text.ToUpper())
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.Ocupacion.Nombre.Contains(CriterioTextBox.Text.ToUpper()));
                        }
                        break;
                    case 11: //Valor Reclamado
                        if (FechaDatePicker.SelectedDate != null)
                        {
                            listado = AfiliadosBLL.GetList(x => x.ValorReclamado == Utilidades.ToFloat(CriterioTextBox.Text)
                            && x.FechaNacimiento == FechaDatePicker.SelectedDate);
                        }
                        else
                        {
                            listado = AfiliadosBLL.GetList(x => x.ValorReclamado == Utilidades.ToFloat(CriterioTextBox.Text));
                        }
                        break;
                }
            }
            else
            {
                listado = AfiliadosBLL.GetList(e => true);
            }

            if (FechaDatePicker.SelectedDate != null && FiltroComboBox.SelectedIndex < 0)
            {
                listado = AfiliadosBLL.GetList(x => x.FechaNacimiento >= FechaDatePicker.SelectedDate);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

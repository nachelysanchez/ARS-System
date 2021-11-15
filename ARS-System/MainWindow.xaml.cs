using ARS_System.UI.Consultas;
using ARS_System.UI.Registros;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ARS_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rRolesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rCiudadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCiudades ciudades = new rCiudades();
            ciudades.Show();
        }

        private void rDoctoresMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rEspecialidadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rEspecialidades respecialidad = new rEspecialidades();
            respecialidad.Show();
        }

        private void rAfiliadosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rOcupacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rAseguradorasMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rDiagnosticosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rServiciosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rReclamacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cRolesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cCiudadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cCiudades ciudades = new cCiudades();
            ciudades.Show();
        }

        private void cDoctoresMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cEspecialidadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cEspecialidades cespecialidad = new cEspecialidades();
            cespecialidad.Show();
        }

        private void cAfiliadosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cOcupacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cAseguradorasMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cDiagnosticosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cServiciosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cReclamacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

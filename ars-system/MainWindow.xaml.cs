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
            rUsuarios usuarios = new rUsuarios();
            usuarios.Show();
        }

        private void rRolesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRoles roles = new rRoles();

            roles.Show();
        }

        private void rCiudadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCiudades ciudades = new rCiudades();
            ciudades.Show();
        }

        private void rDoctoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rDoctores doctores = new rDoctores();
            doctores.Show();
        }

        private void rEspecialidadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rEspecialidades respecialidad = new rEspecialidades();
            respecialidad.Show();
        }

        private void rAfiliadosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rPermisosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPermisos permisos = new rPermisos();
            permisos.Show();
        }

        private void rAseguradorasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rAseguradoras aseguradoras = new rAseguradoras();
            aseguradoras.Show();
        }

        private void rDiagnosticosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rDiagnosticos rdiagnostico = new rDiagnosticos();
            rdiagnostico.Show();
        }

        private void rReclamacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cRolesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cRoles roles = new cRoles();

            roles.Show();
        }

        private void cCiudadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cCiudades ciudades = new cCiudades();
            ciudades.Show();
        }

        private void cDoctoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cDoctores doctores = new cDoctores();
            doctores.Show();
        }

        private void cEspecialidadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cEspecialidades cespecialidad = new cEspecialidades();
            cespecialidad.Show();
        }

        private void cAfiliadosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void cPermisosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cPermisos permisos = new cPermisos();
            permisos.Show();
        }
        private void cOcupacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cOcupaciones ocupaciones = new cOcupaciones();
            ocupaciones.Show();
        }

        private void cAseguradorasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cAseguradoras aseguradoras = new cAseguradoras();
            aseguradoras.Show();
        }

        private void cDiagnosticosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cDiagnosticos cdiagnostico = new cDiagnosticos();
            cdiagnostico.Show();
        }

        private void cServiciosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cServicios cServicios = new cServicios();
            cServicios.Show();
        }

        private void cReclamacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cProvincias_Click_1(object sender, RoutedEventArgs e)
        {
            cProvincias cProvincias = new cProvincias();
            cProvincias.Show();
        }

        private void cPrestadoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cPrestadores cprestador = new cPrestadores();
            cprestador.Show();
        }
    }
}

using ClienteSistemaTutorias.InformacionUsuarios;
using ClienteSistemaTutorias.ServiceReferenceTutorias;
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

namespace ClienteSistemaTutorias
{
    /// <summary>
    /// Lógica de interacción para MenuCoordinador.xaml
    /// </summary>
    public partial class MenuCoordinador : Window
    {
        public MenuCoordinador(Academico academicoLogeado)
        {
            InitializeComponent();
            recibirAcademico(academicoLogeado);
        }
        Academico academicoEnUso = new Academico();

        public void recibirAcademico(Academico academicoLogeado)
        {
            
            academicoEnUso = academicoLogeado;
        }

        private void clickBtnRegistrarComentariosgenerales(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void clickBtnEditarComentariosGenerales(object sender, RoutedEventArgs e)
        {
            SeleccionarComentarios seleccionarComentarios = new SeleccionarComentarios(academicoEnUso);
            seleccionarComentarios.Show();
            this.Close();
        }

        private void clickBtnRegistrarHorarioDeSesion(object sender, RoutedEventArgs e)
        {
            SeleccionarAlumnoParaHorario seleccionarAlumnoParaHorario = new SeleccionarAlumnoParaHorario(academicoEnUso);
            seleccionarAlumnoParaHorario.Show();
            this.Close();
        }

        private void clickBtnConsultarHorario(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnRegistrarProblematicaAcademica(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnLlenarreporteTutoria(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnRegistrarFechasDeSesion(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnConsultarReporteGeneral(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnRegistrarFechasDeCierre(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnRegistrarProfesor(object sender, RoutedEventArgs e)
        {
            RegistrarProfesor registrarProfesor = new RegistrarProfesor(academicoEnUso);
            registrarProfesor.Show();
            this.Close();
        }
 
        private void clickBtnModificarFechasSesion(object sender, RoutedEventArgs e)
        {
            VModificarFechasSesionTutoria registrarProfesor = new VModificarFechasSesionTutoria(academicoEnUso);
            registrarProfesor.Show();
            this.Close();
        }
        //clickBtnSalir
        private void clickBtnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void clickBtnCerrarSesion(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();

        }
    }
}

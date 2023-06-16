using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace ClienteSistemaTutorias
{
    /// <summary>
    /// Lógica de interacción para SeleccionarAlumnoParaHorario.xaml
    /// </summary>
    public partial class SeleccionarAlumnoParaHorario : Window
    {
        public SeleccionarAlumnoParaHorario(Academico academicoLogeado)
        {
            InitializeComponent();
            recibirAcademico(academicoLogeado);
            mostrarTutoradosObtenidos();
        }

        public Academico academicoEnUso = new Academico();
        public void recibirAcademico(Academico academicoLogeado)
        {
            academicoEnUso = academicoLogeado;
        }

        public ObservableCollection<HorarioTutorado> tutoradoCollection { get; set;}

        public void mostrarTutoradosObtenidos()
        {
            tutoradoCollection = new ObservableCollection<HorarioTutorado>();
            var conexion = new Service1Client();
            if (conexion != null)
            {
                int idTutor = academicoEnUso.idAcademico;
                HorarioTutorado[] tutoradosRecuperados = conexion.recuperarTutoradosPorTutor(idTutor);
                foreach (HorarioTutorado tutorado in tutoradosRecuperados)
                {
                    tutoradoCollection.Add(tutorado);
                }
            }
            else
            {
                MessageBox.Show("Error de conexión");
            }
            dgTutorados.ItemsSource = tutoradoCollection;
        }


        private void clickBtnSeleccionar(object sender, RoutedEventArgs e)
        {
            HorarioTutorado tutoradoSeleccionado = dgTutorados.SelectedItem as HorarioTutorado;
            if (tutoradoSeleccionado != null)
            {
                RegistrarHorarioSesion registrarHorarioSesion = new RegistrarHorarioSesion(academicoEnUso, tutoradoSeleccionado);
                registrarHorarioSesion.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un tutorado");
            }
        }

        private void clickBtnCancelar(object sender, RoutedEventArgs e)
        {
            if (academicoEnUso.idRol == 1)
            {
                MenuJefe menuJefe = new MenuJefe(academicoEnUso);
                menuJefe.Show();
                this.Close();
            }
            else if (academicoEnUso.idRol == 2)
            {
                MenuCoordinador menuCoordinador = new MenuCoordinador(academicoEnUso);
                menuCoordinador.Show();
                this.Close();
            }
            else if (academicoEnUso.idRol == 3)
            {
                MenuTutor menuTutor = new MenuTutor(academicoEnUso);
                menuTutor.Show();
                this.Close();
            }
        }
    }
}

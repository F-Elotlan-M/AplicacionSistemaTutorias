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

namespace ClienteSistemaTutorias
{
    /// <summary>
    /// Lógica de interacción para SeleccionarComentarios.xaml
    /// </summary>
    public partial class SeleccionarComentarios : Window
    {
        public SeleccionarComentarios(Academico academicoLogeado)
        {
            InitializeComponent();
            recibirAcademico(academicoLogeado);
            mostrarComentarioObtenidos();
        }
        public Academico academicoEnUso = new Academico();
        public void recibirAcademico(Academico academicoLogeado)
        {
            academicoEnUso = academicoLogeado;
        }

        public ObservableCollection<ConsultaComentarios> comentariosObtenidos { get; set; }

        public void mostrarComentarioObtenidos()
        {
            comentariosObtenidos = new ObservableCollection<ConsultaComentarios>();
            var conexion = new Service1Client();
            if (conexion != null)
            {
                int idTutor = academicoEnUso.idAcademico;
                ConsultaComentarios[] comentariosRecuperados = conexion.obtenerComentarios(idTutor);
                foreach(ConsultaComentarios comentarioGeneral in comentariosRecuperados)
                {
                    comentariosObtenidos.Add(comentarioGeneral);
                }
            }
            else
            {
                MessageBox.Show("Error de conexión");
            }
            dgComentarios.ItemsSource = comentariosObtenidos;
        }

        private void clickBtnModificar(object sender, RoutedEventArgs e)
        {
            ConsultaComentarios comentarioSeleccionado = dgComentarios.SelectedItem as ConsultaComentarios;
            if (comentarioSeleccionado !=  null)
            {
                EditarComentariosGenerales editarComentariosGenerales = new EditarComentariosGenerales(academicoEnUso, comentarioSeleccionado);
                editarComentariosGenerales.Show();
                this.Close();
            }
        }

        private void clickBtnCancelar(object sender, RoutedEventArgs e)
        {
            if (academicoEnUso.idRol == 1)
            {
                MenuJefe menuJefe = new MenuJefe(academicoEnUso);
                menuJefe.Show();
                this.Close();
            }else if(academicoEnUso.idRol == 2)
            {
                MenuCoordinador menuCoordinador = new MenuCoordinador(academicoEnUso);
                menuCoordinador.Show();
                this.Close();
            }
            else if(academicoEnUso.idRol == 3)
            {
                MenuTutor menuTutor = new MenuTutor(academicoEnUso);
                menuTutor.Show();
                this.Close();
            }
        }
    }
}

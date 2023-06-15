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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class EditarComentariosGenerales : Window
    {
        public EditarComentariosGenerales(Academico academicoLogeado, ConsultaComentarios comentarioSeleccionado)
        {
            InitializeComponent();
            recibirAcademico(academicoLogeado);
            recibirComentarios(comentarioSeleccionado);
        }
        Academico academicoEnUso = new Academico();
        ConsultaComentarios comentariosEnUso = new ConsultaComentarios();
        public void recibirAcademico(Academico academicoLogeado)
        {
            academicoEnUso = academicoLogeado;
        }
        public void recibirComentarios(ConsultaComentarios comentarioSeleccionado)
        {
            comentariosEnUso = comentarioSeleccionado;
            tbDescripcion.Text = comentariosEnUso.descripcion;
        }

        private void clickBtnGuardarCambios(object sender, RoutedEventArgs e)
        {
            string cambios = tbDescripcion.Text;
            ComentarioGeneral comentarioGeneral = new ComentarioGeneral();
            comentarioGeneral = new ComentarioGeneral()
            {
                idComentarioGeneral = comentariosEnUso.idComentarioGeneral,
                descripcion = cambios
            };
            Service1Client conexion = new Service1Client();
            bool respuesta = conexion.realizarCambiosComentarios(comentarioGeneral);
            if (respuesta == true)
            {
                MessageBox.Show("El comentario se ha actualizado exitosamente");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        private void clickBtnCancelar(object sender, RoutedEventArgs e)
        {
            SeleccionarComentarios seleccionarComentarios = new SeleccionarComentarios(academicoEnUso);
            seleccionarComentarios.mostrarComentarioObtenidos();
            seleccionarComentarios.Show();
            this.Close();
        }
    }
}

using ClienteSistemaTutorias.Modelo;
using ClienteSistemaTutorias.ServiceReferenceITutoriaAcademicaMgt;
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
    /// Lógica de interacción para VModificarFechasSesionTutoria.xaml
    /// </summary>
    public partial class VModificarFechasSesionTutoria : Window
    {
        ServiceReferenceTutorias.Academico AcademicoLogin;
        public VModificarFechasSesionTutoria(ServiceReferenceTutorias.Academico academicoLog)
        {
            InitializeComponent();
            AcademicoLogin = academicoLog;
            cargarPeriodosEscolares();
        }

        public void cargarPeriodosEscolares()
        {
            PeriodoEscolarViewModel periodoEscolarVM = new PeriodoEscolarViewModel();
            cbPeriodoEscolar.ItemsSource = periodoEscolarVM.PeriodosEscolaresDB;
        }

        private void Button_Click_Comprobar(object sender, RoutedEventArgs e)
        {
            if (cbNumeroSesion.Text == "Seleccione número de sesión")
            {
                lbAdvertencia.Content = "Existen campos vacíos.";
            }
            else
            {
                lbAdvertencia.Content = "";

                cargarTutoriaAcademicaActual();

            }
        }

        public void cargarTutoriaAcademicaActual()
        {
            TutoriaAcademicaViewModel tutoriaAcademicaVM = new TutoriaAcademicaViewModel();

            ComboBoxItem selectedItem = (ComboBoxItem)cbNumeroSesion.SelectedItem;
            string numeroS = selectedItem.Content.ToString();

            int numeroSeleccionado = 0;
            int.TryParse(numeroS, out numeroSeleccionado);

            tutoriaAcademicaVM.SolicitarTutoriaActualServicio(numeroSeleccionado, cbPeriodoEscolar.Text);
            if (tutoriaAcademicaVM.TutoriaAcademicaActual != null)
            {
                dgTutoriaAcademica.ItemsSource = tutoriaAcademicaVM.TutoriaAcademicaActual;
            }
            else if (tutoriaAcademicaVM.TutoriaAcademicaActual == null)
            {
                MessageBox.Show("No existen tutorías académicas con el dato número de sesión: " + numeroSeleccionado.ToString() + " en el período: " + cbPeriodoEscolar.Text, "Registros no encontrados");
            }

        }

        private void Button_Click_Cancelar(object sender, RoutedEventArgs e)
        {
            MenuCoordinador menuCoordinador = new MenuCoordinador(AcademicoLogin);
            menuCoordinador.Show();
            this.Close();
        }

        private void Button_Click_Modificar(object sender, RoutedEventArgs e)
        {
            if (validarCamposVacios() == false)
            {
                TutoriaAcademica tutoriaSeleccionada = dgTutoriaAcademica.SelectedItem as TutoriaAcademica;
                DateTime? fechaSeleccionada = dpFechaNueva.SelectedDate;
                EditarFechaSesionTutoria(tutoriaSeleccionada.idTutoriaAcademica, (DateTime)fechaSeleccionada);
            }
            else
            {
                MessageBox.Show("Existen campos vacios u opciones no seleccionadas.", "No se pudo completar la operacion");
            }
        }

        private void EditarFechaSesionTutoria(int idTutoriaAcadeemica, DateTime fechaSesionNueva)
        {
            TutoriaAcademicaViewModel tutoriaAcademicaViewModel = new TutoriaAcademicaViewModel();
            tutoriaAcademicaViewModel.EditarFechaSesionTutoriaServicio(idTutoriaAcadeemica, fechaSesionNueva);
            string mensaje = "";
            if (tutoriaAcademicaViewModel.respuestaEditarFechaSesionTutoria == 1)
            {
                mensaje = "La operacion se realizó exitosamente.";
                cbNumeroSesion.SelectedIndex = 0;
                dgTutoriaAcademica.ItemsSource = null;
                dpFechaNueva.SelectedDate = null;
            }
            else
            {
                mensaje = "La operacion no pudo completarse debido a que la nueva fecha no se encuentra dentro del tiempo establecido para el periodo escolar o otra tutoria ocupa esa fecha.";
            }

            MessageBox.Show(mensaje, "Estado de operación");
        }

        private Boolean validarCamposVacios()
        {
            Boolean camposVacios = false;
            
            if (dgTutoriaAcademica.Items.Count == 0 || dpFechaNueva.SelectedDate == null || dpFechaNueva.SelectedDate == DateTime.MinValue || dgTutoriaAcademica.SelectedItem == null)
            {
                camposVacios = true;
            }

            return camposVacios;
        }
    }
}

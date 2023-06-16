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
    /// Lógica de interacción para RegistrarSolucion.xaml
    /// </summary>
    public partial class RegistrarSolucion : Window
    {
        public RegistrarSolucion(Academico academicoLogeado, Problematica problematicaSeleccionada)
        {
            InitializeComponent();
            recibirAcademico(academicoLogeado);
            recibirProblematica(problematicaSeleccionada);
        }
        public Academico academicoEnUso = new Academico();
        public Problematica problematicaEnUso = new Problematica();
        public void recibirAcademico(Academico academicoLogeado)
        {
            academicoEnUso = academicoLogeado;
        }
        public void recibirProblematica(Problematica problematicaSeleccionada)
        {
            problematicaEnUso = problematicaSeleccionada;
            tblDescripción.Text = "Descripción: " + problematicaEnUso.descripcion;
            tbNombre.Text = "Titulo: " + problematicaEnUso.nombre;
        }

        private void clickBtnCancelar(object sender, RoutedEventArgs e)
        {
            SeleccionarProblematica seleccionarProblematica = new SeleccionarProblematica(academicoEnUso);
            seleccionarProblematica.Show();
            this.Close();
        }

        private void clickBtnGuardar(object sender, RoutedEventArgs e)
        {
            String descripcionSolucion = tbSolucion.Text;
            int idJefeDeCarrera = academicoEnUso.idAcademico;
            int idProblematica = problematicaEnUso.idProblematica;
            if (!string.IsNullOrEmpty(descripcionSolucion))
            {

                SolucionProblematica solucionNueva = new SolucionProblematica()
                {
                    descripcion = descripcionSolucion,
                    idJefeProgramaEducativo = idJefeDeCarrera,
                    idProblematica = idProblematica
                };
                Service1Client service1Client = new Service1Client();
                bool respuesta = service1Client.registrarSolucion(solucionNueva);
            
                if(respuesta == true)
                {
                    MessageBox.Show("solución registrada exitosamente");
                    SeleccionarProblematica seleccionarProblematica = new SeleccionarProblematica(academicoEnUso);
                    service1Client.asignarSolucion((int)solucionNueva.idProblematica);
                    seleccionarProblematica.mostrarProblematicaAcademicaSinSolucion();
                    seleccionarProblematica.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la solución");
                }
            }
            else
            {
                MessageBox.Show("No se ha introducido una solución");
            }
            
        }
    }
}

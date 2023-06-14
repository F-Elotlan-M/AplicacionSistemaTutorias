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
    /// Lógica de interacción para SeleccionarProblematica.xaml
    /// </summary>
    public partial class SeleccionarProblematica : Window
    {
        public SeleccionarProblematica(Academico academicoLogeado)
        {
            InitializeComponent();
            recibirAcademico(academicoLogeado);
            mostrarProblematicaAcademicaSinSolucion();
        }
        public Academico academicoEnUso = new Academico();
        public void recibirAcademico(Academico academicoLogeado)
        {
            academicoEnUso = academicoLogeado;
        }
        public ObservableCollection<Problematica> problematicasObtenidas { get; set; }
        
        public void mostrarProblematicaAcademicaSinSolucion()
        {
            problematicasObtenidas = new ObservableCollection<Problematica>();
            var conexion = new Service1Client();
            if (conexion != null)
            {
                Problematica[] problematicasRecuperadas = conexion.recuperarProblematicasSinSolucion();
                foreach (Problematica problematicas in problematicasRecuperadas)
                {
                    if(problematicas != null)
                    {
                        problematicasObtenidas.Add(problematicas);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error de conexion");
            }
            dgProblematicas.ItemsSource = problematicasObtenidas;
        }

        private void clickBtnSeleccionar(object sender, RoutedEventArgs e)
        {
            Problematica problematicaSeleccionada = dgProblematicas.SelectedItem as Problematica;
            if(problematicaSeleccionada != null)
            {
                RegistrarSolucion registrarSolucion = new RegistrarSolucion(academicoEnUso, problematicaSeleccionada);
                registrarSolucion.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Esa fila está vacía");
            }
        }

        private void clickBtnCancelar(object sender, RoutedEventArgs e)
        {
            MenuJefe menuJefe = new MenuJefe(academicoEnUso);
            menuJefe.Show();
            this.Close();
        }
    }
}

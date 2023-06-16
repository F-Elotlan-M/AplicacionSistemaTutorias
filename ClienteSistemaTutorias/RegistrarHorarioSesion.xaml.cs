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
    /// Lógica de interacción para RegistrarHorarioSesion.xaml
    /// </summary>
    public partial class RegistrarHorarioSesion : Window
    {
        public RegistrarHorarioSesion(Academico academicoLogeado, HorarioTutorado tutoradoSeleccionado)
        {
            InitializeComponent();
            cmbTime.Loaded += CmbTime_Loaded;
            recibirAcademico(academicoLogeado);
            recibirTutorado(tutoradoSeleccionado);
            iniciarComboBox();
        }

        public Academico academicoEnUso = new Academico();
        public HorarioTutorado tutoradoSeleccionado = new HorarioTutorado();
        string selectedTime = "";
        public void recibirAcademico(Academico academicoLogeado)
        {
            academicoEnUso = academicoLogeado;
        }

        public void recibirTutorado(HorarioTutorado tutorado)
        {
            tutoradoSeleccionado = tutorado;
            lblNombreTutorado.Content = tutoradoSeleccionado.nombreTutorado;
            lblApellidoPaternoTutorado.Content = tutoradoSeleccionado.apellidoPaterno;
            lblApellidoMaternoTutorado.Content = tutoradoSeleccionado.apellidoMaterno;
        }

        private DateTime currentTime;
        //Asignar horarios al combobox

        private void CmbTime_Loaded(object sender, RoutedEventArgs e)
        {
            currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);

            while (currentTime.TimeOfDay <= TimeSpan.FromHours(19))
            {
                cmbTime.Items.Add(currentTime.ToString("HH:mm:ss"));
                currentTime = currentTime.AddMinutes(30);
            }

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentTime = currentTime.AddSeconds(1);
            cmbTime.SelectedItem = currentTime.ToString("HH:mm:ss");
        }

        public ObservableCollection<TutoriaAcademica> sesionesObservables { get; set; }
        int idTutoria = 0;
        public async void iniciarComboBox()
        {

            sesionesObservables = new ObservableCollection<TutoriaAcademica>();
            var conexion = new Service1Client();
            if (conexion != null)
            {
                TutoriaAcademica[] roles = await conexion.obtenerSesionesAsync();
                
                foreach (TutoriaAcademica rolesObtenidos in roles)
                {
                    sesionesObservables.Add(rolesObtenidos);
                }
            }
            else
            {
                MessageBox.Show("Error de conexión");
            }
            cbSesion.ItemsSource = sesionesObservables;
        }

        private void clickBtnAsignar(object sender, RoutedEventArgs e)
        {
            
            TimeSpan horaSeleccionada;
            var sesionSeleccionada = cbSesion.SelectedItem as TutoriaAcademica;
            int idTutor = 0;
            idTutor = academicoEnUso.idAcademico;
            int idTutorado = 0;
            idTutorado = tutoradoSeleccionado.idTutorado;
            if (cbSesion.SelectedIndex !=- 1)
            {
                if(cmbTime.SelectedIndex != -1)
                {

                    idTutoria = sesionSeleccionada.idTutoriaAcademica;
                    selectedTime = cmbTime.SelectedItem.ToString();
                    if (TimeSpan.TryParse(selectedTime, out horaSeleccionada))
                    {
                    
                        HoraTutoria nuevoHorario = new HoraTutoria()
                        {
                            horaTutoria1 = horaSeleccionada,
                            idTutoriaAcademica = idTutoria,
                            idTutorAcademico = idTutor,
                            idTutorado = idTutorado
                        };
                        Service1Client conexion = new Service1Client();
                        int respuesta = conexion.registrarHorarioSesion(nuevoHorario);
                        if (respuesta == 0)
                        {
                            MessageBox.Show("Error de conexión");
                        }else if (respuesta == 1)
                        {
                            MessageBox.Show("Horario registrado exitosamente");
                            SeleccionarAlumnoParaHorario seleccionarAlumnoParaHorario = new SeleccionarAlumnoParaHorario(academicoEnUso);
                            seleccionarAlumnoParaHorario.Show();
                            this.Close();
                        }else if (respuesta == 2)
                        {
                            MessageBox.Show("Este horario ya fue reservado para otro estudiante");
                        }else if (respuesta == 3)
                        {
                            MessageBox.Show("El tutorado ya cuenta con horario para esta sesión");
                        }

                    }
                    else
                    {
                        MessageBox.Show("El formato de la hora es incorrecto");
                    }
                }
                else
                {
                    MessageBox.Show("Hay campos vacíos");
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacíos");
            }
        }

        private void clickBtnCancelar(object sender, RoutedEventArgs e)
        {
            SeleccionarAlumnoParaHorario seleccionarAlumnoParaHorario = new SeleccionarAlumnoParaHorario(academicoEnUso);
            seleccionarAlumnoParaHorario.Show();
            this.Close();
        }
    }
}

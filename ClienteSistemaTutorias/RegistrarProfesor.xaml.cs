using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
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
using System.Text.RegularExpressions;

namespace ClienteSistemaTutorias
{
    /// <summary>
    /// Lógica de interacción para RegistrarProfesor.xaml
    /// </summary>
    public partial class RegistrarProfesor : Window
    {
        public RegistrarProfesor(Academico academicoLogeado)
        {
            InitializeComponent();
            iniciarComboBox();
            recibirAcademico(academicoLogeado);
        }
        Academico academicoEnUso = new Academico();
        public void recibirAcademico(Academico academicoLogeado)
        {
            
            academicoEnUso = academicoLogeado;
        }

        public ObservableCollection<Rol> rolesObservables { get; set; }
        int idRolSeleccionado; 
        public async void iniciarComboBox()
        {
            rolesObservables = new ObservableCollection<Rol>();
            var conexion = new AcademicoClient();
            if (conexion != null)
            {
                Rol[] roles = await conexion.recuperarRolesAsync();
                foreach (Rol rolesObtenidos in roles)
                {
                    rolesObservables.Add(rolesObtenidos);
                }
            }
            else
            {
                MessageBox.Show("Error de conexión");
            }
            cbRol.ItemsSource = rolesObservables;
        }

        private void clickBtnGuardar(object sender, RoutedEventArgs e)
        {
            string nombre = tbNombre.Text;
            string apellidoPaterno = tbApellidoPaterno.Text;
            string apellidoMaterno = tbApellidoMaterno.Text;
            string correo = tbCorreo.Text;
            string numeroMatricula = tbNumeroPersonal.Text;
            int idRol = 0; 
            idRol = idRolSeleccionado;

            if (!string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(apellidoPaterno) || !string.IsNullOrEmpty(apellidoMaterno) || 
                !string.IsNullOrEmpty(correo) || !string.IsNullOrEmpty(numeroMatricula))
            {
                if (ValidarFormatoCorreo(correo))
                {
                    if (idRolSeleccionado > 0)
                    {
                        Academico profesorNuevo = new Academico()
                        {
                            nombre = nombre,
                            apellidoMaterno = apellidoMaterno,
                            apellidoPaterno = apellidoPaterno,
                            correoInstitucional = correo,
                            numPersonal = numeroMatricula,
                            idRol = idRol,
                            password = numeroMatricula,
                            idAcademico = 1
                        };
                        AcademicoClient academicoClient = new AcademicoClient();
                        int respuesta = academicoClient.registrarProfesor(profesorNuevo);
                        if (respuesta == 1)
                        {
                            MessageBox.Show("Profesor registrado");
                            tbNombre.Clear();
                            tbApellidoPaterno.Clear();
                            tbApellidoMaterno.Clear();
                            tbCorreo.Clear();
                            tbNumeroPersonal.Clear();
                            cbRol.SelectedIndex = 0;
                        }
                        else if (respuesta == 2)
                        {
                            MessageBox.Show("El rol de jefe de carrera ya está registrado");
                        }
                        else if (respuesta == 3)
                        {
                            MessageBox.Show("El rol de coordinador de tutorias ya está registrado");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay roles seleccionados");
                    }
                }
                else
                {
                    MessageBox.Show("El formato del correo no es válido");
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacíos");
            }
        }

        private void cbRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rolSeleccionado = cbRol.SelectedItem as Rol;
            idRolSeleccionado = rolSeleccionado.idRol;
            
        }
        //valida que el campo solo reciba letras y no números
        private void txtCampo_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true; 
            }
        }
        //permite verificar que se acepten formatos de correo válidos
        static bool ValidarFormatoCorreo(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patron);
        }
        //valida que solo entren numeros y no letras
        private void txtNumeros_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !EsNumero(e.Text);
        }

        private bool EsNumero(string texto)
        {
            return int.TryParse(texto, out _);
        }

        private void clicBtnCancelar(object sender, RoutedEventArgs e)
        {
            MenuCoordinador menuCoordinador = new MenuCoordinador(academicoEnUso);
            menuCoordinador.Show();
            this.Close();
        }
    }
}

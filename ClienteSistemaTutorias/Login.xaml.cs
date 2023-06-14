using ClienteSistemaTutorias.InformacionUsuarios;
using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Windows;
using System.Runtime.Serialization;
namespace ClienteSistemaTutorias
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        string aviso = "";

        private void clicBtnIniciarSesion(object sender, RoutedEventArgs e)
        {
            string correo = tbUsuario.Text;
            string password = psbPassword.Password;
            if(correo.Length > 0 && password.Length > 0)
            {
                verificarInicioSesion(correo, password);
            }
            else
            {
                aviso = "Hay algunos campos vacíos";
                Avisos avisoVentana = new Avisos(aviso);
                avisoVentana.Show();
            }
        }
        private void clicBtnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void verificarInicioSesion(string correo, string password)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                Mensaje academico = await conexionServicios.LoginAsync(correo, password);
                
                if (academico.usuarioAutenticado != null)
                {
                    Academico academicoRecibido = new Academico();
                    academicoRecibido = academico.usuarioAutenticado;
                    if (academicoRecibido.idRol == 1)
                    {
                        MenuJefe menuJefe = new MenuJefe(academicoRecibido);
                        menuJefe.Show();
                        this.Close();
                    } else if (academicoRecibido.idRol == 2)
                    {
                        MenuCoordinador menuCoordinador = new MenuCoordinador(academicoRecibido);
                        menuCoordinador.Show();
                        this.Close();
                    }
                    else if (academicoRecibido.idRol == 3)
                    {
                        MenuTutor menuTutor = new MenuTutor(academicoRecibido);
                        menuTutor.Show();
                        this.Close();
                    }
                    else
                    {
                        aviso = "Usted no puede acceder al sistema";
                        Avisos avisoVentana = new Avisos(aviso);
                        avisoVentana.Show();
                    }
                }
                else
                {
                    aviso = "usuario y/o contraseña incorrecta";
                    Avisos avisoVentana = new Avisos(aviso);
                    avisoVentana.Show();
                }
            }
            else
            {

            }

        }
    }
}

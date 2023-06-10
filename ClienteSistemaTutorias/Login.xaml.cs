using System;
using System.Windows;

namespace ClienteSistemaTutorias
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void iniciarSesion(object sender, RoutedEventArgs e) 
        { 
            /*
            if (tbUsuario.Text.Length > 0 && psbPassword.Password.Length > 0) 
            {
                verificarInicioSesion(tbUsuario.Text, psbPassword.Password);
            } else {
                MessageBox.Show("Usuario y/o contraseña incorrecta", "Error");
            }
            */
            ServiceReferenceTutorias.Service1Client cliente = new ServiceReferenceTutorias.Service1Client();
            if (cliente.Login(tbUsuario.Text, psbPassword.Password) == 1) {
                MenuTutor menuTutor = new MenuTutor();
                menuTutor.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrecto");
            }

        }
    }
}

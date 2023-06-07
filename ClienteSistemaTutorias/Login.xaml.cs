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
            if (tbUsuario.Text.Length > 0 && psbPassword.Password.Length > 0) 
            {
                verificarInicioSesion(tbUsuario.Text, psbPassword.Password);
            } else {
                MessageBox.Show("Usuario y/o contraseña incorrecta", "Error");
            }
        }

        private async void verificarInicioSesion(string usuario, string password) 
        {

        }
    }
}

﻿using System;
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
    /// Lógica de interacción para MenuTutor.xaml
    /// </summary>
    public partial class MenuTutor : Window
    {
        public MenuTutor()
        {
            InitializeComponent();
        }

        private void clickBtnRegistrarComentariosgenerales(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void clickBtnEditarComentariosGenerales(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        
        private void clickBtnRegistrarFechasDeSesion(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void clickBtnConsultarHorario(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnRegistrarProblematicaAcademica(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnLlenarreporteTutoria(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        //clickBtnSalir
        private void clickBtnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void clickBtnCerrarSesion(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();

        }
    }
}

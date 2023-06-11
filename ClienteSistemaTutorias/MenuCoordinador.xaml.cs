﻿using ClienteSistemaTutorias.InformacionUsuarios;
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
    /// Lógica de interacción para MenuCoordinador.xaml
    /// </summary>
    public partial class MenuCoordinador : Window
    {
        public MenuCoordinador(Academico academicoLogeado)
        {
            InitializeComponent();
            recibirAcademico(academicoLogeado);
        }

        public void recibirAcademico(Academico academicoLogeado)
        {
            Academico academicoEnUso = new Academico();
            academicoEnUso = academicoLogeado;
        }

        private void clickBtnRegistrarComentariosgenerales(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void clickBtnEditarComentariosGenerales(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void clickBtnRegistrarHorarioDeSesion(object sender, RoutedEventArgs e)
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
        private void clickBtnRegistrarFechasDeSesion(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnConsultarReporteGeneral(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnRegistrarFechasDeCierre(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }
        private void clickBtnRegistrarProfesor(object sender, RoutedEventArgs e)
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

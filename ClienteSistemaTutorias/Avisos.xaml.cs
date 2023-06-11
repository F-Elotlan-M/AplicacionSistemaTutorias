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
    /// Lógica de interacción para Avisos.xaml
    /// </summary>
    public partial class Avisos : Window
    {
        public Avisos(string aviso)
        {
            InitializeComponent();
            lblAvisos.Content = aviso;
        }
        private void clicBtnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}

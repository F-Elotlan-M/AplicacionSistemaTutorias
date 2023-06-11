using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ClienteSistemaTutorias.InformacionUsuarios
{
    internal class AcademicoRecibido { 
        public ObservableCollection<Academico> academicoDB { get; set; }

        public void UsuarioViewModel()
        {
            academicoDB = new ObservableCollection<Academico>();
        }

        private async void solicitarInformacionServicio()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                Academico[] usuariosService = await conexionServicios.ObtenerUsuariosAsync();
                foreach (Academico usarioObtenido in usuariosService)
                {
                    academicoDB.Add(usarioObtenido);
                }
            }
        }
    }
}

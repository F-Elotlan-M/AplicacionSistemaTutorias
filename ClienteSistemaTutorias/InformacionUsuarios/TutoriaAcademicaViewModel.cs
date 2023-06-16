using ClienteSistemaTutorias.ServiceReferenceITutoriaAcademicaMgt;
using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo
{
    internal class TutoriaAcademicaViewModel
    {

        public ObservableCollection<ServiceReferenceITutoriaAcademicaMgt.TutoriaAcademica> TutoriaAcademicaActual { get; set; }
        public int respuestaRegistrarReporteTutoriaAcademico { get; set; }
        public int respuestaRegistrarAsistenciaPorTutoria { get; set; }

        public int respuestaEditarFechaSesionTutoria;
        
        public TutoriaAcademicaViewModel() 
        {
            TutoriaAcademicaActual = new ObservableCollection<ServiceReferenceITutoriaAcademicaMgt.TutoriaAcademica>();
        }

        public async void EditarFechaSesionTutoriaServicio(int idTutoriaAcademica, DateTime fechaSesionNueva)
        {
            var conexionServicio = new ITutoriaAcademicaMgtClient();
            if (conexionServicio != null)
            {

                int respuesta = await conexionServicio.EditarFechasSesionTutoriasAsync(idTutoriaAcademica, fechaSesionNueva);

                if (respuesta != 0)
                {
                    respuestaEditarFechaSesionTutoria = 1;
                }
                else
                {
                    respuestaEditarFechaSesionTutoria = 0;
                }

            }
            else
            {
                respuestaEditarFechaSesionTutoria = 0;
            }
        }

        public async void SolicitarTutoriaActualServicio(int numeroSesion, string periodoAcademico)
        {

            var conexionServicio = new ITutoriaAcademicaMgtClient();

            if (conexionServicio != null)
            {

                ServiceReferenceITutoriaAcademicaMgt.TutoriaAcademica[] tutoriaActualService = await conexionServicio.ObtenerTutoriaActualAsync(numeroSesion, periodoAcademico);

                if (tutoriaActualService != null)
                {
                    TutoriaAcademicaActual.Clear();
                    foreach (ServiceReferenceITutoriaAcademicaMgt.TutoriaAcademica tutoria in tutoriaActualService)
                    {
                        TutoriaAcademicaActual.Add(tutoria);
                    }
                }
                else
                {
                    TutoriaAcademicaActual.Clear();
                }
                
            }
            else
            {
                TutoriaAcademicaActual = null;
            }
        }

        public async void RegistrarReporteTutoriaAcademicaServicio(int idProgramaEducativoNuevo, int idTutoriaAcademicaNuevo, int idTutorAcademicoNuevo)
        {
            var conexionServicio = new ITutoriaAcademicaMgtClient();

            if (conexionServicio != null)
            {

                int respuesta = await conexionServicio.RegistrarReporteTutoriaAcademicaAsync(idProgramaEducativoNuevo, idTutoriaAcademicaNuevo, idTutorAcademicoNuevo);

                if (respuesta != 0)
                {
                    respuestaRegistrarReporteTutoriaAcademico = 1;
                }
                else
                {
                    respuestaRegistrarReporteTutoriaAcademico = 0;
                }

            }
            else
            {
                respuestaRegistrarReporteTutoriaAcademico = 0;
            }
        }

        public async void RegistrarAsistenciaPorTutoriaServicio(int[] idAsistencias, int idTutoria)
        {
            var conexionServicio = new ITutoriaAcademicaMgtClient();

            if(conexionServicio != null)
            {
                int respuesta = await conexionServicio.RegistrarAsistenciaPorTutoriaAsync(idAsistencias, idTutoria);

                if (respuesta != 0)
                {
                    respuestaRegistrarAsistenciaPorTutoria = 1;
                }
                else
                {
                    respuestaRegistrarAsistenciaPorTutoria = 0;
                }
            }
            else
            {
                respuestaRegistrarAsistenciaPorTutoria = 0;
            }
        }

    }
}
using ServiciosTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosTutorias
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ITutoriaAcademicaMgt" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ITutoriaAcademicaMgt.svc o ITutoriaAcademicaMgt.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ITutoriaAcademicaMgt : IITutoriaAcademicaMgt
    {
        int IITutoriaAcademicaMgt.RegistrarReporteTutoriaAcademica(int idProgramaEducativoNuevo, int idTutoriaAcademicaNuevo, int idTutorAcademicoNuevo)
        {
            return TutoriaAcademicaDAO.RegistrarReporteTutoriaAcademica(idProgramaEducativoNuevo, idTutoriaAcademicaNuevo, idTutorAcademicoNuevo);
        }

        ObservableCollection<TutoriaAcademica> IITutoriaAcademicaMgt.ObtenerTutoriaActual(int numeroSesion, string periodoAcademico)
        {
            return TutoriaAcademicaDAO.ObtenerTutoriaActual(numeroSesion, periodoAcademico);
        }

        int IITutoriaAcademicaMgt.RegistrarAsistenciaPorTutoria(int[] idAsistentes, int idTutoriaAcademica)
        {
            return TutoriaAcademicaDAO.RegistrarAsistenciaPorTutoria(idAsistentes, idTutoriaAcademica);
        }

        public int EditarFechasSesionTutorias(int idTutoriaAcademica, DateTime fechaSesionNueva)
        {
            return TutoriaAcademicaDAO.EditarFechasSesionTutorias(idTutoriaAcademica, fechaSesionNueva);
        }
    }
}

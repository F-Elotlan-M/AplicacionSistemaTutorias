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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IITutoriaAcademicaMgt" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IITutoriaAcademicaMgt
    {
        [OperationContract]
        ObservableCollection<TutoriaAcademica> ObtenerTutoriaActual(int numeroSesion, string periodoAcademico);

        [OperationContract]
        int RegistrarReporteTutoriaAcademica(int idProgramaEducativoNuevo, int idTutoriaAcademicaNuevo, int idTutorAcademicoNuevo);

        [OperationContract]
        int RegistrarAsistenciaPorTutoria(int[] idAsistentes, int idTutoriaAcademica);

        [OperationContract]
        int EditarFechasSesionTutorias(int idTutoriaAcademica, DateTime fechaSesionNueva);
    }
}

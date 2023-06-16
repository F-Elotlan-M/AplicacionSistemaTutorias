using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ServiciosTutorias.Modelo
{
    public class TutoriaAcademicaDAO
    {

        public static int EditarFechasSesionTutorias(int idTutoriaAcademica, DateTime fechaSesionNueva)
        {
            try
            {
                DataClassesTutoriasDBDataContext conexionBD = GetConnection();
                int respuesta = 0;

                var tutoriaDB = (from tutoriaQuery in conexionBD.TutoriaAcademica
                                where tutoriaQuery.idTutoriaAcademica == idTutoriaAcademica
                                select tutoriaQuery).FirstOrDefault();

                if (tutoriaDB != null || validarFechaOcupada(idTutoriaAcademica, fechaSesionNueva) == false || validarFechaPeriodo(idTutoriaAcademica, fechaSesionNueva) == false)
                {
                    tutoriaDB.fechaSesion = fechaSesionNueva;
                    conexionBD.SubmitChanges();

                    respuesta = 1;
                }

                return respuesta;
            }
            catch
            {
                return 0;
            }
        }

        public static Boolean validarFechaOcupada(int idtutoriaAcademica, DateTime fechaSesionNueva)
        {
            DataClassesTutoriasDBDataContext conexionBD = GetConnection();
            Boolean fechaOcupada = false;

            var tutoriaAModificar = (from tutoriaAQuery in conexionBD.TutoriaAcademica
                             where tutoriaAQuery.idTutoriaAcademica == idtutoriaAcademica
                             select tutoriaAQuery).FirstOrDefault();

            var tutoriaDB = (from tutoriaQuery in conexionBD.TutoriaAcademica
                             where tutoriaQuery.fechaSesion == fechaSesionNueva
                             && tutoriaQuery.idPeriodoEscolar == tutoriaAModificar.idPeriodoEscolar
                             select tutoriaQuery).FirstOrDefault();

            if (tutoriaDB != null)
            {
                fechaOcupada = true;
            }

            return fechaOcupada;
        }

        public static Boolean validarFechaPeriodo(int idTutoriaAcademica, DateTime fechaSesionNueva)
        {
            DataClassesTutoriasDBDataContext conexionBD = GetConnection();
            Boolean fechaFueraPeriodo = false;

            var tutoriaDB = (from tutoriaQuery in conexionBD.TutoriaAcademica
                             join periodoQuery in conexionBD.PeriodoEscolar
                             on tutoriaQuery.idPeriodoEscolar equals periodoQuery.idPeriodoEscolar
                             where tutoriaQuery.idTutoriaAcademica == idTutoriaAcademica
                             && periodoQuery.FechaInicio <= fechaSesionNueva
                             && periodoQuery.FechaFin >= fechaSesionNueva
                             select tutoriaQuery).FirstOrDefault();

            if (tutoriaDB != null)
            {
                fechaFueraPeriodo = true;
            }

            return fechaFueraPeriodo;
        }

        public static ObservableCollection<TutoriaAcademica> ObtenerTutoriaActual(int numeroSesion, string periodoAcademico)
        {
            DataClassesTutoriasDBDataContext conexionBD = GetConnection();

            IQueryable<TutoriaAcademica> tutoriaActual = from tutoriaQuery in conexionBD.TutoriaAcademica
                                                         join periodoQuery in conexionBD.PeriodoEscolar
                                                         on tutoriaQuery.idPeriodoEscolar equals periodoQuery.idPeriodoEscolar
                                                         where tutoriaQuery.numeroSesion == numeroSesion &&
                                                               periodoQuery.titulo == periodoAcademico
                                                         select tutoriaQuery;

            ObservableCollection<TutoriaAcademica> tutoriaAcademicaActual = new ObservableCollection<TutoriaAcademica>();

            foreach (TutoriaAcademica tutoriaAcad in tutoriaActual)
            {
                TutoriaAcademica tutoria = new TutoriaAcademica()
                {
                    idTutoriaAcademica = tutoriaAcad.idTutoriaAcademica,
                    fechaSesion = tutoriaAcad.fechaSesion,
                    numeroSesion = tutoriaAcad.numeroSesion,
                    fechaLimiteReporte = tutoriaAcad.fechaLimiteReporte,
                    idPeriodoEscolar = tutoriaAcad.idPeriodoEscolar
                };
                tutoriaAcademicaActual.Add(tutoria);

            }

            return tutoriaAcademicaActual;
        }

        public static int RegistrarAsistenciaPorTutoria(int[] idAsistentes, int idTutoriaAcademica)
        {
            try
            {
                DataClassesTutoriasDBDataContext conexionBD = GetConnection();
                int respuesta;

                foreach (int idTutoradoAsistente in idAsistentes)
                {
                    var asistencia = new Asistencia
                    {
                        idTutorado = idTutoradoAsistente,
                        idTutoriaAcademica = idTutoriaAcademica
                    };

                    conexionBD.Asistencia.InsertOnSubmit(asistencia);
                    
                }

                conexionBD.SubmitChanges();
                respuesta = 1;
                return respuesta;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int RegistrarReporteTutoriaAcademica(int idProgramaEducativoNuevo, int idTutoriaAcademicaNuevo, int idTutorAcademicoNuevo)
        {
            try
            {
                DataClassesTutoriasDBDataContext conexionBD = GetConnection();
                int respuesta = 0;

                if (validarReporteExistente(idProgramaEducativoNuevo, idTutoriaAcademicaNuevo, idTutorAcademicoNuevo) == false
                    && validarFechaLimiteReporte(idTutoriaAcademicaNuevo) == false)
                {
                    var nuevoReporteTutoriaAcademica = new ReporteTutoriaAcademica()
                    {
                        idProgramaEducativo = idProgramaEducativoNuevo,
                        idTutoriaAcademica = idTutoriaAcademicaNuevo,
                        idTutorAcademico = idTutorAcademicoNuevo
                    };

                    conexionBD.ReporteTutoriaAcademica.InsertOnSubmit(nuevoReporteTutoriaAcademica);
                    conexionBD.SubmitChanges();

                    respuesta = 1;
                }

                return respuesta;
            }catch (Exception ex)
            {
                return 0;
            }
        }

        public static Boolean validarReporteExistente(int idProgramaEducativo, int idTutoriaAcademica, int idTutorAcademico)
        {
            DataClassesTutoriasDBDataContext conexionBD = GetConnection();
            Boolean reporteExistente = false;

            var reporteEncontrado = (from reporteTutoriaQuery in conexionBD.ReporteTutoriaAcademica
                                     where  reporteTutoriaQuery.idProgramaEducativo == idProgramaEducativo
                                     && reporteTutoriaQuery.idTutoriaAcademica == idTutoriaAcademica
                                     && reporteTutoriaQuery.idTutorAcademico == idTutorAcademico
                                    select reporteTutoriaQuery).FirstOrDefault();
            
            if (reporteEncontrado != null)
            {
                reporteExistente = true;
            }

            return reporteExistente;
        }

        public static Boolean validarFechaLimiteReporte(int idTutoriaAcademica)
        {
            DataClassesTutoriasDBDataContext conexionBD = GetConnection();
            Boolean fechaExpirada = false;
            DateTime fechaActual = DateTime.Now;

            var tutoriaAcademicaEncontrada = (from tutoriaQuery in conexionBD.TutoriaAcademica
                                              where tutoriaQuery.idTutoriaAcademica == idTutoriaAcademica
                                              && tutoriaQuery.fechaLimiteReporte >= fechaActual
                                              select tutoriaQuery).FirstOrDefault();


            if (tutoriaAcademicaEncontrada == null)
            {
                fechaExpirada = true;
            }

            return fechaExpirada;
        }

        public static DataClassesTutoriasDBDataContext GetConnection()
        {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }

    }
}
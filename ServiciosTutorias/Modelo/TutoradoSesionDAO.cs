using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo
{
    public class TutoradoSesionDAO
    {
        public List<HorarioTutorado> recuperarTutoradosPorTutor(int idTutor)
        {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<HorarioTutorado> tutorados = new List<HorarioTutorado>();
            var resultado = conexionBD.HorarioTutorado
                            .Where(h => h.idAcademico == idTutor)
                            .Select(h => new
                            {
                                h.idTutorado,
                                h.nombreTutorado,
                                h.apellidoPaterno,
                                h.apellidoMaterno,
                                h.idAcademico,
                                h.nombreTutor
                            })
                            .ToList();
            if (conexionBD != null)
            {
                if (resultado != null)
                {
                    foreach (var agregar in resultado)
                    {
                        HorarioTutorado tutoradoIterable = new HorarioTutorado()
                        {
                            idTutorado = agregar.idTutorado,
                            nombreTutorado = agregar.nombreTutorado,
                            apellidoPaterno = agregar.apellidoPaterno,
                            apellidoMaterno = agregar.apellidoMaterno,
                            idAcademico = agregar.idAcademico,
                            nombreTutor = agregar.nombreTutor
                        };
                        tutorados.Add(tutoradoIterable);
                    }
                    return tutorados;
                }else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public List<TutoriaAcademica> obtenerSesiones()
        {
            DateTime fechaActual = DateTime.Now;
            List<TutoriaAcademica> sesiones = new List<TutoriaAcademica>();
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            var result = from tutoria in conexionBD.TutoriaAcademica
                         where tutoria.fechaSesion > fechaActual
                         select tutoria;
            if (result != null)
            {
                foreach (var resultados in result)
                {
                    TutoriaAcademica tutoriaIterable = new TutoriaAcademica()
                    {
                        idTutoriaAcademica = resultados.idTutoriaAcademica,
                        fechaSesion = resultados.fechaSesion,
                        numeroSesion = resultados.numeroSesion,
                        fechaLimiteReporte = resultados.fechaLimiteReporte,
                        idPeriodoEscolar = resultados.idPeriodoEscolar
                    };
                    sesiones.Add(tutoriaIterable);
                }
                return sesiones;
            }
            else
            {
                return null;
            }
        }

        public int registrarHorarioSesion(HoraTutoria horario)
        {
            try
            {
                DataClassesTutoriasDBDataContext conexionBD = getConnection();
                var consulta = from consultaTutoradoExistente in conexionBD.HoraTutoria
                               where consultaTutoradoExistente.idTutorado == horario.idTutorado &&
                               consultaTutoradoExistente.idTutoriaAcademica == horario.idTutoriaAcademica
                               select consultaTutoradoExistente;
                if(!consulta.Any())
                {
                    var consultaHorario = from consultaHorarioExistente in conexionBD.HoraTutoria
                                          where consultaHorarioExistente.horaTutoria1 == horario.horaTutoria1 &&
                                          consultaHorarioExistente.idTutoriaAcademica == horario.idTutoriaAcademica
                                          select consultaHorarioExistente;
                    if (!consultaHorario.Any())
                    {
                        var horarioNuevo = new HoraTutoria()
                        {
                            horaTutoria1 = horario.horaTutoria1,
                            idTutoriaAcademica = horario.idTutoriaAcademica,
                            idTutorAcademico = horario.idTutorAcademico,
                            idTutorado = horario.idTutorado
                        };
                        conexionBD.HoraTutoria.InsertOnSubmit(horarioNuevo);
                        conexionBD.SubmitChanges();
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 3;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    
        public List<ConsultaDeHorarios> obtenerHorarios()
        {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            IQueryable<ConsultaDeHorarios> consultaHorarios = from consulta in conexionBD.ConsultaDeHorarios
                                                                select consulta; 
            return consultaHorarios.ToList();
        }


        public static DataClassesTutoriasDBDataContext getConnection()
        {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }
    }

}
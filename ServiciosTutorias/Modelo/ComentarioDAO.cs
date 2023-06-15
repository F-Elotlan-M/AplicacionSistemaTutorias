using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo
{
    public class ComentarioDAO
    {

        public List<ConsultaComentarios> obtenerComentarios(int idTutor)
        {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            DateTime fechaActual = DateTime.Now;


            List<ConsultaComentarios> comentarios = new List<ConsultaComentarios>();
            IQueryable<ConsultaComentarios> consultarComentarios = from comentariosConsulta in conexionBD.ConsultaComentarios
                                                                   where comentariosConsulta.fechaLimiteReporte > fechaActual &&
                                                                   comentariosConsulta.descripcion != null &&
                                                                   comentariosConsulta.idTutorAcademico == idTutor
                                                                    select comentariosConsulta;
            if(consultarComentarios != null)
            {
                foreach(var agregar in consultarComentarios)
                {
                    ConsultaComentarios comentariosIterable = new ConsultaComentarios()
                    {
                        idComentarioGeneral = agregar.idComentarioGeneral,
                        descripcion = agregar.descripcion,
                        nombre = agregar.nombre,
                        fechaSesion = agregar.fechaSesion,
                        numeroSesion = agregar.numeroSesion,
                        fechaLimiteReporte = agregar.fechaLimiteReporte
                    };
                    comentarios.Add(comentariosIterable);
                }
                return comentarios;
            }
            else
            {
                return null;
            }
        }

        public Boolean realizarCambiosComentarios(ComentarioGeneral comentarioGeneral)
        {
            try
            {
                DataClassesTutoriasDBDataContext conexionBD = getConnection();
                var consulta = (from ConsultaComentarios in conexionBD.ComentarioGeneral
                                where ConsultaComentarios.idComentarioGeneral == comentarioGeneral.idComentarioGeneral
                                select ConsultaComentarios).FirstOrDefault();
                if(consulta != null)
                {
                    consulta.descripcion = comentarioGeneral.descripcion;
                    conexionBD.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public static DataClassesTutoriasDBDataContext getConnection()
        {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }
    }
}
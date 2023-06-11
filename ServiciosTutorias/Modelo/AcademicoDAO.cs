using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo
{
    public class AcademicoDAO
    {

        public static List<Academico> obtenerUsuarios()
        {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();

            IQueryable<Academico> usuariosBD = from usuarioQuery in conexionBD.Academico
                                             select usuarioQuery;
            return usuariosBD.ToList();
        }
        public Mensaje Login(string correo, string password)
        {
            DataClassesTutoriasDBDataContext conexionDB = getConnection();
            Mensaje mensajeLogeado = new Mensaje();
            Academico consulta = (from academicoConsulta in conexionDB.Academico
                                  where academicoConsulta.correoInstitucional == correo &&
                                  academicoConsulta.password == password
                                  select academicoConsulta).FirstOrDefault();
            if (consulta != null)
            {
                mensajeLogeado = new Mensaje()
                {
                    mensajeTexto = "Usuario encontrado",
                    error = false,
                    usuarioAutenticado = new Academico()
                    {
                        idAcademico = consulta.idAcademico,
                        nombre = consulta.nombre,
                        apellidoMaterno = consulta.apellidoMaterno,
                        apellidoPaterno = consulta.apellidoPaterno,
                        correoInstitucional = consulta.correoInstitucional,
                        password = consulta.password,
                        numPersonal = consulta.numPersonal,
                        idRol = consulta.idRol
                    }
                };
                return mensajeLogeado;
            }
            else
            {
                mensajeLogeado = new Mensaje()
                {
                    error = true,
                    mensajeTexto = "Usuario no encontrado"
                };
                return mensajeLogeado;
            }
        }
        

        public int LoginPrueba(string correo, string password)
        {
            DataClassesTutoriasDBDataContext conexionDB = getConnection();
            var consulta = (from academicoConsulta in conexionDB.Academico
                            where academicoConsulta.correoInstitucional == correo &&
                            academicoConsulta.password == password
                            select academicoConsulta).FirstOrDefault();
            if (consulta != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static DataClassesTutoriasDBDataContext getConnection()
        {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }
    }
}
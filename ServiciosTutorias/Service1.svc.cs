using ServiciosTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosTutorias {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1, IAcademico {
        public string GetData(int value) {
            return string.Format("You entered: {0}", value);
        }
        public List<Academico> ObtenerUsuarios()
        {
            List<Academico> usuariosBD = AcademicoDAO.obtenerUsuarios();
            return usuariosBD;
        }

        public Mensaje Login(string correo, string password)
        {
            AcademicoDAO academicoDAO = new AcademicoDAO();
            return academicoDAO.Login(correo, password);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int LoginPrueba(string correo, string password)
        {
            AcademicoDAO academicoDAO = new AcademicoDAO();
            return academicoDAO.LoginPrueba(correo, password);
        }

        //metodos de la interface IAcademico
        public int registrarProfesor(Academico profesorNuevo)
        {
            AcademicoDAO academicoDAO = new AcademicoDAO();
            return academicoDAO.registrarProfesor(profesorNuevo);
        }

        public List<Rol> recuperarRoles()
        {
            AcademicoDAO academicoRoles = new AcademicoDAO();
            return academicoRoles.recuperarRoles();
        }

        public List<Problematica> recuperarProblematicasSinSolucion()
        {
            SolucionDAO solucion = new SolucionDAO();
            return solucion.recuperarProblematicasSinSolucion();
        }

        public bool registrarSolucion(SolucionProblematica solucionNueva)
        {
            SolucionDAO solucionDAO = new SolucionDAO();
            return solucionDAO.registrarSolucion(solucionNueva);
        }

        public int asignarSolucion(int idProblematica)
        {
            SolucionDAO solucionDAO = new SolucionDAO();
            return solucionDAO.asignarSolucion(idProblematica);
        }

        public List<ConsultaComentarios> obtenerComentarios(int idTutor)
        {
            ComentarioDAO comentarioDAO = new ComentarioDAO();
            return comentarioDAO.obtenerComentarios(idTutor);
        }

        public bool realizarCambiosComentarios(ComentarioGeneral comentarioEditar)
        {
            ComentarioDAO comentarioDAO = new ComentarioDAO();
            return comentarioDAO.realizarCambiosComentarios(comentarioEditar);
        }

        public List<HorarioTutorado> recuperarTutoradosPorTutor(int idTutor)
        {
            TutoradoSesionDAO tutoradoSesionDAO = new TutoradoSesionDAO();
            return tutoradoSesionDAO.recuperarTutoradosPorTutor(idTutor);
        }

        public List<TutoriaAcademica> obtenerSesiones()
        {
            TutoradoSesionDAO tutoradoSesionDAO = new TutoradoSesionDAO();
            return tutoradoSesionDAO.obtenerSesiones();
        }

        public int registrarHorarioSesion(HoraTutoria horario)
        {
            TutoradoSesionDAO tutoradoSesionDAO = new TutoradoSesionDAO();
            return tutoradoSesionDAO.registrarHorarioSesion(horario);
        }

        public List<ConsultaDeHorarios> obtenerHorarios()
        {
            TutoradoSesionDAO tutoradoSesionDAO = new TutoradoSesionDAO();
            return tutoradoSesionDAO.obtenerHorarios();
        }
    }
}

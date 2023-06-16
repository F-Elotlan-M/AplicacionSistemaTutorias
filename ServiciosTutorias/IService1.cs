using ServiciosTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosTutorias {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1 {

        
        [OperationContract]
        string GetData(int value);
        [OperationContract]
        List<Academico> ObtenerUsuarios();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        Mensaje Login(string correo, string password);
        [OperationContract]
        int LoginPrueba(string correo, string password);


        //metodos de SolucionDAO
        [OperationContract]
        List<Problematica> recuperarProblematicasSinSolucion();

        [OperationContract]
        bool registrarSolucion(SolucionProblematica solucionNueva);

        [OperationContract]
        int asignarSolucion(int idProblematica);

        //metodos de comentarioDAO
        [OperationContract]
        List<ConsultaComentarios> obtenerComentarios(int idTutor);
        [OperationContract]
        Boolean realizarCambiosComentarios(ComentarioGeneral comentarioEditar);

        //metodos de tutoradoDAO
        [OperationContract]
        List<HorarioTutorado> recuperarTutoradosPorTutor(int idTutor);
        [OperationContract]
        List<TutoriaAcademica> obtenerSesiones();
        [OperationContract]
        int registrarHorarioSesion(HoraTutoria horario);
        List<ConsultaDeHorarios> obtenerHorarios();

        // TODO: agregue aquí sus operaciones de servicio
    }



    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}

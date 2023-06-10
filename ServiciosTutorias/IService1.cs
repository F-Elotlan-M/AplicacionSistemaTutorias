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
        CompositeType GetDataUsingDataContract(CompositeType composite);
<<<<<<< HEAD
        [OperationContract]
        int Login(string user, string password);
=======
>>>>>>> 82ea36daeb3394d607fe0e3371fa8b926c64aea7

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

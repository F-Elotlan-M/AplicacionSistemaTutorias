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
    public class Service1 : IService1 {
        public string GetData(int value) {
            return string.Format("You entered: {0}", value);
        }

<<<<<<< HEAD

=======
<<<<<<< HEAD
>>>>>>> 4779afe6bc608ade82119819ddf99d251231c43a
        public int Login(string user, string password)
        {
            if (user == "elotlan" && password == "123456")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

<<<<<<< HEAD

=======
=======
>>>>>>> 82ea36daeb3394d607fe0e3371fa8b926c64aea7
>>>>>>> 4779afe6bc608ade82119819ddf99d251231c43a
        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD

=======
>>>>>>> 82ea36daeb3394d607fe0e3371fa8b926c64aea7
>>>>>>> 4779afe6bc608ade82119819ddf99d251231c43a
    }
}

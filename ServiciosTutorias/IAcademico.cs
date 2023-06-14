using ServiciosTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosTutorias
{
    [ServiceContract]
    public interface IAcademico
    {
        [OperationContract]
        int registrarProfesor(Academico profesorNuevo);
        [OperationContract]
        List<Rol> recuperarRoles();
    }
}

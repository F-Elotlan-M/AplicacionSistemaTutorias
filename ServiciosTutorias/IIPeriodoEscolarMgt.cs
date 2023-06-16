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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IIPeriodoEscolarMgt" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IIPeriodoEscolarMgt
    {
        [OperationContract]
        ObservableCollection<PeriodoEscolar> ObtenerPeriodosEscolares();
    }
}

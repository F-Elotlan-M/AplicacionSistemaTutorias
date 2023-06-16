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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "IPeriodoEscolarMgt" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione IPeriodoEscolarMgt.svc o IPeriodoEscolarMgt.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class IPeriodoEscolarMgt : IIPeriodoEscolarMgt
    {

        public ObservableCollection<PeriodoEscolar> ObtenerPeriodosEscolares()
        {
            return PeriodoEscolarDAO.ObtenerPeriodosEscolares();
        }
    }
}

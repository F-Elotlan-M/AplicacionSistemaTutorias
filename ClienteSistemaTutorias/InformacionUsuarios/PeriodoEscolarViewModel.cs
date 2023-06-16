using ClienteSistemaTutorias.ServiceReferenceITutoriaAcademicaMgt;
using ClienteSistemaTutorias.ServiceReferenceIPeriodoEscolarMgt;
using ClienteSistemaTutorias.ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo
{

    internal class PeriodoEscolarViewModel
    {
        public ObservableCollection<ServiceReferenceIPeriodoEscolarMgt.PeriodoEscolar> PeriodosEscolaresDB { get; set; }

        public PeriodoEscolarViewModel()
        {
            PeriodosEscolaresDB = new ObservableCollection<ServiceReferenceIPeriodoEscolarMgt.PeriodoEscolar>();
            solicitarPeriodosEscolaresServicio();
        }

        private async void solicitarPeriodosEscolaresServicio()
        {
            var conexionServicios = new IPeriodoEscolarMgtClient();

                if (conexionServicios != null)
                {
                    ServiceReferenceIPeriodoEscolarMgt.PeriodoEscolar[] periodosEscolaresService = await conexionServicios.ObtenerPeriodosEscolaresAsync();
                    foreach (ServiceReferenceIPeriodoEscolarMgt.PeriodoEscolar periodoObtenido in periodosEscolaresService)
                    {
                        PeriodosEscolaresDB.Add(periodoObtenido);
                    }
            }
            else
            {
                PeriodosEscolaresDB = null;
            }
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo
{
    public class PeriodoEscolarDAO
    {

        public static ObservableCollection<PeriodoEscolar> ObtenerPeriodosEscolares()
        {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();

            IQueryable<PeriodoEscolar> periodosEscolarBD = from periodoEscolarQuery in conexionBD.PeriodoEscolar
                                               select periodoEscolarQuery;

            ObservableCollection<PeriodoEscolar> periodosEscolaresLista = new ObservableCollection<PeriodoEscolar>();

                foreach (PeriodoEscolar periodoEscolar in periodosEscolarBD)
                {
                    PeriodoEscolar periodo = new PeriodoEscolar()
                    {
                        idPeriodoEscolar = periodoEscolar.idPeriodoEscolar,
                        titulo = periodoEscolar.titulo,
                        FechaInicio = periodoEscolar.FechaInicio,
                        FechaFin = periodoEscolar.FechaFin,
                        fechasTutorias = periodoEscolar.fechasTutorias
                    };

                    periodosEscolaresLista.Add(periodo);
                }

            return periodosEscolaresLista;
        }

        public static DataClassesTutoriasDBDataContext getConnection()
        {
            return new DataClassesTutoriasDBDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["TutoriasBDConnectionString"].ConnectionString);
        }
    }
}
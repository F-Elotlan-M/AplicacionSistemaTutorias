using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace ServiciosTutorias.Modelo
{
    public class SolucionDAO
    {

        public List<Problematica> recuperarProblematicasSinSolucion()
        {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            List<Problematica> problematicas = new List<Problematica>();
            var consulta = from consultaProblematica in conexionBD.Problematica
                           where consultaProblematica.idSolucionProblematica == null
                           select consultaProblematica;
            if(consulta != null)
            {
                foreach (var agregar in consulta)
                {
                    if (agregar != null)
                    {
                        Problematica problematicaIterable = new Problematica()
                        {
                            idProblematica = agregar.idProblematica,
                            descripcion = agregar.descripcion,
                            numeroIncidencias = agregar.numeroIncidencias,
                            idReporteTutoriaAcademica = agregar.idReporteTutoriaAcademica,
                            idClasificacionProblematica = agregar.idClasificacionProblematica,
                            idSolucionProblematica = agregar.idSolucionProblematica,
                            nombre = agregar.nombre
                        };
                        problematicas.Add(problematicaIterable);
                    }
                }
                return problematicas;
            }
            else
            {
                return null;
            }
        }

        public Boolean registrarSolucion(SolucionProblematica solucionNueva)
        {
            try
            {
                DataClassesTutoriasDBDataContext conexionBD = getConnection();
                if (conexionBD != null)
                {
                    var solucionProblematica = new SolucionProblematica()
                    {
                        descripcion = solucionNueva.descripcion,
                        idJefeProgramaEducativo = solucionNueva.idJefeProgramaEducativo,
                        idProblematica = solucionNueva.idProblematica
                    };
                    conexionBD.SolucionProblematica.InsertOnSubmit(solucionProblematica);
                    conexionBD.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {
                return false;
                Console.WriteLine(ex);
            }
            
        }

        public int asignarSolucion(int idProblematica)
        {
            DataClassesTutoriasDBDataContext conexionBD = getConnection();
            var consulta = (from consultaProblematica in conexionBD.Problematica
                            join consultaSolucion in conexionBD.SolucionProblematica on consultaProblematica.idProblematica equals consultaSolucion.idProblematica
                            where consultaProblematica.idProblematica == idProblematica && consultaProblematica.idProblematica == consultaProblematica.idProblematica
                            select consultaSolucion).FirstOrDefault();
            if(conexionBD != null)
            {
                if (consulta != null)
                {
                    int idSolucion = consulta.idSolucionProblematica;
                    var query = (from consultarProblematica in conexionBD.Problematica
                                    where consultarProblematica.idProblematica == idProblematica
                                    select consultarProblematica).FirstOrDefault();
                    if(query != null)
                    {
                        query.idSolucionProblematica = consulta.idSolucionProblematica;
                        conexionBD.SubmitChanges();
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 2;
                }
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
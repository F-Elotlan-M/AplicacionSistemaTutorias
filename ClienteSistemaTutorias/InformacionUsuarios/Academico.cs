using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.InformacionUsuarios
{
    internal class Academico
    {
        int idAcademico { get; set; }
        string nombre { get; set; }
        string apellidoPaterno { get; set; }
        string apellidoMaterno { get; set; }
        string correoInstitucional { get; set; }
        string numPersonal { get; set; }
        string password { get; set; }
        int idRol { get; set; }
    }
}

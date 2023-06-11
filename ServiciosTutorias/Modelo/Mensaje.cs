using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTutorias.Modelo
{
    public class Mensaje
    {
        public Boolean error { get; set; }
        public string mensajeTexto { get; set; }

        public Academico usuarioAutenticado { get; set; }
    }
}
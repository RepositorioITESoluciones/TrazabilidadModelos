using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trazabilidad.Entidades
{
    public class Bitacora
    {
        public int idBitacora { get; set; }
        public int idEtapaxProceso { get; set; }
        public string Proceso { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }


    }
}
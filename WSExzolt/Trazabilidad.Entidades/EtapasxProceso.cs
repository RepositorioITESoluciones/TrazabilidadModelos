using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trazabilidad.Entidades
{
    public class EtapasxProceso
    {
        public int idEtapaxProceso { get; set; }
        public int idProcesoxModelo { get; set; }
        public int idEtapa { get; set; }
        public string descripcion { get; set; }

    }
}
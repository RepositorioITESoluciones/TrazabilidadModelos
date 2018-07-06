using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSModelosTrazabilidad.Models
{
    public class ProcesosxModelo
    {
        public int idProcesoxModelo { get; set; }
        public int idModelo { get; set; }
        public int idProceso { get; set; }
        public string descripcion { get; set; }
        
    }
}
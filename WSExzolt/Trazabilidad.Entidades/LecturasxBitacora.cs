using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trazabilidad.Entidades
{
    public class LecturasxBitacora
    {
        public int idLecturasxBitacora { get; set; }
        public int idBitacora { get; set; }
        public int idSensor { get; set; }
        public string DesSensor { get; set; }
        public int idModulo { get; set; }
        public string DesModulo { get; set; }
        public double valor { get; set; }
        public string acronimo { get; set; }
        public string DesEtapa { get; set; }

    }
    
}
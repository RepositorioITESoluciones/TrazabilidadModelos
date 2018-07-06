using System;
using System.Web.Services;
using Exzolt.Negocio;
using Trazabilidad.Entidades;
using System.Collections.Generic;

[System.Web.Script.Services.ScriptService]

public class WSExzolt : System.Web.Services.WebService
{
    public WSExzolt() { }

    // Clases Instanciadas
    readonly TrazabilidadModulos metodos = new TrazabilidadModulos();

    #region Get
    [WebMethod]
    public List<LecturasxBitacora> OptenerLecturas(int idBitacora)
    {
        return metodos.lecturas(idBitacora);
    }
    [WebMethod]
    public List<Bitacora> OptenerBitacora(int idBitacora)
    {
        return metodos.Bitacora(idBitacora);
    }
    #endregion
    #region Post
    [WebMethod]
    public bool PostLectura(string lectura)
    {
        return metodos.insertaLectura(lectura);
    }
    #endregion

}


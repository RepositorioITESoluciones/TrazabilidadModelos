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
    public List<LecturasxBitacora> OptenerLecturas(int idModelo)
    {
        return metodos.lecturas(idModelo);
    }
    [WebMethod]
    public List<Bitacora> OptenerBitacora(int idModelo)
    {
        return metodos.Bitacora(idModelo);
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


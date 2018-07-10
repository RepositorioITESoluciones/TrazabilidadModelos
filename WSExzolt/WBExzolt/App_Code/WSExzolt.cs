using System;
using System.Web.Services;
using Exzolt.Negocio;
using Trazabilidad.Entidades;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
    [WebMethod]
    public int PostBitacora(int idEtaxPro, int bandera)
    {
        return metodos.insertaBitacora(idEtaxPro, bandera);
    }
    #endregion
    #region Update
    [WebMethod]
    public bool UpdateBitacora(int idBitacora)
    {
        return metodos.UpdateBitacora(idBitacora);
    }
    #endregion
}


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


        StringBuilder sb = new StringBuilder();
        sb.Append("Hola Mario");
        File.AppendAllText(@"C:\Users\Mario\Desktop\Log\" + "log.txt", sb.ToString());
        sb.Clear();

        //File.AppendAllText(@"C:\Users\Mario\Desktop\Log" + "log.txt", "entre a postLectura");
        return metodos.insertaLectura(lectura);
    }
    [WebMethod]
    public int PostBitacora(int idEtaxPro, int bandera)
    {
        return metodos.insertaBitacora(idEtaxPro, bandera);
    }

    #endregion

}


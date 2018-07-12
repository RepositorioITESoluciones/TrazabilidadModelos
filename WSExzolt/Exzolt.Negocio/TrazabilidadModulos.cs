using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Exzolt.Datos;
using Trazabilidad.Entidades;

namespace Exzolt.Negocio
{
    
    public class TrazabilidadModulos
    {
        ConvertJsonToDataset convertJson = new ConvertJsonToDataset();
        DTrazabilidad metodoDatos = new DTrazabilidad();
        public bool insertaLectura(string lecturas)
        {
            DataSet Registros = new DataSet();
            Registros=convertJson.ConvertJsonStringToDataSet(lecturas);
            return metodoDatos.insertaLecturas(Registros); ;
        }

        public int insertaBitacora(int idEtaxPro, int bandera, int idModelo)
        {
            return metodoDatos.insertaBitacora(idEtaxPro, bandera, idModelo);
        }

        public bool UpdateBitacora(int idBitacora)
        {
            return metodoDatos.UpdateBitacora(idBitacora);
        }


        public List<LecturasxBitacora> lecturas(int idModelo)
        {
            List<LecturasxBitacora> listlecturas = new List<LecturasxBitacora>();
            DataTable dtLecturas;
            dtLecturas=metodoDatos.Lecturas(idModelo);

            foreach (DataRow row in dtLecturas.Rows)
            {
                LecturasxBitacora parametros = new LecturasxBitacora();

                parametros.DesModulo = row["Modulo"].ToString();
                parametros.DesSensor = row["Sensor"].ToString();
                parametros.valor = Convert.ToDouble(row["Lectura"].ToString());
                parametros.acronimo = row["Unidad"].ToString();

                listlecturas.Add(parametros);
            }            
            return listlecturas;
        }

        public List<Bitacora> Bitacora(int idModelo)
        {
            List<Bitacora> listlecturas = new List<Bitacora>();
            DataTable dtBitacora;
            dtBitacora = metodoDatos.Bitacora(idModelo);

            foreach (DataRow row in dtBitacora.Rows)
            {
                Bitacora parametros = new Bitacora();

                parametros.Proceso = row["Proceso"].ToString();
                parametros.Etapa = row["Etapas"].ToString();
                parametros.fechaInicio = row["fechaInicio"].ToString();
                if(row["fechaFin"].ToString() != "") {
                    parametros.fechaFin = row["fechaFin"].ToString();
                }
                else
                {
                    parametros.fechaFin = "---";
                }
                

                listlecturas.Add(parametros);
            }
            return listlecturas;
        }

    }
}

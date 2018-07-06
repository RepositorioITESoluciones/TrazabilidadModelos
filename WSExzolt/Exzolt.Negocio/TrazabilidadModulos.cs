﻿using System;
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

            metodoDatos.insertaLecturas(Registros);
            return true;
        }


        public List<LecturasxBitacora> lecturas(int idBitacora)
        {
            List<LecturasxBitacora> listlecturas = new List<LecturasxBitacora>();
            DataTable dtLecturas;
            dtLecturas=metodoDatos.Lecturas(idBitacora);

            foreach (DataRow row in dtLecturas.Rows)
            {
                LecturasxBitacora parametros = new LecturasxBitacora();

                parametros.DesEtapa = row["Etapa"].ToString();
                parametros.DesModulo = row["Modulo"].ToString();
                parametros.DesSensor = row["Sensor"].ToString();
                parametros.valor = Convert.ToDouble(row["Lectura"].ToString());
                parametros.acronimo = row["acronimo"].ToString();

                listlecturas.Add(parametros);
            }            
            return listlecturas;
        }

        public List<Bitacora> Bitacora(int idBitacora)
        {
            List<Bitacora> listlecturas = new List<Bitacora>();
            DataTable dtBitacora;
            dtBitacora = metodoDatos.Bitacora(idBitacora);

            foreach (DataRow row in dtBitacora.Rows)
            {
                Bitacora parametros = new Bitacora();

                parametros.Proceso = row["Proceso"].ToString();
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
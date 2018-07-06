using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Exzolt.Framework.AccesoDatos;
using Trazabilidad.Entidades;

namespace Exzolt.Datos
{
    public class DTrazabilidad
    {
        
        public bool insertaLecturas(DataSet regitros)
        {
            SqlConnection connection = null;
            SqlDataReader consulta;
            int idBitacora = 0;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    foreach (DataRow row in regitros.Tables["informacion"].Rows)
                    {
                        idBitacora = Convert.ToInt32(row["idBitacora"].ToString());
                    }


                    foreach (DataRow item in regitros.Tables["Lecturas"].Rows)
                    {
                        connection.Open();
                        consulta = Ejecuta.ConsultaConRetorno(connection, "INSERT INTO ModelosTrazabilidad.LecturasxBitacora VALUES ("+ idBitacora + ","+ item["idSensor"].ToString() + ","+ item["idModulo"].ToString() + ","+ item["valor"].ToString() + ")");
                        connection.Close();
                    }
                    

                }
                return true;

            }
            catch(Exception ex)
            {
                return false;
                throw ex;                
            }
        }

        public DataTable Lecturas(int idBitacora)
        {
            DataTable dtLecturas = new DataTable();
            SqlConnection connection = null;
            SqlDataReader consulta;
            try{
                using (connection = Conexion.ObtieneConexion("ConexionBD")){
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT EP.descripcion Etapa, M.descripcion Modulo, S.descripcion Sensor,"
                                                                    + " valor Lectura, u.acronimo"
                                                                    + " FROM ModelosTrazabilidad.LecturasxBitacora LB,"
                                                                    + " ModelosTrazabilidad.Bitacora B, ModelosTrazabilidad.Sensores S,"
                                                                    + " ModelosTrazabilidad.Modulos M, ModelosTrazabilidad.Unidades U,"
                                                                    + " ModelosTrazabilidad.EtapasxProceso EP"
                                                                    + " WHERE B.idBitacora = LB.idBitacora"
                                                                    + " AND S.idSensor = LB.idSensor"
                                                                    + " AND M.idModulo = LB.idModulo"
                                                                    + " AND U.idUnidad = S.idUnidad"
                                                                    + " AND EP.idEtapaxProceso = B.idEtapaxProceso"
                                                                    + " AND b.idBitacora = "+ idBitacora
                                                                    + " AND B.fechaFin IS NULL; ");
                    dtLecturas.Load(consulta);
                    connection.Close();

                }


            }
            catch
            {

            }
            return dtLecturas;
        }

        public DataTable Bitacora(int idBitacora)
        {
            DataTable dtBitacora = new DataTable();
            SqlConnection connection = null;
            SqlDataReader consulta;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT distinct PM.descripcion Proceso, B.fechaInicio, B.fechaFin"
                                            + " FROM ModelosTrazabilidad.LecturasxBitacora LB,"
                                            + " ModelosTrazabilidad.Bitacora B, ModelosTrazabilidad.Sensores S,"
                                            + " ModelosTrazabilidad.Modulos M, ModelosTrazabilidad.Unidades U,"
                                            + " ModelosTrazabilidad.EtapasxProceso EP, ModelosTrazabilidad.ProcesosxModelo PM"
                                            + " WHERE B.idBitacora = LB.idBitacora"
                                            + " AND S.idSensor = LB.idSensor"
                                            + " AND M.idModulo = LB.idModulo"
                                            + " AND U.idUnidad = S.idUnidad"
                                            + " AND EP.idEtapaxProceso = B.idEtapaxProceso"
                                            + " AND PM.idProcesoxModelo = EP.idProcesoxModelo"
                                            + " AND B.idBitacora = "+ idBitacora);
                    dtBitacora.Load(consulta);
                    connection.Close();

                }

                return dtBitacora;
            }
            catch
            {
                return dtBitacora;
            }
            
        }


    }
}

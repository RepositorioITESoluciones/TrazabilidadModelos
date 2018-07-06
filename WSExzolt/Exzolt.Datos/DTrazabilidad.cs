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

        public int insertaBitacora(int idEtaxPro, int bandera)
        {
            SqlConnection connection = null;
            SqlDataReader consulta;
            DataTable dt = new DataTable();
            int idBitacora = 0;
            int resultado = 0;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {

                    if (idEtaxPro==1 && bandera == 1) {

                        connection.Open();
                        consulta = Ejecuta.ConsultaConRetorno(connection, "UPDATE ModelosTrazabilidad.Bitacora SET bandera = 1");
                        connection.Close();                       

                    }
                        connection.Open();
                        consulta = Ejecuta.ConsultaConRetorno(connection, "INSERT INTO ModelosTrazabilidad.Bitacora OUTPUT Inserted.idBitacora VALUES(" + idEtaxPro + ",'" + DateTime.Now.ToString("dd/mm/yyyy HH:mm:ss") + "',NULL,0);");
                        dt.Load(consulta);
                        connection.Close();

                    foreach (DataRow row in dt.Rows) { resultado = Convert.ToInt32(row["idBitacora"].ToString()); }

                }
                return resultado;

            }
            catch (Exception ex)
            {
                return resultado;
                throw ex;
            }
            
        }

        public DataTable Lecturas(int idModelo)
        {
            DataTable dtLecturas = new DataTable();
            SqlConnection connection = null;
            SqlDataReader consulta;
            try{
                using (connection = Conexion.ObtieneConexion("ConexionBD")){
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT distinct  M.descripcion Modulo, S.descripcion Sensor,"
                                                                        + " valor Lectura, u.acronimo Unidad"
                                                                        + " FROM ModelosTrazabilidad.LecturasxBitacora LB,"
                                                                        + " ModelosTrazabilidad.Bitacora B, ModelosTrazabilidad.Sensores S,"
                                                                        + " ModelosTrazabilidad.Modulos M, ModelosTrazabilidad.Unidades U,"
                                                                        + " ModelosTrazabilidad.Modelos MO,"
                                                                        + " ModelosTrazabilidad.EtapasxProceso EP, ModelosTrazabilidad.ProcesosxModelo PM"
                                                                        + " WHERE B.idBitacora = LB.idBitacora"
                                                                        + " AND S.idSensor = LB.idSensor"
                                                                        + " AND M.idModulo = LB.idModulo"
                                                                        + " AND U.idUnidad = S.idUnidad"
                                                                        + " AND EP.idEtapaxProceso = B.idEtapaxProceso"
                                                                        + " AND PM.idProcesoxModelo = EP.idProcesoxModelo"
                                                                        + " AND MO.idModelo = PM.idModelo"
                                                                        + " AND MO.idModelo = "+idModelo
                                                                        + " AND B.bandera = 0");
                    dtLecturas.Load(consulta);
                    connection.Close();

                }


            }
            catch
            {

            }
            return dtLecturas;
        }

        public DataTable Bitacora(int idModelo)
        {
            DataTable dtBitacora = new DataTable();
            SqlConnection connection = null;
            SqlDataReader consulta;
            try
            {
                using (connection = Conexion.ObtieneConexion("ConexionBD"))
                {
                    connection.Open();
                    consulta = Ejecuta.ConsultaConRetorno(connection, "SELECT distinct pm.descripcion Proceso, EP.descripcion Etapas,B.fechaInicio, B.fechaFin" 
                                                                        + " FROM ModelosTrazabilidad.LecturasxBitacora LB,"
                                                                        + " ModelosTrazabilidad.Bitacora B, ModelosTrazabilidad.Sensores S,"
                                                                        + " ModelosTrazabilidad.Modulos M, ModelosTrazabilidad.Unidades U,"
                                                                        + " ModelosTrazabilidad.Modelos MO,"
                                                                        + " ModelosTrazabilidad.EtapasxProceso EP, ModelosTrazabilidad.ProcesosxModelo PM"
                                                                        + " WHERE B.idBitacora = LB.idBitacora"
                                                                        + " AND S.idSensor = LB.idSensor"
                                                                        + " AND M.idModulo = LB.idModulo"
                                                                        + " AND U.idUnidad = S.idUnidad"
                                                                        + " AND EP.idEtapaxProceso = B.idEtapaxProceso"
                                                                        + " AND PM.idProcesoxModelo = EP.idProcesoxModelo"
                                                                        + " AND MO.idModelo = PM.idModelo"
                                                                        + " AND MO.idModelo = "+idModelo 
                                                                        + " AND B.bandera = 0;");
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

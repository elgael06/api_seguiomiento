using api_seguimiento.objetos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_seguimiento.Controllers
{
    public class Manejo_fechasController : ApiController
    {
        public static ConexionesSQL sql_izagar = new ConexionesSQL();
        //abre la conexion a sql
        public SqlConnection conexion_web = sql_izagar.Web();
        public SqlConnection conexion_scoi = sql_izagar.Scoi();
        public SqlDataReader lector;
        // POST api/<controller>
        public Diferencia_semana_anio_iso PostDiferencia_semana_anio_iso(string f1, string f2)
        {
            Diferencia_semana_anio_iso fecha = new Diferencia_semana_anio_iso();
            SqlCommand comando = new SqlCommand("[retornar_diferencia_semana_anio_iso] '" + f1 + "','" + f2 + "'", conexion_web);
            try
            {
                conexion_web.Open();
                lector = comando.ExecuteReader();
                lector.Read();
                fecha.lunes = (string)lector["Lunes"];
                fecha.domingo = (string)lector["Domingo"];
                fecha.semana_inicio = int.Parse(lector["Semana_inicio"].ToString());
                fecha.semana_termino = int.Parse(lector["Semana_termino"].ToString());
                fecha.anio_inicio = int.Parse(lector["Anio_inicio"].ToString());
                fecha.anio_termino = int.Parse(lector["Anio_termino"].ToString());
                fecha.semanas = int.Parse(lector["semanas"].ToString());
            }
            catch { return fecha; }
            conexion_web.Close();
            return fecha;
        }
        public Diferencia_semana_anio_iso PostRetornar_fecha_por_semana_de_anio(int si,int st)
        {
            Diferencia_semana_anio_iso fecha = new Diferencia_semana_anio_iso();
            SqlCommand comando = new SqlCommand("retornar_fecha_por_semana_de_anio " + si + "," + st , conexion_scoi);
            try
            {
                conexion_scoi.Open();
                lector = comando.ExecuteReader();
                lector.Read();
                fecha.lunes = (string)lector["Lunes"];
                fecha.domingo = (string)lector["Domingo"];
                fecha.semana_inicio = int.Parse(lector["Semana_inicio"].ToString());
                fecha.semana_termino = int.Parse(lector["Semana_termino"].ToString());
                fecha.anio_inicio = int.Parse(lector["Anio_inicio"].ToString());
                fecha.anio_termino = int.Parse(lector["Anio_termino"].ToString());
                fecha.semanas = int.Parse(lector["semanas"].ToString());
            }
            catch { return fecha; }
            conexion_scoi.Close();
            return fecha;
        }
    }
}
using api_seguimiento.Models.comparativo_resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_seguimiento.Models.Estado_de_resultados.Periodo
{
    public class PeriodoSemanaAnio : Estado_de_resultados_total
    {
        public int Semana { get; set; }
        public Estado_de_resultados_total UTILIDAD_EN_OPERACION { get; set; }

        public PeriodoSemanaAnio(int semana,List<Resultado> lista_movimientos) {
            Semana= semana;
            UTILIDAD_EN_OPERACION = new Estado_de_resultados_total();
            ObtenerTotales(lista_movimientos);
        }
        private void ObtenerTotales(List<Resultado> lista_movimientos)
        {
            foreach (Resultado movimineto in lista_movimientos)
            {
                Total_Costo += movimineto.Total_Costo;
                Total_Precio_venta += movimineto.Total_Precio_venta;
            }
            UTILIDAD_EN_OPERACION = ObtenerOperacionesSemana(lista_movimientos);
        }
        private Estado_de_resultados_total ObtenerOperacionesSemana(List<Resultado> lista)
        {
            Estado_de_resultados_total Ventas_netas = new Estado_de_resultados_total();
            Estado_de_resultados_total costo_netas = new Estado_de_resultados_total();

            List<Resultado> lista_ventas_netas = lista.Where(e => e.Concepto == "VENTAS NETAS").ToList();
            List<Resultado> lista_costo_netas = lista.Where(e => e.Concepto == "COSTO DE VENTAS").ToList();

            foreach (Resultado e in lista_ventas_netas)
            {
                Ventas_netas.Total_Costo += e.Total_Costo;
                Ventas_netas.Total_Precio_venta += e.Total_Precio_venta;
            }
            foreach (Resultado e in lista_costo_netas)
            {
                costo_netas.Total_Costo += e.Total_Costo;
                costo_netas.Total_Precio_venta += e.Total_Precio_venta;
            }

            return new Estado_de_resultados_total
            {
                Total_Costo = Redondear_a_dos_decimales(Ventas_netas.Total_Costo + costo_netas.Total_Costo),
                Total_Precio_venta = Redondear_a_dos_decimales(Ventas_netas.Total_Precio_venta + costo_netas.Total_Precio_venta)
            };
        }
        private double Redondear_a_dos_decimales(double dato)
        {
            return Math.Round(dato * 100) / 100;
        }
    }
}
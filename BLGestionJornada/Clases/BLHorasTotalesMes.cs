using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLGestionJornada.Comun;
using BLGestionJornada.Entidades;

namespace BLGestionJornada.Clases
{
    public class BLHorasTotalesMes
    {
        public EntHorasTotalesMes ObtenerHorasMes(int pe_intIdMes)
        {
            EntHorasTotalesMes vl_entSalida = new EntHorasTotalesMes();
            try
            {
                BLComun vl_BLComun = new BLComun();
                string[] vl_arrHorasTotalesMes = vl_BLComun.ObtenerDatos(vl_BLComun.ObtenerValorConfig("RUTA_HORAS_TOTALES_MES"));
                if (vl_arrHorasTotalesMes != null)
                {
                    foreach (string vl_strHorasMes in vl_arrHorasTotalesMes)
                    {
                        string[] vl_strItemHorasMes = vl_strHorasMes.Split('|');
                        if (int.Parse(vl_strItemHorasMes[0].ToString())==pe_intIdMes)
                        {
                            vl_entSalida.Mes = pe_intIdMes;
                            vl_entSalida.HorasTotales = int.Parse(vl_strItemHorasMes[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vl_entSalida;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLGestionJornada.Comun;
using BLGestionJornada.Entidades;

namespace BLGestionJornada.Clases
{
    public class BLTipoHorario
    {
        public EntTipoHorario ObtenerTipoHorario(DateTime pe_datHoy)
        {
            List<EntTipoHorario> vl_LstSalida = new List<EntTipoHorario>();

            try
            {
                BLComun vl_BLComun = new BLComun();
                string[] vl_arrTipoHorario = vl_BLComun.ObtenerDatos(vl_BLComun.ObtenerValorConfig("RUTA_TIPO_HORARIO"));
                if (vl_arrTipoHorario != null)
                {
                    foreach(string vl_strTipo in vl_arrTipoHorario)
                    {
                        string[] vl_strItemTipo = vl_strTipo.Split('|');
                        vl_LstSalida.Add(new EntTipoHorario
                        {
                            Tipo = (BLComun.TipoHorario) int.Parse(vl_strItemTipo[0]),
                            FechaInicio = Convert.ToDateTime(vl_strItemTipo[1]),
                            FechaFin = Convert.ToDateTime(vl_strItemTipo[2])
                        });                        
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            EntTipoHorario vl_EntTipoHorario = vl_LstSalida.First(a => pe_datHoy >= a.FechaInicio && pe_datHoy <= a.FechaFin);

            return vl_EntTipoHorario;
        }

    }
}

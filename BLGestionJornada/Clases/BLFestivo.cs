using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLGestionJornada.Comun;
using BLGestionJornada.Entidades;

namespace BLGestionJornada.Clases
{
    public class BLFestivo
    {

        public List<EntFestivo> ObtenerFestivos(int pe_intMes)
        {
            List<EntFestivo> vl_LstFestivos = new List<EntFestivo>();

            try
            {
                BLComun vl_BLComun = new BLComun();
                string[] vl_arrFestivos = vl_BLComun.ObtenerDatos(vl_BLComun.ObtenerValorConfig("RUTA_FESTIVOS"));
                if (vl_LstFestivos != null)
                {
                    foreach(DateTime vl_Fecha in  Array.ConvertAll(vl_arrFestivos, DateTime.Parse).Where(a=>a.Month==pe_intMes))
                    {
                        vl_LstFestivos.Add(new EntFestivo { Fecha = vl_Fecha });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            

            return vl_LstFestivos;
        }

    }
}

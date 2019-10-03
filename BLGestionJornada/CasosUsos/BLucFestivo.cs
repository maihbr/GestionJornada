using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLGestionJornada;
using BLGestionJornada.Clases;
using BLGestionJornada.Entidades;

namespace BLGestionJornada.CasosUsos
{
    public class BLucFestivo
    {
        public List<EntFestivo> ObtenerFestivosMes(int pe_intMes)
        {
            List<EntFestivo> vl_LstFestivos = new List<EntFestivo>();

            BLFestivo vl_BLFestivo = new BLFestivo();

            try
            {
                vl_LstFestivos = vl_BLFestivo.ObtenerFestivos(pe_intMes);
            }
            catch (Exception ex)
            {
                throw ex ;
            }

            return vl_LstFestivos;
        }
    }
}

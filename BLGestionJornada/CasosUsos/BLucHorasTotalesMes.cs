using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLGestionJornada.Clases;
using BLGestionJornada.Entidades;

namespace BLGestionJornada.CasosUsos
{
    public class BLucHorasTotalesMes
    {
        public int ObtenerHorasMes(int pe_intMes)
        {
            int vl_intSalida = 0;

            try
            {
                BLHorasTotalesMes vl_BLHorasTotalesMes = new BLHorasTotalesMes();
                vl_intSalida = vl_BLHorasTotalesMes.ObtenerHorasMes(pe_intMes).HorasTotales;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vl_intSalida;

        }
    }
}

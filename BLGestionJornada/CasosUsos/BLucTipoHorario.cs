using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLGestionJornada.Clases;
using BLGestionJornada.Comun;
using BLGestionJornada.Entidades;

namespace BLGestionJornada.CasosUsos
{
    public class BLucTipoHorario
    {
        public static BLComun.TipoHorario ObtenerTipoHorario(DateTime pe_datHoy)
        {
            BLTipoHorario vl_BLTipoHorario = new BLTipoHorario();
            EntTipoHorario vl_EntTipoHorario = null;

            try
            {
                vl_EntTipoHorario = vl_BLTipoHorario.ObtenerTipoHorario(pe_datHoy);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vl_EntTipoHorario.Tipo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLGestionJornada.Entidades;
using BLGestionJornada.Clases;
using BLGestionJornada.Comun;

namespace BLGestionJornada.CasosUsos
{
    public class BLucHorario
    {
        public static List<EntHorario> ObtenerHorario(BLComun.TipoHorario pe_TipoHorario)
        {
            List<EntHorario> vl_HorarioSemanal = new List<EntHorario>();

            try
            {
                BLHorario vl_BLHorario = new BLHorario();
                vl_HorarioSemanal = vl_BLHorario.ObtenerHorario(pe_TipoHorario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vl_HorarioSemanal;

        }
    }
}

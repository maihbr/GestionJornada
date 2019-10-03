using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLGestionJornada.Comun;
using BLGestionJornada.Entidades;

namespace BLGestionJornada.Clases
{
    public class BLHorario
    {

        public List<EntHorario> ObtenerHorario(BLComun.TipoHorario pe_TipoHorario)
        {
            List<EntHorario> vl_EntSalida = new List<EntHorario>();

            try
            {
                BLComun vl_BLComun = new BLComun();
                string[] vl_arrHorarios = (pe_TipoHorario==BLComun.TipoHorario.Invierno)? vl_BLComun.ObtenerDatos(vl_BLComun.ObtenerValorConfig("RUTA_HORARIO")): vl_BLComun.ObtenerDatos(vl_BLComun.ObtenerValorConfig("RUTA_HORARIO_VERANO"));

                if (vl_arrHorarios != null)
                {

                    TimeSpan? vl_tsHoraEntradaManana;
                    TimeSpan? vl_tsHoraSalidaManana;
                    TimeSpan? vl_tsHoraEntradaTarde;
                    TimeSpan? vl_tsHoraSalidaTarde;

                    foreach(string vl_Horarios in vl_arrHorarios)
                    {
                        vl_tsHoraEntradaManana = null;
                        vl_tsHoraSalidaManana = null;
                        vl_tsHoraEntradaTarde = null;
                        vl_tsHoraSalidaTarde = null;

                        string[] vl_arrItems = vl_Horarios.Split('|');

                        if(vl_arrItems[1] != "null")
                        {
                            vl_tsHoraEntradaManana = TimeSpan.Parse(vl_arrItems[1]);
                        }

                        if (vl_arrItems[2] != "null")
                        {
                            vl_tsHoraSalidaManana = TimeSpan.Parse(vl_arrItems[2]);
                        }

                        if (vl_arrItems[3] != "null")
                        {
                            vl_tsHoraEntradaTarde = TimeSpan.Parse(vl_arrItems[3]);
                        }

                        if (vl_arrItems[4] != "null")
                        {
                            vl_tsHoraSalidaTarde = TimeSpan.Parse(vl_arrItems[4]);
                        }


                        vl_EntSalida.Add(new EntHorario {
                            Dia = (DayOfWeek) int.Parse(vl_arrItems[0]),
                            HoraEntradaManana = vl_tsHoraEntradaManana,
                            HoraSalidaManana = vl_tsHoraSalidaManana,
                            HoraEntradaTarde = vl_tsHoraEntradaTarde,
                            HoraSalidaTarde = vl_tsHoraSalidaTarde
                        });

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return vl_EntSalida;

        }

    }
}

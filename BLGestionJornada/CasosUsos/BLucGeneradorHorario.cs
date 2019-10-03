using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLGestionJornada;
using BLGestionJornada.Clases;
using BLGestionJornada.Comun;
using BLGestionJornada.Entidades;

namespace BLGestionJornada.CasosUsos
{
    public class BLucGeneradorHorario
    {

        public List<EntHorarioDia> GenerarHorario(DateTime pe_datPrimerDiaMes,List<EntHorario> pe_LstHorarios,List<EntFestivo> pe_LstFestivos,int pe_intRango)
        {
            List<EntHorarioDia> vl_LstSalida = new List<EntHorarioDia>();

            //Siempre vamos a generar 31 dias por que despues trasaladar los datos al Excel no resulta mas sencillo

            DateTime vl_datFecha = pe_datPrimerDiaMes;
            Random vl_Randon = new Random();
            
            for (int i=0;i<=30;i++)
            {

                EntHorarioDia vl_EntHorarioDia = new EntHorarioDia();
                vl_EntHorarioDia.Fecha = vl_datFecha;
                vl_EntHorarioDia.Dia = vl_datFecha.DayOfWeek;
                vl_EntHorarioDia.DiaMes = vl_datFecha.Day;

                if (!pe_LstFestivos.Exists(a => a.Fecha == vl_datFecha) && vl_datFecha.Month==pe_datPrimerDiaMes.Month)
                {
                    #region Generar Detalle Horario
                    //Recuperamos el horario teorico
                                        

                    EntHorario vl_EntHorarioTeorico = pe_LstHorarios.First(a => a.Dia == vl_datFecha.DayOfWeek);

                    if (vl_EntHorarioTeorico.HoraEntradaManana != null)
                    {
                        vl_EntHorarioDia.HoraEntradaManana = vl_EntHorarioTeorico.HoraEntradaManana.Value.Add(TimeSpan.FromMinutes(vl_Randon.Next(0, pe_intRango)));
                    }

                    if (vl_EntHorarioTeorico.HoraSalidaManana != null)
                    {
                        vl_EntHorarioDia.HoraSalidaManana = vl_EntHorarioTeorico.HoraSalidaManana.Value.Add(TimeSpan.FromMinutes(vl_Randon.Next(0, pe_intRango)));                    
                    }

                    if (vl_EntHorarioTeorico.HoraEntradaTarde != null)
                    {
                        vl_EntHorarioDia.HoraEntradaTarde = vl_EntHorarioTeorico.HoraEntradaTarde.Value.Add(TimeSpan.FromMinutes(vl_Randon.Next(0, pe_intRango)));
                    }

                    if (vl_EntHorarioTeorico.HoraSalidaTarde != null)
                    {
                        vl_EntHorarioDia.HoraSalidaTarde = vl_EntHorarioTeorico.HoraSalidaTarde.Value.Add(TimeSpan.FromMinutes(vl_Randon.Next(0, pe_intRango)));
                    }

                    #endregion

                }

                vl_LstSalida.Add(vl_EntHorarioDia);
                vl_datFecha = vl_datFecha.AddDays(1);
            }

            return vl_LstSalida;
        }

    }
}

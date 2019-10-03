using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLGestionJornada.CasosUsos;
using BLGestionJornada.Comun;
using BLGestionJornada.Entidades;

namespace GestionJornada
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                BLComun vl_BLComun = new BLComun();
                DateTime vl_datHoy = new DateTime(2019, 11, 1); //DateTime.Now;

                List<EntHorario> vl_HorarioSemanal =  BLucHorario.ObtenerHorario(BLucTipoHorario.ObtenerTipoHorario(vl_datHoy));

                BLucHorasTotalesMes vl_BLucHorasTotalesMes = new BLucHorasTotalesMes();
                int vl_intTotalHoras = vl_BLucHorasTotalesMes.ObtenerHorasMes(vl_datHoy.Month);

                BLucFestivo vl_BLucFestivo = new BLucFestivo();
                List<EntFestivo> vl_LstFestivos = vl_BLucFestivo.ObtenerFestivosMes(vl_datHoy.Month);

                BLucGeneradorHorario vl_BLucGeneradorHorario = new BLucGeneradorHorario();
                List<EntHorarioDia> vl_LstHorarioMes = vl_BLucGeneradorHorario.GenerarHorario(vl_datHoy, vl_HorarioSemanal, vl_LstFestivos,int.Parse(vl_BLComun.ObtenerValorConfig("RANGO")));

                //Generamos el Excel.
                BLucExcel vl_BLucExcel = new BLucExcel();
                vl_BLucExcel.GuardarExcel(vl_LstHorarioMes, vl_BLComun.ObtenerValorConfig("RUTA_EXCEL"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Pie();

            

        }

       


        static void Pie()
        {
            Console.WriteLine("Pulse una tecla para finalizar :");
            Console.ReadKey();
        }

    }
}

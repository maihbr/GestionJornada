using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLGestionJornada.Comun;
using BLGestionJornada.Entidades;
using Microsoft.Office.Interop.Excel;

namespace BLGestionJornada.CasosUsos
{
    public class BLucExcel
    {

        public bool GuardarExcel(List<EntHorarioDia> pe_LstMes,string pe_strRutaFicheroExcel,int pe_intFilaInicioDetalle=14)
        {
            bool vl_boolSalida = false;

            try
            {
                Application ExcelApp = new Application();
                Workbook vl_ExcelWorKbooK = ExcelApp.Workbooks.Open(pe_strRutaFicheroExcel);
                Worksheet vl_Worksheet = vl_ExcelWorKbooK.Sheets[1];

                int vl_intFila = pe_intFilaInicioDetalle;

                foreach (EntHorarioDia vl_EntHorarioDia in pe_LstMes)
                {

                    vl_Worksheet.Cells[vl_intFila, 1] = vl_EntHorarioDia.DiaMes;


                    vl_Worksheet.Cells[vl_intFila, 2] = (vl_EntHorarioDia.HoraEntradaManana.HasValue)? vl_EntHorarioDia.HoraEntradaManana.Value.ToString():"";                    
                    vl_Worksheet.Cells[vl_intFila, 3] = (vl_EntHorarioDia.HoraSalidaManana.HasValue)? vl_EntHorarioDia.HoraSalidaManana.Value.ToString():"";
                    vl_Worksheet.Cells[vl_intFila, 5] = (vl_EntHorarioDia.HoraEntradaTarde.HasValue)? vl_EntHorarioDia.HoraEntradaTarde.Value.ToString():"";
                    vl_Worksheet.Cells[vl_intFila, 6] = (vl_EntHorarioDia.HoraSalidaTarde.HasValue)? vl_EntHorarioDia.HoraSalidaTarde.Value.ToString(): "";
                    
                      vl_intFila++;

                }


                //Ahora el pie de la firma.

                BLComun vl_BLComun = new BLComun();

                vl_intFila = int.Parse(vl_BLComun.ObtenerValorConfig("FILA_PIE_EXCEL"));
                vl_Worksheet.Cells[vl_intFila, 3] = DateTime.DaysInMonth(pe_LstMes.First().Fecha.Year, pe_LstMes.First().Fecha.Month);
                vl_Worksheet.Cells[vl_intFila, 5] = vl_BLComun.ObtenerNombreMes(pe_LstMes.First().Fecha.Month);
                vl_Worksheet.Cells[vl_intFila, 8] = pe_LstMes.First().Fecha.Year;

                //Ahora la cabecera
                vl_intFila = int.Parse(vl_BLComun.ObtenerValorConfig("FILA_CABECERA_EXCEL"));
                vl_Worksheet.Cells[vl_intFila, 5] = pe_LstMes.First().Fecha.Month;

                vl_ExcelWorKbooK.Save();

                vl_Worksheet = null;
                vl_ExcelWorKbooK.Close();
                vl_ExcelWorKbooK = null;
                ExcelApp = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return vl_boolSalida;

        }


        


    }
}

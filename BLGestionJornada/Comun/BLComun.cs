using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLGestionJornada.Comun
{
    public class BLComun
    {

        public enum TipoHorario
        {
            Invierno=1,Verano
        } 

        public string[] ObtenerDatos(string pe_strRutaFichero)
        {            
           return File.ReadAllLines(pe_strRutaFichero);            
        }

        public string ObtenerValorConfig(string pe_strClave)
        {
            return System.Configuration.ConfigurationManager.AppSettings[pe_strClave].ToString();
        }

        public string ObtenerNombreMes(int pe_intMes)
        {
            string[] Meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            return Meses[pe_intMes - 1];
        }



    }
}

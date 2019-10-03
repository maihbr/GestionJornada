using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLGestionJornada.Comun;

namespace BLGestionJornada.Entidades
{
    public class EntTipoHorario
    {
        public BLComun.TipoHorario Tipo  { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}

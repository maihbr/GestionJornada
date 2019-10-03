using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLGestionJornada.Entidades
{
    public class EntHorarioDia : EntHorario
    {
        public DateTime Fecha { get; set; }
        public int DiaMes { get; set; }
    }
}

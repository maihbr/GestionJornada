using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLGestionJornada.Entidades
{
    public class EntHorario
    {
        public DayOfWeek Dia { get; set; }
        public TimeSpan? HoraEntradaManana { get; set; }
        public TimeSpan? HoraSalidaManana { get; set; }
        public TimeSpan? HoraEntradaTarde { get; set; }
        public TimeSpan? HoraSalidaTarde { get; set; }


    }
}

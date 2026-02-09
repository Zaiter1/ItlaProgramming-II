using System;
using System.Collections.Generic;
using System.Text;

namespace P2_Tarea_MapaDeClases.Entities
{
    public class ComunityMember:Person 
    {
        public int institutionalCode { get; set; } 

        public DateTime entryDate { get; set; }

    }
}

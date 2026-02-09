using System;
using System.Collections.Generic;
using System.Text;

namespace P2_Tarea_MapaDeClases.Entities
{
    public class Employee : ComunityMember
    {
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public int SNS { get; set; }

    }
}

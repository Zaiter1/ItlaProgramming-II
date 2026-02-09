using System;
using System.Collections.Generic;
using System.Text;

namespace P2_Tarea_MapaDeClases.Entities
{
    public class Student: ComunityMember
    {
        public int StudentId { get; set; }

        public string Major { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public StudentStatus Status { get; set; }

        public DateTime ExitDate{ get; set; }
    }
    public enum StudentStatus
    {
        Active,
        Graduated,
        Suspended,
        Withdrawn
    }


}

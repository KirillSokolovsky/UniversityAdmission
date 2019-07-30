namespace UniversityAdmission.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AbiturientModel
    {
        public int Order { get; set; }
        public string Fio { get; set; }
        public int Ege { get; set; }
        public bool IsImmidiate { get; set; }
        public bool AnotherDirection { get; set; }
    }
}

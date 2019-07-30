namespace UniversityAdmission.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SpecialityModel
    {
        public string Name { get; set; }
        public string AcceptNumber { get; set; }
        public int FilterNumber { get; set; }
        public int Soglasen { get; set; }
        public List<AbiturientModel> Abiturients { get; set; } = new List<AbiturientModel>();
    }
}

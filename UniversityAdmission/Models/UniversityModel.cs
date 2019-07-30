namespace UniversityAdmission.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UniversityModel
    {
        public string Name { get; set; }

        public List<SpecialityModel> Specialities { get; set; } = new List<SpecialityModel>();
    }
}

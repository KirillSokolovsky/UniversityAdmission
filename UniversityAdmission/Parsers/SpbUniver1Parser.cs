namespace UniversityAdmission.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    public class SpbUniver1Parser
    {
        private XlsParser _xlsParser = new XlsParser();
        private Dictionary<string, string> _files = new Dictionary<string, string>();
        private string _name = "";

        public SpbUniver1Parser()
        {
            _name = "СПХФУ";
            _files.Add("БТ", @"C:\Users\Kaifat\Desktop\поступление\БТ_Бюджет.XLS");
            _files.Add("ХТА", @"C:\Users\Kaifat\Desktop\поступление\ХТА_Бюджет.XLS");
            _files.Add("ХТП", @"C:\Users\Kaifat\Desktop\поступление\ХТП_Бюджет.XLS");
        }

        public UniversityModel GetUniversityModel()
        {
            var model = new UniversityModel();

            model.Name = _name;

            foreach (var item in _files)
            {
                var sModel = new SpecialityModel { Name = item.Key};

                var vals = _xlsParser.Parse(item.Value, 11);

                sModel.AcceptNumber = vals[4][0];

                var order = 0;
                for (int i = 7; i < vals.Count; i++)
                {
                    var fio = vals[i][1];
                    if (string.IsNullOrEmpty(fio)) continue;

                    var abit = new AbiturientModel
                    {
                        Order = ++order,
                        Fio = fio,
                        Ege = int.Parse(vals[i][2]),
                        IsImmidiate = !string.IsNullOrEmpty(vals[i][9]),
                        AnotherDirection = !string.IsNullOrEmpty(vals[i][10])
                    };

                    sModel.Abiturients.Add(abit);
                }
                model.Specialities.Add(sModel);
            }

            return model;
        }
    }
}

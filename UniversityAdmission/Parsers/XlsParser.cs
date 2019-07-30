namespace UniversityAdmission.Parsers
{
    using ExcelDataReader;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class XlsParser
    {
        public List<List<string>> Parse(string filePath, int columnsCount)
        {
            var rows = new List<List<string>>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            var values = new List<string>();
                            for (int x = 0; x < columnsCount; x++)
                            {
                                values.Add(reader.GetString(x));
                            }
                            rows.Add(values);
                        }
                    } while (reader.NextResult());
                }
            }

            return rows;
        }
    }
}

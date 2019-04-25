using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalSupports.Models
{
    public class ExcelFile
    {
        public static ExcelPackage GenerateExcelFile<T>(IEnumerable<T> ds)
        {
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add(nameof(T));

            List<System.Reflection.PropertyInfo> typeProps = typeof(T).GetProperties().ToList();
            foreach (T elem in ds)
            {
                int i = ds.ToList().IndexOf(elem) + 2;
                foreach (System.Reflection.PropertyInfo prop in typeProps)
                {
                    if (prop.ToString().Contains("System.Collections.Generic") || prop.ToString().Contains("WebApplication1.Models"))
                    {
                        continue;
                    }

                    int j = typeProps.IndexOf(prop);
                    ws.Cells[1, j + 1].Value = prop.Name;
                    ws.Cells[1, j + 1].Style.Font.Bold = true;
                    ws.Cells[i, j + 1].Value = typeProps[j].GetValue(elem);
                }
            }

            return pck;

        }
    }
}
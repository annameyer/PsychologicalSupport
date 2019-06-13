using OfficeOpenXml;
using PsychologicalSupports.Models.Dependencies;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PsychologicalSupports.Models
{
    public class ExcelFile
    {
        private IRepository<Student> _repository;
        public ExcelFile(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public IEnumerable<string> FIO()
        {
            var studentsFIO = _repository.List();
            return studentsFIO.Select(x => x.FIO);
        }

        public static ExcelPackage GenerateExcelFile<T>(IEnumerable<T> ds)
        {
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add(nameof(T));

            System.Reflection.PropertyInfo[] typeProps = typeof(T).GetProperties();
            
            foreach (T elem in ds)
            {
                int i = ds.ToList().IndexOf(elem) + 2;
                foreach (System.Reflection.PropertyInfo prop in typeProps)
                {
                    if (prop.ToString().Contains("System.Collections.Generic") || prop.ToString().Contains("PsychologicalSupports.Models"))
                    {
                        continue;
                    }

                    int j = typeProps.ToList().IndexOf(prop);
                    object[] atrrs = prop.GetCustomAttributes(true);
                    object typeAttr = atrrs.Count() > 0 ? atrrs[0] : null;
                    var authAttr = typeAttr as DisplayAttribute;
                    
                    if (j == 0)
                    {
                        
                        ws.Cells[1, j + 1].Value = "_repository.List()";
                        ws.Cells[1, j + 1].Style.Font.Bold = true;
                        ws.Cells[i, j + 1].Value = typeProps[5].GetValue(elem);
                    }
                    else
                    {
                        ws.Cells[1, j + 1].Value = authAttr != null ? authAttr.Name : prop.Name;

                        ws.Cells[1, j + 1].Style.Font.Bold = true;
                        ws.Cells[i, j + 1].Value = typeProps[j].GetValue(elem);
                    }
                    
                }
            }

            return pck;
        }
    }
}
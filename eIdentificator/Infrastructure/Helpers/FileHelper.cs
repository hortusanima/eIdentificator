using eIdentificator.Domain.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace eIdentificator.Infrastructure.Helpers
{
    public class FileHelper : IFileHelper
    {
        public void WriteCSVFile<T>(
            List<T> list, 
            string filePath
        )
        {
            using (var writer = new StreamWriter(
                filePath, 
                append: false, 
                encoding: Encoding.UTF8)
            )
            {
                var properties = typeof(T).GetProperties();
                writer.WriteLine(string.Join(
                    ",", 
                    properties.Select(p => p.Name
                )));

                foreach (var item in list)
                {
                    var values = properties.Select(
                        p => p.GetValue(item)?.ToString() ?? "")
                        .ToArray();
                    writer.WriteLine(string.Join(
                        ",", 
                        values
                    ));
                }
            }
        }
    }
}

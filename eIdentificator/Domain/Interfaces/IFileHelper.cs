using System.Collections.Generic;

namespace eIdentificator.Domain.Interfaces
{
    public interface IFileHelper
    {
        void WriteCSVFile<T>(List<T> list, string filePath);
    }
}

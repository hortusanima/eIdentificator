using System.Collections.Generic;

namespace eIdentificator.Domain.Interfaces
{
    public interface IListHelper
    {
        void SortListByClassField<T>(ref List<T> list, string field, bool isDescendant);
    }
}

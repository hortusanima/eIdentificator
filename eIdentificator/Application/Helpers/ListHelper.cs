using eIdentificator.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace eIdentificator.Application.Helpers
{
    public class ListHelper : IListHelper
    {
        public void SortListByClassField<T>(
            ref List<T> list, 
            string field, 
            bool isDescending
        )
        {
            list.Sort((o1, o2) =>
            {
                var prop1 = o1
                    .GetType()
                        .GetProperty(field)?
                            .GetValue(o1) as IComparable;
                var prop2 = o2
                    .GetType()
                        .GetProperty(field)?
                            .GetValue(o2) as IComparable;

                if (prop1 == null && prop2 == null) return 0;
                if (prop1 == null) return -1;
                if (prop2 == null) return 1;

                return prop1.CompareTo(prop2);
            });

            if (isDescending)
            {
                list.Reverse();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.Helper
{
    public static class ListExtensions
    {
        public static bool HasCount<T>(this List<T>? list, int threshold)
        {
            if (list == null)
            {
                return false;
            }

            return list.Count >= threshold;
        }
    }
}

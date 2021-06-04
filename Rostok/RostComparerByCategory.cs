using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rostok
{
    class RostComparerByCategory : IEqualityComparer<Rost>
    {
        public bool Equals(Rost a, Rost b)
        {
            if (object.ReferenceEquals(a, b)) return true;

            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null)) return false;

            return a.Kategória == b.Kategória;
        }

        public int GetHashCode(Rost r)
        {
            return 0;
        }
    }
}

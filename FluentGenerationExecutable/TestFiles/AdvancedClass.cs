namespace first.second
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    [System.Obsolete("use something else")]
    public abstract class AdvancedClass<T1, T2, T3> : IEnumerable<T1> where T1 : System.IComparable where T2 : System.IComparable
    {
        public IEnumerator<T1> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
namespace first.second
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    [System.Obsolete("use something else")]
    public interface IAdvancedInterface<T1, out T2, in T3> : IEnumerable<T1> where T1 : System.IComparable where T2 : System.IComparable
    {
    }
}
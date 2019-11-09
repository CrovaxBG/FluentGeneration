namespace first.second.third
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public interface IFullInterface<T1>
    {
        System.String StringProperty
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        System.Collections.Generic.Dictionary<System.Collections.Generic.HashSet<System.Int32>, System.Collections.Generic.List<System.Int32>> MapProp
        {
            get;
        }

        void VoidMethod<T>();
        void VoidMethod2(System.Int32 intParam);
    }
}
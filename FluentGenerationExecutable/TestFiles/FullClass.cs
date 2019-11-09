namespace first.second.third
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class FullClass<T>
    {
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.ComponentModel.DataAnnotations.DisplayAttribute]
        private static readonly System.Int32 _count;
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.ComponentModel.DataAnnotations.DisplayAttribute]
        private System.Collections.Generic.List<System.String> _counters;
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public System.Collections.Generic.List<System.String> Counters
        {
            get
            {
                return _counters;
            }

            private set
            {
                _counters = value;
            }
        }

        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public System.String AutoProp
        {
            get;
            set;
        }

        = null;
        public static void Method1(System.Int32 x, ref System.Int32 y, out System.Int32 z)
        {
            z = x + y;
        }

        [System.Diagnostics.Contracts.PureAttribute]
        public System.String Method2(FluentGeneration.Shared.IParameter parameter)
        {
            return string.Empty;
        }
    }
}
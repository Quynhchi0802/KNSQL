using System;

namespace KNSQL.Models
{
    internal class StringLenghthAttribute : Attribute
    {
        private int v;

        public StringLenghthAttribute(int v)
        {
            this.v = v;
        }
    }
}
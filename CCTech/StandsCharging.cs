﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing;

using System.Windows.Documents;

namespace CCTech
{
     
    class StandsCharging
    {
        DateTime TimeOfEntrece = DateTime.Now;
       
    }

    internal struct NewStruct
    {
        public object Item1;
        public object Item2;

        public NewStruct(object item1, object item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override bool Equals(object obj)
        {
            return obj is NewStruct other &&
                   EqualityComparer<object>.Default.Equals(Item1, other.Item1) &&
                   EqualityComparer<object>.Default.Equals(Item2, other.Item2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Item1, Item2);
        }

        public void Deconstruct(out object item1, out object item2)
        {
            item1 = Item1;
            item2 = Item2;
        }

        public static implicit operator (object, object)(NewStruct value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct((object, object) value)
        {
            return new NewStruct(value.Item1, value.Item2);
        }
    }
}

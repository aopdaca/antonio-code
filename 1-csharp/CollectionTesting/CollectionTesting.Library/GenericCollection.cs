using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionTesting.Library
{
    // just after the class (or method) name in its def - that is declaring  type param
    //for type param names, we use T,U,V etc....
    //or TSource, TKey, TValue, things like that
    public class GenericCollection<T>
    {
        // everywhere eelse, you are using that definied type param
        protected readonly List<T> list = new List<T>();

        public GenericCollection()
        {

        }
        public GenericCollection(IEnumerable<T> values)
        {
            list.AddRange(values);
        }

         public void Add(T value)
        {
            // this is called deligation - deligate tast of ading to other object
            list.Add(value);
        }

        public bool Removebool(T value)
        {
            return list.Remove(value);
        }


        public void Remove(T s)
        {
            list.Remove(s);
        }

        public string this[int index]
        {
            get => list[index];
            set => list[index] = value;

        }
    }
}

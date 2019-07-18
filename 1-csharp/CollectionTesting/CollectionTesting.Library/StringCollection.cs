using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionTesting.Library
{
    /// <summary>
    /// An ordered collection of strings with some healpful methods.
    /// </summary>
    /// <remarks>
    /// this class is based on list, using composition
    /// </remarks>
    public class StringCollection : GenericCollection<string>
    {
        //read only only stops from reasigning variable, does not prevent changing state of object
        //private readonly List<string> _list = new List<string>();

        //constructors are not (directly) inherited

        public StringCollection() { } // implicitly calls base() first

        public StringCollection(IEnumerable<string> values) : base(values)
        {}
        //every chid class constructor HAS to call SOME base class constructor first
        //by defult, it will call the zero paamerter one.

        //public void Add(string s)
        //{
        //    // this is called deligation - deligate tast of ading to other object
        //    _list.Add(s);
        //}

        //public bool Removebool(string s)
        //{
        //    return _list.Remove(s);
        //}

      
        //public void Remove(string s)
        //{
        //     _list.Remove(s);
        //}

        //public string this[int index]
        //{
        //    get => _list[index];
        //    set => _list[index] = value;

        //}

        public bool IsEmpty()
        {
            if (_list.Count == 0)
            {
                return true;
            }
            return false;
            
        }

        //TDD, test driven development
        //Write code before you write the code that they test
        // 1. Write corect but failling tests
        // 2. you implement code until the test pass
        public string GetLongest()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfVowle()
        {
            throw new NotImplementedException();
        }

        public int GetAvrageLength()
        {
            throw new NotImplementedException();
        }
    }
}

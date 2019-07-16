using System;
using System.Collections.Generic;
using System.Text;

namespace DogApp
{
    class Dog
    {
        //private string name;
        //private string owner;

        //public string GetName()
        //{
        //    return name;
        //}

        //public string GetOwner()
        //{
        //    return owner;
        //}

        //public void SetOwner(string owner)
        //{
        //    if (owner == null)
        //    {
        //        throw new ArgumentNullException("Owner");
        //    }
        //    this.owner = owner;
        //}

        private string Name { get; set; }

        private string _owner;

        public string Owner
        {
            get { return _owner; }
            set
            {
                if ( value == null)
                {
                    throw new ArgumentNullException("Owner");
                }

                _owner = value;
            }
        }

        public string Identifier
        {
            get
            {
                // string interpolation syntax
                return $"{Owner} - {Name}";
            }
        }

        public Dog(string name)
        {
            this.Name = name;
        }

        public void Bark()
        {
            Console.WriteLine("Bark!!!");
        }
    }
}

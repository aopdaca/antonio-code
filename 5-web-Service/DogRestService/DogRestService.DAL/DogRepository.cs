using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DogRestService.DAL
{
    public class DogRepository
    {
        private readonly List<Dog> dogs;

        public DogRepository(List<Dog> dogs)
        {
            this.dogs = dogs ?? throw new ArgumentNullException(nameof(dogs));
        }

        public IEnumerable<Dog> GetAll()
        {
            return dogs;
        }

        public Dog Get(int id)
        {
            return dogs.FirstOrDefault(x => x.Id == id);
        }

        public Dog Update(Dog dog)
        {
            return dogs.Where(x => x.Id == dog.Id).First();
        }

        public int Create(Dog dog)
        {
            var newDog = new Dog
            {
                Id = dogs.Count == 0 ? 1 : dogs.Max(x => x.Id) + 1,
                Name = dog.Name
            };
            dogs.Add(newDog);
            return newDog.Id;
        }
    }
}

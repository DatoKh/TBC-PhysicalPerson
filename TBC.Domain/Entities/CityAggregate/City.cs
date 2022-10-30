using Common.Domain.Seedwork;
using System.Collections.Generic;

namespace TBC.Domain.Entities.CityAggregate
{
    public class City : BaseEntity<int>
    {
        protected City() { }

        private City(string name) : this()
        {
            Name = name;
        }

        public string Name { get; private set; }

        public virtual ICollection<PersonAggregate.Person> People { get; set; }

        public static City Create(string name) => new City(name);

        public void Update(string name) => Name = name;
    }
}

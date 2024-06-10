using Cargo.Entity.Entities.Abstract;

namespace Cargo.Entity.Entities.Concrete
{
    public class Company : BaseEntity
    {
        public Company()
        {
            Cargos = new List<Entity.Entities.Concrete.Cargo>();
        }

        public string Name { get; set; }

        // Relations
        public IEnumerable<Entity.Entities.Concrete.Cargo> Cargos { get; set; }
    }
}
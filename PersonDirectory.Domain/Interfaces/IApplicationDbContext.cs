using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PersonDirectory.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PersonDirectory.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        DatabaseFacade Database { get; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<PersonRelationship> PersonRelationships { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

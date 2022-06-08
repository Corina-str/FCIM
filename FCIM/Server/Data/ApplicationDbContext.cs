using BiroulSindicalFCIM.Shared;
using Duende.IdentityServer.EntityFramework.Options;
using Duende.IdentityServer.Models;
using FCIM.Server.Models;
using FCIM.Shared;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FCIM.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<EduCard> EduCards { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
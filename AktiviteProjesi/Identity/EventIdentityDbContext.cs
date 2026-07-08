using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AktiviteProjesi.Identity
{
    public class EventIdentityDbContext :IdentityDbContext<EventIdentityUser,EventIdentityRole,string>
    {
        public EventIdentityDbContext(DbContextOptions<EventIdentityDbContext> options ): base(options)
        {

        }

    }
}

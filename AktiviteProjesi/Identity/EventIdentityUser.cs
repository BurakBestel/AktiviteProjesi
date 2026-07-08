using Microsoft.AspNetCore.Identity;

namespace AktiviteProjesi.Identity
{
    public class EventIdentityUser : IdentityUser
    {
        public  string Name { get; set; }
        public string Surname { get; set; }
    }
}

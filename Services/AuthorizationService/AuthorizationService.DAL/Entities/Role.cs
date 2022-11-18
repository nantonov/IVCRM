using Microsoft.AspNetCore.Identity;

namespace AuthorizationService.DAL.Entities
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
        }
    }
}

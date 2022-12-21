using Microsoft.AspNetCore.Identity;

namespace CursoIndio.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}

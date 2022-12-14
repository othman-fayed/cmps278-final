using Microsoft.AspNetCore.Identity;

namespace DocumentsWeb.Data.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        /// <summary>
        /// Mr, Ms, Mrs
        /// </summary>
        public string? TitleOfCourtesy { get; set; }
    }
}

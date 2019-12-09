using Acme.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Acme.Models
{
    public class User : IValidatableObject 
    {
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;
            var dbContext = validationContext.GetService(typeof(AcmeDbContext)) as AcmeDbContext;
            var existingUser = dbContext.Users.FirstOrDefault(x => x.Email.ToLower() == user.Email.ToLower());
            if (existingUser != null)
            {
                yield return new ValidationResult("A user with the same email already exists");
            }
        }
    }
}

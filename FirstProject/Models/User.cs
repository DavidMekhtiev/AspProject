using System;
using System.Collections.Generic;

namespace FirstProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string IIN { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;

        public List<CenterUser> CenterUsers { get; set; }
    }
}

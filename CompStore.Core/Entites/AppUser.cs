using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
    }
}

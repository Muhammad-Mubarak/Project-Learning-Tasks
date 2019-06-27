using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityFramework.Data
{
    public class Application : IdentityUser
    {
        public string firstName { get; set; }
    }
}

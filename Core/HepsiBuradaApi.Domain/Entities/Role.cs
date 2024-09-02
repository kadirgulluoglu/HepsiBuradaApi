using System;
using Microsoft.AspNetCore.Identity;

namespace HepsiBuradaApi.Domain.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role()
        {
        }
    }
}


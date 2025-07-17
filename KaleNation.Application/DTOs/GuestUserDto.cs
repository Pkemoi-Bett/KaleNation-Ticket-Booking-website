using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaleNation.Application.DTOs
{
    public class GuestUserDto
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
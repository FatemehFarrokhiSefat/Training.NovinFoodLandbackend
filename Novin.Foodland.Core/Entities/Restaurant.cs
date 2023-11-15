using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Foodland.Core.Entities
{
    public class Restaurant : BaseEntity 
    {
        public String? Title { get; set; }
        public ApplicationUser? Owner { get; set; }
        public string?  OwnerUsername { get; set; }
        public bool IsApproved { get; set; }
        public ApplicationUser? Approved { get; set; }
        public String? ApprovedUsername { get; set; }
        public DateTime? ApprovedTime { get; set; }
        public bool IsActive { get; set; }
        public byte[]? Logo { get; set; }
        public string? LogoType { get; set; }
        public string? Address { get; set; }
    }
}

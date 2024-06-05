using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Anshan.Framework.Domain;

namespace Domain.Models.Users
{
    public class User : AggregateRoot<int>
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public string MembershipId { get; private set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
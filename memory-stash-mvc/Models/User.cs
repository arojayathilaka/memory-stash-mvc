using System;
using System.Collections.Generic;

#nullable disable

namespace memory_stash_mvc.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation Properties
        public virtual List<Friend> Friends { get; set; }
        public virtual List<Group_User> Groups_Users { get; set; }
    }
}

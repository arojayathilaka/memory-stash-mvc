﻿using System;
using System.Collections.Generic;

#nullable disable

namespace memory_stash.Data.Models
{
    public partial class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public virtual List<Group_User> Groups_Users { get; set; }
        public virtual List<Memory> Memories { get; set; }
    }
}

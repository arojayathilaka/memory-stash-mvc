using System;
using System.Collections.Generic;

#nullable disable

namespace memory_stash_mvc.Models
{
    public class MemoryImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        // Navigation Properties
        public int MemoryId { get; set; }
        public  Memory Memory { get; set; }
    }
}

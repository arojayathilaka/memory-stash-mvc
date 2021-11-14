using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

#nullable disable

namespace memory_stash_mvc.Models
{
    public class MemoryImage
    {
        public int Id { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        // Navigation Properties
        public int MemoryId { get; set; }
        public  Memory Memory { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class ContentGenre
    {
        public int? GenreId { get; set; }
        public int? ContentId { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual Content Content { get; set; }
        public virtual Genre Genre { get; set; }
    }
}

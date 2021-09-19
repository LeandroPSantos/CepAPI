using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class ContentRating
    {
        public ContentRating()
        {
            Contents = new HashSet<Content>();
        }

        public int ContentRatingId { get; set; }
        public int? ContentTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual ContentType ContentType { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}

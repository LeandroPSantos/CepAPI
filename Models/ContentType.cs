using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class ContentType
    {
        public ContentType()
        {
            ContentRatings = new HashSet<ContentRating>();
            Contents = new HashSet<Content>();
        }

        public int ContentTypeId { get; set; }
        public string Name { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual ICollection<ContentRating> ContentRatings { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}

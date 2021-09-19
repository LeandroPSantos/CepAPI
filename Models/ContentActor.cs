using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class ContentActor
    {
        public int? ActorId { get; set; }
        public int? ContentId { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Content Content { get; set; }
    }
}

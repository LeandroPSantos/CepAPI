using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class ContentDirector
    {
        public int? DirectorId { get; set; }
        public int? ContentId { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual Content Content { get; set; }
        public virtual Director Director { get; set; }
    }
}

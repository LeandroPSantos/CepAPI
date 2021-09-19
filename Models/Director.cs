using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class Director
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

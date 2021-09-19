using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

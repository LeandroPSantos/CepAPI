using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class EpisodeList
    {
        public int EpisodeId { get; set; }
        public int SeasonNum { get; set; }
        public string EpisodeName { get; set; }
        public int? ContentId { get; set; }
        public string ReleaseDate { get; set; }
        public decimal EpisodeRating { get; set; }
        public int EpisodeNum { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdated { get; set; }
        public string EpisodeImdbLink { get; set; }
        public int EpisodeScoreVotes { get; set; }

        public virtual Content Content { get; set; }
    }
}

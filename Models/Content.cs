using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class Content
    {
        public Content()
        {
            EpisodeLists = new HashSet<EpisodeList>();
        }

        public int ContentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalSeasons { get; set; }
        public decimal ImdbScore { get; set; }
        public string ReleaseDates { get; set; }
        public string PlayTime { get; set; }
        public int? ContentRating { get; set; }
        public int TotalEpisodes { get; set; }
        public int ContentType { get; set; }
        public string ImdbLink { get; set; }
        public DateTime LastUpdated { get; set; }
        public int ImdbScoreVotes { get; set; }
        public string RatingDetails { get; set; }
        public string[] Languages { get; set; }

        public virtual ContentRating ContentRatingNavigation { get; set; }
        public virtual ContentType ContentTypeNavigation { get; set; }
        public virtual ICollection<EpisodeList> EpisodeLists { get; set; }
    }
}

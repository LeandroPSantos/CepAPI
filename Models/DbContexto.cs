using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsumoCepAPI.Models
{
    public partial class DbContexto : DbContext
    {
        public DbContexto()
        {
        }

        public DbContexto(DbContextOptions<DbContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentActor> ContentActors { get; set; }
        public virtual DbSet<ContentDirector> ContentDirectors { get; set; }
        public virtual DbSet<ContentGenre> ContentGenres { get; set; }
        public virtual DbSet<ContentRating> ContentRatings { get; set; }
        public virtual DbSet<ContentType> ContentTypes { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<EpisodeList> EpisodeLists { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<ListaResumidum> ListaResumida { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<TblCep> TblCeps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=no-db-dev-101.negocieonline.com.br;Port=5432;Database=db_selecao_imdb;Username=test;Password=Sacapp@2020");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actors");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("contents");

                entity.HasIndex(e => e.ImdbLink, "contents_imdb_link_key")
                    .IsUnique();

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.ContentRating).HasColumnName("content_rating");

                entity.Property(e => e.ContentType).HasColumnName("content_type");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ImdbLink)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("imdb_link");

                entity.Property(e => e.ImdbScore).HasColumnName("imdb_score");

                entity.Property(e => e.ImdbScoreVotes).HasColumnName("imdb_score_votes");

                entity.Property(e => e.Languages)
                    .IsRequired()
                    .HasColumnType("character varying(50)[]")
                    .HasColumnName("languages");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.PlayTime)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("play_time");

                entity.Property(e => e.RatingDetails)
                    .IsRequired()
                    .HasColumnType("json")
                    .HasColumnName("rating_details")
                    .HasDefaultValueSql("'{}'::json");

                entity.Property(e => e.ReleaseDates)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("release_dates");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.TotalEpisodes).HasColumnName("total_episodes");

                entity.Property(e => e.TotalSeasons).HasColumnName("total_seasons");

                entity.HasOne(d => d.ContentRatingNavigation)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.ContentRating)
                    .HasConstraintName("contents_content_rating_fkey");

                entity.HasOne(d => d.ContentTypeNavigation)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.ContentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contents_content_type_fkey");
            });

            modelBuilder.Entity<ContentActor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("content_actors");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.HasOne(d => d.Actor)
                    .WithMany()
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("content_actors_actor_id_fkey");

                entity.HasOne(d => d.Content)
                    .WithMany()
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("content_actors_content_id_fkey");
            });

            modelBuilder.Entity<ContentDirector>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("content_directors");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.DirectorId).HasColumnName("director_id");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.HasOne(d => d.Content)
                    .WithMany()
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("content_directors_content_id_fkey");

                entity.HasOne(d => d.Director)
                    .WithMany()
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("content_directors_director_id_fkey");
            });

            modelBuilder.Entity<ContentGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("content_genres");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.HasOne(d => d.Content)
                    .WithMany()
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("content_genres_content_id_fkey");

                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("content_genres_genre_id_fkey");
            });

            modelBuilder.Entity<ContentRating>(entity =>
            {
                entity.ToTable("content_ratings");

                entity.HasIndex(e => e.Name, "content_ratings_name_key")
                    .IsUnique();

                entity.Property(e => e.ContentRatingId).HasColumnName("content_rating_id");

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.ContentRatings)
                    .HasForeignKey(d => d.ContentTypeId)
                    .HasConstraintName("content_ratings_content_type_id_fkey");
            });

            modelBuilder.Entity<ContentType>(entity =>
            {
                entity.ToTable("content_types");

                entity.HasIndex(e => e.Name, "content_types_name_key")
                    .IsUnique();

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("directors");

                entity.Property(e => e.DirectorId).HasColumnName("director_id");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EpisodeList>(entity =>
            {
                entity.HasKey(e => e.EpisodeId)
                    .HasName("episode_list_pkey");

                entity.ToTable("episode_list");

                entity.HasIndex(e => e.EpisodeImdbLink, "episode_list_episode_imdb_link_key")
                    .IsUnique();

                entity.Property(e => e.EpisodeId).HasColumnName("episode_id");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EpisodeImdbLink)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("episode_imdb_link");

                entity.Property(e => e.EpisodeName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("episode_name");

                entity.Property(e => e.EpisodeNum).HasColumnName("episode_num");

                entity.Property(e => e.EpisodeRating).HasColumnName("episode_rating");

                entity.Property(e => e.EpisodeScoreVotes).HasColumnName("episode_score_votes");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.ReleaseDate)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("release_date");

                entity.Property(e => e.SeasonNum).HasColumnName("season_num");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.EpisodeLists)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("episode_list_content_id_fkey");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.HasIndex(e => e.Name, "genres_name_key")
                    .IsUnique();

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("languages");

                entity.HasIndex(e => e.Name, "languages_name_key")
                    .IsUnique();

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ListaResumidum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lista_resumida");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.EpisodeName)
                    .HasMaxLength(250)
                    .HasColumnName("episode_name");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory", "dbo");

                entity.Property(e => e.MigrationId)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.ContextKey)
                    .HasMaxLength(300)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasDefaultValueSql("'\\x'::bytea");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''::character varying");
            });

            modelBuilder.Entity<TblCep>(entity =>
            {
                entity.HasKey(e => e.IdCep)
                    .HasName("pk_id_cep");

                entity.ToTable("tbl_cep");

                entity.Property(e => e.IdCep)
                    .HasColumnName("id_cep")
                    .HasDefaultValueSql("nextval('cep_id_seq'::regclass)");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("cep");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(120)
                    .HasColumnName("complemento");

                entity.Property(e => e.Ddd).HasColumnName("ddd");

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.Property(e => e.Ibge)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ibge");

                entity.Property(e => e.Localidade)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("localidade");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("logradouro");

                entity.Property(e => e.Siafi).HasColumnName("siafi");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("uf");
            });

            modelBuilder.HasSequence("cep_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

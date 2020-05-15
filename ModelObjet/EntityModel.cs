using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;



namespace ModelObjet
{
    public class EntityModel : DbContext
    {
        public DbSet<Bibliotheque> LesBibliotheques { get; set; }
        public DbSet<Document> LesDocuments { get; set; }
        public DbSet<Film> LesFilms { get; set; }
        public DbSet<Livre> LesLivres { get; set; }
        public DbSet<Acteur> LesActeurs { get; set; }
        public DbSet<Realisateur> LesRealisateurs { get; set; }
        public DbSet<Auteur> LesAuteurs { get; set; }
        public DbSet<Participer> LesParticipants { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=localhost;Database=e4_bibliotheque;Uid=root;Pwd=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bibliotheque>
                (
                    entity =>
                    {
                        entity.ToTable("bibliotheque");
                        entity.HasKey(e => e.IdBibliotheque);
                        entity.Property(e => e.IdBibliotheque).HasColumnName("idBibliotheque");
                        entity.Property(e => e.NomBibliotheque).HasColumnName("nomBibliotheque");
                    }
                );
            modelBuilder.Entity<Document>
                (
                    entity =>
                    {
                        entity.ToTable("document");
                        entity.HasKey(e => e.IdDoc);
                        entity.Property(e => e.IdDoc).HasColumnName("idDocument");
                        entity.Property(e => e.Titre).HasColumnName("titre");
                        entity.Property(e => e.Etat).HasColumnName("etat");
                    }
                );
            modelBuilder.Entity<Film>
                (
                    entity =>
                    {
                        entity.ToTable("film");
                        entity.HasKey(e => e.IdFilm);
                        entity.Property(e => e.IdFilm).HasColumnName("idFilm");
                        entity.Property(e => e.Titre).HasColumnName("titreFilm");
                        entity.Property(e => e.Etat).HasColumnName("etat");
                        entity.Property(e => e.PrixFilm).HasColumnName("prixFilm");
                        entity.Property(e => e.Photo).HasColumnName("photoFilm");
                    }
                );
            modelBuilder.Entity<Livre>
                (
                    entity =>
                    {
                        entity.ToTable("livre");
                        entity.HasKey(e => e.IdLivre);
                        entity.Property(e => e.IdLivre).HasColumnName("idLivre");
                        entity.Property(e => e.Titre).HasColumnName("titreLivre");
                        entity.Property(e => e.Etat).HasColumnName("etat");
                        entity.Property(e => e.PrixLivre).HasColumnName("prix");
                        entity.Property(e => e.Photo).HasColumnName("photoLivre");
                        entity.Property(e => e.Resume).HasColumnName("resume");
                    }
                );
            modelBuilder.Entity<Acteur>
                (
                    entity =>
                    {
                        entity.ToTable("acteur");
                        entity.HasKey(e => e.IdActeur);
                        entity.Property(e => e.IdActeur).HasColumnName("idActeur");
                        entity.Property(e => e.NomActeur).HasColumnName("nomActeur");
                        entity.Property(e => e.PrenomActeur).HasColumnName("prenomActeur");
                        entity.Property(e => e.AgeActeur).HasColumnName("ageActeur");
                        entity.Property(e => e.PhotoActeur).HasColumnName("photoActeur");

                    }
                );
            modelBuilder.Entity<Realisateur>
                (
                    entity =>
                    {
                        entity.ToTable("realisateur");
                        entity.HasKey(e => e.IdReal);
                        entity.Property(e => e.IdReal).HasColumnName("idRealisateur");
                        entity.Property(e => e.NomReal).HasColumnName("nomRealisateur");
                        entity.Property(e => e.PrenomReal).HasColumnName("prenomRealisateur");
                        entity.Property(e => e.PhotoReal).HasColumnName("photoRealisateur");

                    }
                );
            modelBuilder.Entity<Auteur>
                (
                    entity =>
                    {
                        entity.ToTable("auteur");
                        entity.HasKey(e => e.IdAuteur);
                        entity.Property(e => e.IdAuteur).HasColumnName("idAuteur");
                        entity.Property(e => e.NomAuteur).HasColumnName("nomAuteur");
                        entity.Property(e => e.PrenomAuteur).HasColumnName("prenomAuteur");
                        entity.Property(e => e.PhotoAuteur).HasColumnName("photoAuteur");

                    }
                );
            modelBuilder.Entity<Participer>
                (
                    entity =>
                    {
                        entity.ToTable("participer");
                        entity.HasKey(e => e.NumFilm);
                        entity.HasKey(e => e.NumActeur);
                        entity.Property(e => e.NumFilm).HasColumnName("numFilm");
                        entity.Property(e => e.NumActeur).HasColumnName("numActeur");

                    }
                );
        }
    }
}

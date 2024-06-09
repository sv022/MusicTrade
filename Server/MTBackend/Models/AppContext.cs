using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MTBackend.Models;

public partial class AppDbContent : DbContext
{
    public AppDbContent()
    {
    }

    public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Listing> Listings { get; set; }

    public virtual DbSet<ListingImage> ListingImages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAdress> UserAdresses { get; set; }

    public virtual DbSet<UserFavoriteListing> UserFavoriteListings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("images_pkey");

            entity.ToTable("images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image1)
                .HasMaxLength(255)
                .HasColumnName("image");
        });

        modelBuilder.Entity<Listing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("listings_pkey");

            entity.ToTable("listings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .HasColumnName("adress");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Isexchangable).HasColumnName("isexchangable");
            entity.Property(e => e.Ownerid).HasColumnName("ownerid");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Publishdate).HasColumnName("publishdate");
            entity.Property(e => e.Tags)
                .HasMaxLength(255)
                .HasColumnName("tags");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Category).WithMany(p => p.Listings)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("listings_categoryid_foreign");

            entity.HasOne(d => d.Owner).WithMany(p => p.Listings)
                .HasForeignKey(d => d.Ownerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("listings_ownerid_foreign");
        });

        modelBuilder.Entity<ListingImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("id_pkey");

            entity.ToTable("listing_images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Imageid).HasColumnName("imageid");
            entity.Property(e => e.Listingid).HasColumnName("listingid");

            entity.HasOne(d => d.Image).WithMany()
                .HasForeignKey(d => d.Imageid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("listing_images_imageid_foreign");

            entity.HasOne(d => d.Listing).WithMany()
                .HasForeignKey(d => d.Listingid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("listing_images_listingid_foreign");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Avatarid).HasColumnName("avatarid");
            entity.Property(e => e.City)
                .HasColumnType("character varying")
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Refreshtoken)
                .HasColumnType("character varying")
                .HasColumnName("refreshtoken");
            entity.Property(e => e.Signupdate).HasColumnName("signupdate");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.Avatar).WithMany(p => p.Users)
                .HasForeignKey(d => d.Avatarid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("avatar_fk");
        });

        modelBuilder.Entity<UserAdress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_adresses_pkey");

            entity.ToTable("user_adresses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .HasColumnName("adress");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.UserAdresses)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_adresses_userid_foreign");
        });

        modelBuilder.Entity<UserFavoriteListing>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_favorite_listings");

            entity.Property(e => e.Listingid).HasColumnName("listingid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Listing).WithMany()
                .HasForeignKey(d => d.Listingid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_favorite_listings_listingid_foreign");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_favorite_listings_userid_foreign");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

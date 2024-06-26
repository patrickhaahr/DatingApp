﻿using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class DatingAppDbContext : DbContext
    {
        public DatingAppDbContext(DbContextOptions<DatingAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Profile)
                .WithOne(p => p.Account)
                .HasForeignKey<Profile>(p => p.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Sender)
                .WithMany(a => a.SentLikes)
                .HasForeignKey(l => l.SenderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Receiver)
                .WithMany(p => p.ReceivedLikes)
                .HasForeignKey(l => l.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Change to Restrict to avoid multiple cascade paths

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(a => a.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(p => p.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Change to Restrict to avoid multiple cascade paths

            // Configure primary key of City not to be an identity column
            modelBuilder.Entity<City>()
                .Property(c => c.ZipCode)
                .ValueGeneratedNever();

            // Configure unique constraints for Email and UserName
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.UserName)
                .IsUnique();

            // Add check constraint for age validation
            modelBuilder.Entity<Account>()
                .HasCheckConstraint("CK_Account_BirthDate", "DATEDIFF(YEAR, BirthDate, GETDATE()) >= 18");

            base.OnModelCreating(modelBuilder);
        }
    }
}
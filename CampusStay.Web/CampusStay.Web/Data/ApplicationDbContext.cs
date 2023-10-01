using CampusStay.Web.Models.Domain;
using CampusStay.Web.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampusStay.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<DormRoom> DormRooms { get; set; }
        public virtual DbSet<Campus> Campuses { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } 
        public virtual DbSet<DormRoomInShoppingCart> DormRoomInShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DormRoom>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Campus>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            //many-to-one
            builder.Entity<Campus>()
                .HasMany(c => c.DormRooms) 
                .WithOne(d => d.Campus)    
                .HasForeignKey(d => d.CampusId);

            //one-to-one
            builder.Entity<ShoppingCart>()
                .HasOne<ApplicationUser>(z => z.User)
                .WithOne(z => z.ShoppingCart)
                .HasForeignKey<ShoppingCart>(z => z.UserId);

            //many-to-many
            builder.Entity<DormRoomInShoppingCart>()
                .HasKey(z => new { z.DormRoomId, z.ShoppingCartId });

            builder.Entity<DormRoomInShoppingCart>()
                .HasOne(z => z.DormRoom)
                .WithMany(z => z.DormRoomInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<DormRoomInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.DormRoomInShoppingCarts)
                .HasForeignKey(z => z.DormRoomId);
        }
    }
}
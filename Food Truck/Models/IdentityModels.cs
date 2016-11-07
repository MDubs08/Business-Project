using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Food_Truck.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Truck> Truck { get; set; }
        public DbSet<TruckInventory> TruckInventory { get; set; }
        public DbSet<Menu_Item> Menu_Item { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Zipcode> Zipcode { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ScheduleLocation> ScheduleLocation { get; set; }
    }
}
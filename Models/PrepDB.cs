using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ReactAspCoreCrud1.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            // get the scope of our db context
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DonationDBContext>());
            }
        }

        public static void SeedData(DonationDBContext context)
        {
            // applies the database schema
            System.Console.WriteLine("Applying Migrations...");
            context.Database.Migrate();
            // add some info no data
            if (!context.DCandidates.Any())
            {
                System.Console.WriteLine("Seeding data...");
                context.DCandidates.AddRange(
                    new DCandidate(){address = "a", age = 1,bloodGroup = "AB+", email = "a@a.com", fullName = "a", mobile = "1"},
                    new DCandidate(){address = "b", age = 2,bloodGroup = "O+", email = "b@b.com", fullName = "b", mobile = "2"},
                    new DCandidate(){address = "c", age = 3,bloodGroup = "AB-", email = "c@c.com", fullName = "c", mobile = "3"},
                    new DCandidate(){address = "d", age = 4,bloodGroup = "A+", email = "d@d.com", fullName = "d", mobile = "4"}
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data.");
            }
        }
    }
}
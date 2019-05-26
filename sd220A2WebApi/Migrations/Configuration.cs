namespace sd220A2WebApi.Migrations
{
    using sd220A2WebApi.Models.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<sd220A2WebApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(sd220A2WebApi.Models.ApplicationDbContext context)
        {
            context.CreditCardBrands.AddOrUpdate(p => p.IdentificationNumber,
                new CreditCardBrand { IdentificationNumber = "011", Brand = "Visa" },
                new CreditCardBrand { IdentificationNumber = "021", Brand = "Mastercard" },
                new CreditCardBrand { IdentificationNumber = "031", Brand = "American Express" }
            );
        }
    }
}

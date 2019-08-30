
namespace Shop.Web.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Shop.Web.Data.Entities;
    public class SeedDB
    {
        private readonly DataContext context;
        private Random random;
        public SeedDB(DataContext context)
        {
            this.context = context;
            this.random = new Random();   
        }
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone x");
                this.AddProduct("Magic Mouse");
                this.AddProduct("iWatch Series 4");
                await this.context.SaveChangesAsync();
            }
            
        }
        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailable = true,
                Stock = this.random.Next(100)
            });
        }       

    }
}

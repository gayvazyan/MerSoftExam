using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopAppMerSoftExam.Core.Entities;
using ShopAppMerSoftExam.Core.Repository;

namespace ShopAppMerSoftExam.Core
{
    public static partial class ServicesInitializer
    {
        public static void ConfigureDbContext(IConfiguration configuration, IServiceCollection services)
        {


            services.AddDbContextPool<ShopAppDbContect>(
              options => options.UseSqlServer(configuration.GetConnectionString("AppDbConnection")));



        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositories<>), typeof(Repositories<>));
            services.AddTransient<IGrupeRepasitory, GrupeRepasitory>();
            services.AddTransient<IProductRepasitory, ProductRepasitory>();
            services.AddTransient<IClientRepasitory, ClientRepasitory>();
            services.AddTransient<ISaleRepasitory, SaleRepasitory>();
            services.AddTransient<IOrderRepasitory, OrderRepasitory>();
            services.AddTransient<IOrderItemRepasitory, OrderItemRepasitory>();
            services.AddTransient<ISaleItemRepasitory, SaleItemRepasitory>();
            

        }
    }
}

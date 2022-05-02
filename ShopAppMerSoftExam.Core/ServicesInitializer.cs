using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopAppMerSoftExam.Core.Entities;

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
            //services.AddTransient(typeof(IRepositories<>), typeof(Repositories<>));
            //services.AddTransient<IProductRepasitory, ProductRepasitory>();
            
        }
    }
}

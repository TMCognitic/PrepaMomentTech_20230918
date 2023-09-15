using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using Tools.Locator;
using DR = PrepaMomentTech_20230918.Dal.Repositories;
using DS = PrepaMomentTech_20230918.Dal.Services;
using PrepaMomentTech_20230918.Bll.Repositories;
using PrepaMomentTech_20230918.Bll.Services;

namespace PrepaMomentTech_20230918.DalBllApp
{
    internal class Locator : LocatorBase
    {
        private const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PrepaMomentTech;User Id=AppUser; Password=Test1234=;Encrypt=False;";
        internal static Locator Instance = new Locator();

        private Locator()
        {
        }


        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDbConnection>(sp => new SqlConnection(CONNECTION_STRING));
            services.AddTransient<DR.IContactRepository, DS.ContactService>();
            services.AddTransient<IContactRepository, ContactService>();
        }
    }
}

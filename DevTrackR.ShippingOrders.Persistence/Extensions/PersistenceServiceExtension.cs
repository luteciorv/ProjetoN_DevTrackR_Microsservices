using DevTrackR.ShippingOrders.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using DevTrackR.ShippingOrders.Core.Repositories;
using DevTrackR.ShippingOrders.Persistence.Repositories;

namespace DevTrackR.ShippingOrders.Persistence.Extensions
{
    public static class PersistenceServiceExtension
    {
        public static void ConfigurePersistenceServices(this IServiceCollection services)
        {
            services.ConfigureRepositoriesServices();
            services.ConfigureMongoDbServices();
        }

        private static void ConfigureRepositoriesServices(this IServiceCollection services)
        {
            services.AddScoped<IShippingServiceRepository, ShippingServiceRepository>();
            services.AddScoped<IShippingOrderRepository, ShippingOrderRepository>();
        }

        private static void ConfigureMongoDbServices(this IServiceCollection services)
        {
            services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var options = new MongoDbOptions();

                configuration?.GetSection("MongoDb").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

                var configuration = serviceProvider.GetService<IConfiguration>();
                var options = serviceProvider.GetService<MongoDbOptions>();

                var client = new MongoClient(options?.ConnectionString);
                var database = client.GetDatabase(options?.Database);

                var mongoDbSeed = new MongoDbSeed(database);
                mongoDbSeed.Populate();

                return client;
            });

            services.AddTransient(serviceProvider =>
            {
                var options = serviceProvider.GetService<MongoDbOptions>();
                var mongoClient = serviceProvider.GetService<IMongoClient>();
                var database = mongoClient?.GetDatabase(options?.Database);

                return database;
            });
        }
    }
}

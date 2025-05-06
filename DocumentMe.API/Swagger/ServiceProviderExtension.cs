using Microsoft.OpenApi.Writers;
using System.Text;

namespace DocumentMe.API.Swagger
{
    public static class ServiceProviderExtension
    {
        /// <summary>
        ///  Generate swagger.json and write to file
        /// </summary>
        /// <param name="provider">Service retrieving obj</param>
        public static void AddSwaggerFileToCurrentDirectory(this IServiceProvider provider)
        {
            var swagger = provider.GetRequiredService<Swashbuckle.AspNetCore.Swagger.ISwaggerProvider>();

            var swaggerDoc = swagger.GetSwagger("v1");
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "swagger.json");

            using (var stream = new FileStream(jsonPath, FileMode.Create))
            {
                var writer = new OpenApiJsonWriter(new StreamWriter(stream, Encoding.UTF8));

                swaggerDoc.SerializeAsV3(writer);
            }
        }
    }
}

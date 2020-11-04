using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CitiesInfo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddControllersWithViews().AddNewtonsoftJson(); //Service to fix API error:
            //The JSON value could not be converted to Microsoft.AspNetCore.JsonPatch.JsonPatchDocument

            services.AddControllers()
                .AddMvcOptions(o =>
                {
                    //o.OutputFormatters.Add(new XmlSerializerOutputFormatter());  

                    //The XmlSerializerOutputFormatter is an asp.net core outputformatter that uses the XmlSerializer internally, 
                    //whereas the DataContractSerializerOutputFormatter uses the DataContractSerializer internally.

                    //The DataContractSerializer is more flexible in configuration.For example it supports reference detection to prevent the serializer from recursively serializing items, 
                    //which would normally cause an endless loop.
                    //o.OutputFormatters.RemoveType(typeof(SystemTextJsonOutputFormatter)); //this changes the default to xml format

                    o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());

                    //o.OutputFormatters.Add(new SystemTextJsonOutputFormatter(jsonSerializerOptions:null)); //since default is xml, now we again add json for specific requests


                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            //app.UseStatusCodePages(); // uses status codes pages that returns texts

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

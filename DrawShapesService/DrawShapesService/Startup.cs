using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DrawShapesService.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using DrawShapesService.Middleware;
using Serilog;
using DrawShapesService.Processor;
using DrawShapesService.Validators;

namespace DrawShapesService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IContainer Container { get; private set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            AddJsonConverers(serializerSettings);

            services.AddSingleton<JsonSerializerSettings>(serializerSettings);
            services.AddCors();
            services.AddMvcCore()
                .AddJsonFormatters()
                .AddJsonOptions(opt =>
                {
                    AddJsonConverers(opt.SerializerSettings);
                });

            return CreateAutofacServiceProvider(services);
        }
        private void AddJsonConverers(JsonSerializerSettings serializerSettings)
        {
            serializerSettings.Converters.Add(new StringEnumConverter());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(
                options => options.WithOrigins(Configuration.GetSection(Constants.CorsUrl).Value).AllowAnyMethod()
            );
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            loggerFactory.AddSerilog();
            app.UseMvc();
        }


        private IServiceProvider CreateAutofacServiceProvider(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterType<DrawShapesController>();
            builder.RegisterInstance(new QueryFormatProcessing()).As<IQueryFormatProcessing>();
            builder.RegisterType<CircleValidator>().Named<ShapeValidator>(Constants.Shapes.Circle);
            builder.RegisterType<IsoscelesTriangleValidator>().Named<ShapeValidator>(Constants.Shapes.IsoscelesTriangle);
            builder.RegisterType<OvalValidator>().Named<ShapeValidator>(Constants.Shapes.Oval);
            builder.RegisterType<ParallelogramValidator>().Named<ShapeValidator>(Constants.Shapes.Parallelogram);
            builder.RegisterType<RectangleValidator>().Named<ShapeValidator>(Constants.Shapes.Rectangle);
            builder.RegisterType<ScaleneTriangleValidator>().Named<ShapeValidator>(Constants.Shapes.ScaleneTriangle);
            builder.RegisterType<RegularPolygonValidator>().Named<ShapeValidator>(Constants.Shapes.Square);
            builder.RegisterType<RegularPolygonValidator>().Named<ShapeValidator>(Constants.Shapes.EquilateralTriangle);
            builder.RegisterType<RegularPolygonValidator>().Named<ShapeValidator>(Constants.Shapes.Pentagon);
            builder.RegisterType<RegularPolygonValidator>().Named<ShapeValidator>(Constants.Shapes.Hexagon);
            builder.RegisterType<RegularPolygonValidator>().Named<ShapeValidator>(Constants.Shapes.Heptagon);
            builder.RegisterType<RegularPolygonValidator>().Named<ShapeValidator>(Constants.Shapes.Octagon);

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

    }
}

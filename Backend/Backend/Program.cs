
namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string Origin = "MyAllowOrigin";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: Origin,
                    corsBuilder =>
                    {
                        corsBuilder.WithOrigins(["http://localhost:3000"])
                        .WithMethods(["GET"]);
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors(Origin);

            app.Run();
        }
    }
}

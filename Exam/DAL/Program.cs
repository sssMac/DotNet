using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(option => option.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors();


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(builder => builder.AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/Monsters", (ApplicationContext db) => db.Monsters.ToList());

app.Run();

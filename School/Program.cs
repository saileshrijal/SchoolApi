using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Data.IRepository;
using School.Data.Repository;
using School.Services.Implementation;
using School.Services.Interface;

var builder = WebApplication.CreateBuilder(args);
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connectionString));

    builder.Services.AddControllers();

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IGradeService,GradeService>();
    builder.Services.AddScoped<ISubjectService, SubjectService>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
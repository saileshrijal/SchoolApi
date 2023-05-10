using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Config;
using SchoolApi.Data;
using SchoolApi.Helpers;
using SchoolApi.Helpers.Interface;
using SchoolApi.Manager;
using SchoolApi.Manager.Interface;
using SchoolApi.Models;
using SchoolApi.Repository;
using SchoolApi.Repository.Interface;
using SchoolApi.Seeder;
using SchoolApi.Seeder.Interface;
using SchoolApi.Services;
using SchoolApi.Services.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connectionString));

    builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value!);
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true,
        };
    });

    //services
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserSeeder, UserSeeder>();
    builder.Services.AddScoped<IAuthManager, AuthManager >();
    builder.Services.AddScoped<IGradeService, GradeService>();
    builder.Services.AddScoped<ISubjectService, SubjectService>();
    builder.Services.AddScoped<ITeacherService, TeacherService>();
    builder.Services.AddScoped<IParentService, ParentService>();
    builder.Services.AddScoped<IStudentService, StudentService>();
    builder.Services.AddScoped<IExamTypeService, ExamTypeService>();
    builder.Services.AddScoped<IExamService, ExamService>();
    builder.Services.AddScoped<IFileHelper, FileHelper>();
   
   
    //repositories
    builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
    builder.Services.AddScoped<IGradeRepository, GradeRepository>();
    builder.Services.AddScoped<ISubjectGradeRepository, SubjectGradeRepository>();
    builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
    builder.Services.AddScoped<IParentRepository, ParentRepository>();
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();
    builder.Services.AddScoped<IExamTypeRepository, ExamTypeRepository>();
    builder.Services.AddScoped<IExamRepository, ExamRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}



var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseStaticFiles();

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}



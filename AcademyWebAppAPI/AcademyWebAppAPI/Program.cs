
using AcademyWebAppAPI.DataTransferObjectsManagers.BranchDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.CourseDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.GroupDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.LanguageDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.SubjectDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeCourseRelationsDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.TraineeDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.TransactionDtosManager;
using AcademyWebAppAPI.DataTransferObjectsManagers.UserDtosManager;
using AcademyWebAppAPI.Models;
using AcademyWebAppAPI.Repositories.Branch;
using AcademyWebAppAPI.Repositories.Course;
using AcademyWebAppAPI.Repositories.Group;
using AcademyWebAppAPI.Repositories.Language;
using AcademyWebAppAPI.Repositories.Subject;
using AcademyWebAppAPI.Repositories.Trainee;
using AcademyWebAppAPI.Repositories.TraineeCourseRelation;
using AcademyWebAppAPI.Repositories.Transaction;
using AcademyWebAppAPI.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AcademyWebAppAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AcademyWebAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddScoped<IGroupDtosManager, GroupDtosManager>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserDtosManager, UserDtosManager>();
            builder.Services.AddScoped<ITraineeCourseRelationRepository, TraineeCourseRelationRepository>();
            builder.Services.AddScoped<ITraineeCourseRelationDtosManager, TraineeCourseRelationDtosManager>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<ITransactionDtosManager, TransactionDtosManager>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            builder.Services.AddScoped<ITraineeDtosManager, TraineeDtosManager>();
            builder.Services.AddScoped<IBranchRepository, BranchRepository>();
            builder.Services.AddScoped<IBranchDtosManager, BranchDtosManager>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseDtosManager, CourseDtosManager>();
            builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
            builder.Services.AddScoped<ISubjectDtosManager, SubjectDtosManager>();
            builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
            builder.Services.AddScoped<ILanguageDtosManager, LanguageDtosManager>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowingAPIClientsAccess", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            builder.Services.AddAuthentication(options => options.DefaultAuthenticateScheme = "AcademyScheme")
                .AddJwtBearer("AcademyScheme", options =>
                {
                    string secretKey = "AcademyWebAppAPIDevelopedByOurTeam";
                    var encodedSecretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = encodedSecretKey,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AcademyInNumbersPage", policy =>
                    policy.RequireClaim("AcademyInNumbersPage", "True"));
                
                options.AddPolicy("GroupsPage", policy =>
                    policy.RequireClaim("GroupsPage", "True"));
                
                options.AddPolicy("UsersPage", policy =>
                    policy.RequireClaim("UsersPage", "True"));
                
                options.AddPolicy("BranchesPage", policy =>
                    policy.RequireClaim("BranchesPage", "True"));
                
                options.AddPolicy("CoursesPage", policy =>
                    policy.RequireClaim("CoursesPage", "True"));
                
                options.AddPolicy("SubjectsPage", policy =>
                    policy.RequireClaim("SubjectsPage", "True"));
                
                options.AddPolicy("TraineeAdditionPage", policy =>
                    policy.RequireClaim("TraineeAdditionPage", "True"));
                
                options.AddPolicy("CoursesToTraineeAdditionPage", policy =>
                    policy.RequireClaim("CoursesToTraineeAdditionPage", "True"));
                
                options.AddPolicy("TraineeCombinedAccountStatementPage", policy =>
                    policy.RequireClaim("TraineeCombinedAccountStatementPage", "True"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowingAPIClientsAccess");

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
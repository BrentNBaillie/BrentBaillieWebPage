using BrentBaillieAPI.Models;
using BrentBaillieAPI.Services.WorkIntance;
using BrentBaillieAPI.Services.Information;
using BrentBaillieAPI.Services.Educations;
using BrentBaillieAPI.Services.Skills;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MyDb"));

builder.Services.AddTransient<IInfoService, InfoService>();
builder.Services.AddTransient<IWorkInstanceService, WorkInstanceService>();
builder.Services.AddTransient<IEducationService, EducationService>();
builder.Services.AddTransient<ISkillService, SkillService>();

builder.Services.AddCors(policy => {

    policy.AddPolicy("CORS_Policy", builder =>
      builder.WithOrigins("*")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyOrigin()
        .AllowAnyMethod());
});

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseCors("CORS_Policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

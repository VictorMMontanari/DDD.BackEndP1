using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interfaces.SecretariaInterface;
using DDD.Infra.SQLServer.Interfaces.TIInterface;
using DDD.Infra.SQLServer.Repositories.SecretariaRepository;
using DDD.Infra.SQLServer.Repositories.TIRepository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Importante para rodar
builder.Services.AddCors();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Add services to the container.

//IOC - Dependency Injection
//SecretariaContext
builder.Services.AddScoped<IAlunoRepository, AlunoRepositorySqlServer>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepositorySqlServer>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepositorySqlServer>();
//TIContext
builder.Services.AddScoped<IGerenteRepository, GerenteRepositorySqlServer>();
builder.Services.AddScoped<IProgramadorRepository, ProgramadorRepositorySqlServer>();
builder.Services.AddScoped<IProjetoTIRepository, ProjetoTIRepositorySqlServer>();
//SqlContext
builder.Services.AddScoped<SqlContext, SqlContext>();

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Importante para rodar
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

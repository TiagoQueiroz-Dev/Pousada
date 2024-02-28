using backend.Database;
using backend.Entidades.Cliente.Repository;
using backend.Entidades.Cliente.Services;
using backend.Repository.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuraçao do banco de dados
var stringconection = builder.Configuration.GetConnectionString("Conexao");
builder.Services.AddDbContext<PousadaContext>(opt => {opt.UseMySql(stringconection, ServerVersion.AutoDetect(stringconection));});

//configuraçao do identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<PousadaContext>();

//injeçao de indepencias
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();
builder.Services.AddScoped<IClienteRepository,ClienteRepository>();
builder.Services.AddScoped<ClienteService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
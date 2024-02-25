using backend.Database;
using backend.Repository.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> 2b9b74f (Implementaçao da RF - 01 Cadastro do usuario)
=======
>>>>>>> b8c0dd168497516aae581edc52be0a2c2dfc3959
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuraçao do banco de dados
var stringconection = builder.Configuration.GetConnectionString("Conexao");
builder.Services.AddDbContext<PousadaContext>(opt => {opt.UseMySql(stringconection, ServerVersion.AutoDetect(stringconection));});

//configuraçao do identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<PousadaContext>();

//configuraçao das injeçao de dependencias
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();

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
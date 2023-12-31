
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adicionar o servi�o de controllers
builder.Services.AddControllers();

//Adiciona servi�o de autentica��o JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os par�metros de valida��o de token
.AddJwtBearer("JwtBearer",options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         //Valida quem est� solicitando
         ValidateIssuer = true,

         //Valida quem est� recebendo
         ValidateAudience = true,


         //Define se o tempo de espera��o do token ser� validado
         ValidateLifetime = true,
         //Define forma de criptografia e ainda valida��o da chave de autentica��o
         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

         //Coloca o limite do login de 5 minutos
         ClockSkew = TimeSpan.FromMinutes(5),

         // Local de quem solicita
         ValidIssuer = "webapi.filmes.tarde",
        //Local de quem recebe
         ValidAudience = "webapi.filmes.tarde"


     };
 }); 
//Paramos aqui





//adiciona o gerador de swagger

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Tarde",
        Description = " API para gerenciar filmes e seus generos - introdu��o a sprint 2 - backend API",

        Contact = new OpenApiContact
        {
            Name = "Senai informatica - Guilherme Gozzi Oliveira",
            Url = new Uri("https://github.com/GuilhermeOliveira23"),

        },

    });

    ///Configure o Swagger para usar o arquivo XML gerado com as instru��es anteriores. 
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    //Usando a autentica��o no swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() 
    {
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme ="Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "Value: Bearer TokenJWT"
    
    
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"

                }
                
            },
          new string[] {}
        }
    });
});

var app = builder.Build();

//mapear os controles


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//Usar autentica��o
app.UseAuthentication();
//Usar Autoriza��o
app.UseAuthorization();

app.MapControllers();
app.Run();



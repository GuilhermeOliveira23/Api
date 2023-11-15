using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
{

    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository  _usuarioRepository;

            public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }



        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou Senha Inválidos !");
            }




            // 1° definir as informações(Claims) que serão fornecidos no token (PayLoad)
            var claims = new[]
            {
                //formato da claim(tipo,valor)
                new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
               
                //Existe a possibilidade de criar uma claim personalizada
                new Claim("Claim Personalizada","Valor Personalizado")

            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

            //3° Definir as credencias do token (Header)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            //4° - Gerar o token
            var token = new JwtSecurityToken
            (
                //emissor do token 
                issuer: "webapi.filmes.tarde",


                //destinatário
                audience: "webapi.filmes.tarde",

                //dados definidos nas claim(PayLoad)
                claims: claims,

                //tempo de expiração
                expires: DateTime.Now.AddMinutes(5),

                //credenciais do token
                signingCredentials: creds
            );

            //5° - retornar  o token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });



        }
    }
}

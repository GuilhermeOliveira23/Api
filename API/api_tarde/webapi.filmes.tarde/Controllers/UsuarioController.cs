using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController :ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

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
                new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                new Claim(ClaimTypes.Role, usuarioBuscado.Permissao),
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
                    claims : claims,

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

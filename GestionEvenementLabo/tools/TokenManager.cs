using GestionEvent_DAL.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionEvenementLabo.tools
{
    public class TokenManager
    {

        public static string _secretKey = "nqdsjnjsqdnjsqnjjqsnj4jkjkjkjkjj5dqsopjkosdjklm6qsjiofqkjskdpq2isofqjkpdoqjdoisqn,dpqos";


        public string generateToken(User user)
        {
            //1. Generer la clé de signature

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //2. Données concernant le token et l'utilisateur
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name )

            };

            //Construire le token avec toute les infos utiles
            JwtSecurityToken jwt = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(1),
                issuer: "https://localhost:7213/",
                audience: "https://localhost:7020/"
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }
    }
}

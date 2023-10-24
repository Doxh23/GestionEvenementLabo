using GestionEvent_DAL.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionEvenementLabo.tools
{
    public class TokenManager
    {

        public static string _secretKey = "nqdsjnjsqdnjsqnjjqsnjqsdkjkjkjkjkjjdqsopjkosdjklmqsjiofqkjskdpqisofqjkpdoqjdoisqn,dpqos";


        public string generateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            Console.WriteLine(user.Role.Id);
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Id.ToString())
            };

            JwtSecurityToken jwt = new(claims : claims , signingCredentials : credentials , expires : DateTime.Now.AddDays(1) );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();


            return handler.WriteToken(jwt);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Model
{
    public class UserFormRegister
    {
        public int Id { get; set; }
        public string LoginEmail { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }


        public string LastName { get; set; }

        public string FirstName { get; set; }
        public string GSM { get; set; }
        public string NickName { get; set; }
        public string Allergie { get; set; }
        public string InfoSupp { get; set; }
    }
}

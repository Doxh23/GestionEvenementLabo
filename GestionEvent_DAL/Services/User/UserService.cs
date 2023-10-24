using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.User
{
    public class UserService : IUserRepository
    {
        private readonly UserDBService _userDBService;
        public UserService(SqlConnection sqlconn) {
        _userDBService = new UserDBService(sqlconn);

            
        }
        public List<Model.User> GetAll()
        {
            return _userDBService.GetAll();
        }

        public bool Register(UserFormRegister user)
        {

           return _userDBService.Register(user);

        }
        public Model.User Login(string Email,string Password)
        {

           return _userDBService.Login(Email,Password);
        }

    

        public Model.User GetById(int id)
        {
           return _userDBService.GetById(id);
        }

        public bool Delete(int id)
        {
            return _userDBService.Delete(id);
        }

     
    }
}

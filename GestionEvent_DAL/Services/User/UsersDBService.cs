using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using GestionEvent_DAL.tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.User
{
    public class UsersDBService : BaseRepository<Model.User>, IUserRepository
    {
        SqlConnection _connection;
       
        public UsersDBService(SqlConnection conn) : base(conn)
        {
            _connection = conn;
            _tableName = nameof(UsersDBService).Split(new string[] { "DB" }, StringSplitOptions.None)[0];
        }

       

        public List<Model.User> GetAll()
        {
          

            return SQLFonction.getList(_connection, $" select  u.Id, LoginEmail,r.Value as [role] ,LastName,FirstName,GSM,Nickname,Allergie,InfoSupp  from {_tableName} as u join [Role] as r on u.RoleId = r.Id",mapper).Cast<Model.User>().ToList();
        }


        public override Model.User GetById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };


            return SQLFonction.getOne(_connection, $"select  u.Id, LoginEmail,r.Value as [role] ,r.Id as RoleId ,LastName,FirstName,GSM,Nickname,Allergie,InfoSupp  from {_tableName} as u join [Role] as r on u.RoleId = r.Id where u.Id = @id", mapper, parameters);
        }
        public Model.User Login(string email, string password)
        {

            SqlParameter[] parameters = new SqlParameter[]
         {
                new SqlParameter("email", email),
                new SqlParameter("pwd", password)
         };


            return SQLFonction.getOne(_connection, $"UserLogin @email,@pwd", mapper, parameters);
        }

        public override bool Delete(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "delete from Users where Id = @id ; delete from Salt where Id = @Id";
                cmd.Parameters.AddWithValue("@id", id);
                _connection.Open();
                int row = cmd.ExecuteNonQuery();
                _connection.Close();
                if (row > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public bool Register(UserFormRegister user)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@InfoSupp", user.InfoSupp),
                    new SqlParameter("@role", user.Role),
                    new SqlParameter("@Allergie", user.LoginEmail),
                    new SqlParameter("@FirstName", user.FirstName),
                    new SqlParameter("@LastName", user.LastName),
                    new SqlParameter("@GSM", user.GSM),
                    new SqlParameter("@email", user.LoginEmail),
                    new SqlParameter("@NickName", user.NickName),
                    new SqlParameter("@pwd", user.Password)

                };

            return SQLFonction.AlterTable(_connection, "userRegister @pwd,@email,@role,@LastName,@FirstName,@GSM,@NickName,@Allergie,@InfoSupp",parameters);
        }
        public override Model.User mapper(SqlDataReader reader)
        {
            return new Model.User()
            {
                Id = (int)reader["Id"],
                InfoSupp = (string)reader["InfoSupp"],
                Allergie = (string)reader["Allergie"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                GSM = (string)reader["GSM"],
                LoginEmail = (string)reader["LoginEmail"],
                NickName = (string)reader["NickName"],
                Role = new Model.Role() { Id = (int)reader["RoleId"], Name = (string)reader["role"] }

                //Role = (string)reader["RoleId"], // a changer
                //Salt = (string)reader["SaltId"], //a changer
            };
        }



   
    }
}

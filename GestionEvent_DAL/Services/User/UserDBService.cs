using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.User
{
    public class UserDBService : BaseRepository<Model.User>, IUserRepository
    {
        SqlConnection _connection;
        protected override string _tableName
        {
            get
            {
                return "Users";
            }
        }
        public UserDBService(SqlConnection conn) : base(conn)
        {
            _connection = conn;
        }

       

        public List<Model.User> GetAll()
        {
            List<Model.User> list = new List<Model.User>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = " select  u.Id, LoginEmail,r.Value as [role] ,LastName,FirstName,GSM,Nickname,Allergie,InfoSupp  from Users as u join [Role] as r on u.RoleId = r.Id";


                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(mapper(reader));

                    }
                }
                _connection.Close();
            }
            return list;
        }


        public override Model.User GetById(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = " select  u.Id, LoginEmail,r.Value as [role] ,r.Id as RoleId ,LastName,FirstName,GSM,Nickname,Allergie,InfoSupp  from Users as u join [Role] as r on u.RoleId = r.Id where u.Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                _connection.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if(r.Read())
                    {
                        return mapper(r);
                    }
                }
                return null;
            }

        }
        public Model.User Login(string email, string password)
        {
            Model.User u = new Model.User();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "UserLogin @email,@pwd";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pwd", password);

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return mapper(reader);
                }
                _connection.Close();






                return null;
            }
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
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "userRegister @pwd,@email,@role,@LastName,@FirstName,@GSM,NickName,@Allergie,@InfoSupp";

                cmd.Parameters.AddWithValue("@InfoSupp", user.InfoSupp);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@Allergie", user.LoginEmail);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@GSM", user.GSM);
                cmd.Parameters.AddWithValue("@email", user.LoginEmail);
                cmd.Parameters.AddWithValue("@NickName", user.NickName);
                cmd.Parameters.AddWithValue("@pwd", user.Password);



                _connection.Open();
                int row;
               
                    row = (int)cmd.ExecuteNonQuery();

                
               
                _connection.Close();
                if (row > 1)
                {
                    return true;
                }
                return false;
            }
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
                Role = new Model.Role() { Id = (int)reader["RoleId"], Name = (string)reader["role"] }//TODO A CHANGER

                //Role = (string)reader["RoleId"], // a changer
                //Salt = (string)reader["SaltId"], //a changer
            };
        }



   
    }
}

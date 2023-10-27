using GestionEvent_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.Comments
{
    public class CommentsDBService : BaseRepository<Model.Comments>
    {
        public CommentsDBService(SqlConnection sqlconn) : base(sqlconn)
        {
        }

        protected override string _tableName
        {
            get
            {
                return "Comments";
            }
        }

        public bool AddComment(Model.Comments comment)
        {
            List<Model.Comments> list = new List<Model.Comments>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "insert into Comments values(@content,@PostDate,@UserId,@EventId)";
                cmd.Parameters.AddWithValue("content", comment.content);
                cmd.Parameters.AddWithValue("PostDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UserId", comment.UserId);
                cmd.Parameters.AddWithValue("EventId", comment.EventId);
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

        public override List<Model.Comments> GetAll()
        {
            List<Model.Comments> list = new List<Model.Comments>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select c.Id as IdC,Content, PostDate , UserId from Comments as c join Users as u on u.Id = c.UserId ";
                _connection.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(mapper(r));
                    }
                }
                _connection.Close();
                return list;
            }
        }
        public List<Model.Comments> getByEvent(int id)
        {
            List<Model.Comments> list = new List<Model.Comments>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"select c.Id as IdC,Content, PostDate ,EventId, UserId from {_tableName} as c join Users as u on u.Id = c.UserId where EventId = @id";
                cmd.Parameters.AddWithValue("id", id);
                _connection.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(mapper(r));
                    }
                }
                _connection.Close();
                return list;
            }
        }

        public override Model.Comments GetById(int id)
        {
            Model.Comments comments = default(Model.Comments);
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"select c.Id as IdC,Content, PostDate,EventId, UserId from {_tableName} as c join Users as u on u.Id = c.UserId";
                cmd.Parameters.AddWithValue("id", id);
                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comments = mapper(reader);
                    }
                }
                _connection.Close();
            }
            return comments;
        }

        public override Model.Comments mapper(SqlDataReader reader)
        {
            return new Model.Comments()
            {
                content = (string)reader["Content"],
                UserId = (int)reader["UserId"],
                EventId = (int)reader["EventId"],
                Id = (int)reader["IdC"],
                PostDate = ((DateTime)reader["PostDate"]).ToString("d")

            };
        }
    }
}

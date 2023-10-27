using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using GestionEvent_DAL.tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionEvent_DAL.Services.Comments
{
    public class CommentsDBService : BaseRepository<Model.Comments>, ICommentsRepository
    {
        public CommentsDBService(SqlConnection sqlconn) : base(sqlconn)
        {
        }

     

        public bool AddComment(Model.Comments comment)
        {

            SqlParameter[] parameter = new SqlParameter[]
            {
                 new SqlParameter("content", comment.content),
                new SqlParameter("PostDate", DateTime.Now),
                new SqlParameter("UserId", comment.UserId),
                new SqlParameter("EventId", comment.EventId),
             };


            return SQLFonction.AlterTable(_connection, "insert into Comments values(@content, @PostDate, @UserId, @EventId)", parameter);
        }

        public override List<Model.Comments> GetAll()
        {

            return SQLFonction.getList(_connection, "select c.Id as IdC, Content, PostDate,Nickname, UserId,EventId from Comments as c join Users as u on u.Id = c.UserId order by PostDate", mapper).Cast<Model.Comments>().ToList();
        }
        public List<Model.Comments> getByEvent(int id)
        {

            SqlParameter[] parameter = new SqlParameter[1]
            {
                new SqlParameter("id",id)
            };
            return SQLFonction.getList(_connection, $"select c.Id as IdC,Content, PostDate ,EventId,UserId, Nickname from {_tableName} as c join Users as u on u.Id = c.UserId where EventId = @id order by PostDate", mapper, parameter).Cast<Model.Comments>().ToList();
        }

        public override Model.Comments GetById(int id)
        {
            SqlParameter[] parameter = new SqlParameter[1]
          {
                new SqlParameter("id",id)
          };


            return SQLFonction.getOne(_connection, $"select c.Id as IdC,Content,Nickname, PostDate,EventId, UserId from {_tableName} as c join Users as u on u.Id = c.UserId", mapper, parameter);
        }

        public override Model.Comments mapper(SqlDataReader reader)
        {
            return new Model.Comments()
            {
                content = (string)reader["Content"],
                UserId = (int)reader["UserId"],
                NickName = (string)reader["Nickname"],
                EventId = (int)reader["EventId"],
                Id = (int)reader["IdC"],
                PostDate = ((DateTime)reader["PostDate"]).ToString("d")

            };
        }
    }
}

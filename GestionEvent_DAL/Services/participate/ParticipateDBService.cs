using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using GestionEvent_DAL.tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.participate
{
    public class ParticipateDBService : BaseRepository<Participate>, IParticipate
    {
        public ParticipateDBService(SqlConnection sqlconn) : base(sqlconn)
        {
        }

     

        public bool addParticipate(Participate participate)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("cosplayerId",participate.Id) ,
            new SqlParameter("eventId", participate.EventId),
            new SqlParameter("date", participate.Date),
            new SqlParameter("presence", participate.Presence)
            };



            return SQLFonction.AlterTable(_connection, $"insert into {_tableName} values(@cosplayerId,@eventId,@date,@presence)", parameters);
        }

        public List<Participate> GetByEvent(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("id", id),
            };


            return SQLFonction.getList(_connection, $"Select p.* , u.Nickname from  Participate as p join Users as u on u.Id = p.CosplayerId  where  EventId = @id", mapper, parameters).Cast<Participate>().ToList();
        }

        public override Participate mapper(SqlDataReader reader)
        {
            return new Participate()
            {
                Id = (int)reader["CosplayerId"],
                EventId = (int)reader["EventId"],
                Date = ((DateTime)reader["date"]).ToString("d"),
                Nickname = (string)reader["Nickname"],
                Presence = (string)reader["Presence"]
            };
        }
    }
}

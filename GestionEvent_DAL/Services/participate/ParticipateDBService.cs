using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.participate
{
    public class ParticipateDBService : BaseRepository<Participate> , IParticipate
    {
        public ParticipateDBService(SqlConnection sqlconn) : base(sqlconn)
        {
        }

        protected override string _tableName
        {
            get
            {
                return "Participate";
            }
        }

        public bool addParticipate(Participate participate)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"insert into {_tableName} values(@cosplayerId,@eventId,@date,@presence)";
                cmd.Parameters.AddWithValue("cosplayerId",participate.Id) ;
                cmd.Parameters.AddWithValue("eventId",participate.EventId) ;
                cmd.Parameters.AddWithValue("date", participate.Date);
                cmd.Parameters.AddWithValue("presence",participate.Presence) ;

                _connection.Open();
               int row = cmd.ExecuteNonQuery();
                _connection.Close();

                if(row > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public override Participate mapper(SqlDataReader reader)
        {
            return new Participate()
            {
                // TODDO
            };
        }
    }
}

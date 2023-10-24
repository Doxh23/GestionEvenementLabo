using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.Status
{
    public class statusDBService : BaseRepository<Model.Status>
    {

        public statusDBService(SqlConnection sqlconn) : base(sqlconn)
        {
        }

        protected override string _tableName
        {
            get
            {
                return "Status";
            }
        }

        public override Model.Status mapper(SqlDataReader reader)
        {
            return new Model.Status()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
               

            };

        }
    }
}

using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.Role
{
    internal class RoleDBService : BaseRepository<Model.Role>
    {
        public RoleDBService(SqlConnection sqlconn) : base(sqlconn)
        {
        }

  

        public override Model.Role mapper(SqlDataReader reader)
        {
            return new Model.Role()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Value"],
            };
        }
    }
}

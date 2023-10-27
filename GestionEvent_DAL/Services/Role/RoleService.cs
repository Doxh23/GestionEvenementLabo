using GestionEvent_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.Role
{
    public class RoleService : IRole
    {
        private RoleDBService _roleDBService;
        public RoleService(SqlConnection conn)
        {
            _roleDBService = new RoleDBService(conn);
        }
        public bool Delete(int id)
        {
           return _roleDBService.Delete(id);
        }

        public List<Model.Role> GetAll()
        {
            return _roleDBService.GetAll();
        }

        public Model.Role GetById(int id)
        {
           return _roleDBService.GetById(id);
        }
    }
}

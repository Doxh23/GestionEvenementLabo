using GestionEvent_DAL.Model;
using GestionEvent_DAL.Services.Event;
using GestionEvent_DAL.Services.Status;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services
{
    public class StatusService
    {

        private readonly statusDBService _StatusDBservice;
        public StatusService(SqlConnection sqlconn)
        {
            _StatusDBservice = new statusDBService(sqlconn);
        }
        public bool Delete(int id)
        {
            return _StatusDBservice.Delete(id);
        }

        public List<Model.Status> GetAll()
        {
            return _StatusDBservice.GetAll();
        }

        public Model.Status GetById(int id)
        {
            return _StatusDBservice.GetById(id);
        }
    }
}

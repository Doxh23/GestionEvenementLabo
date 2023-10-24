using GestionEvent_DAL.Model;
using GestionEvent_DAL.Services.Event;
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

        private readonly EventDBservice _StatusDBservice;
        public StatusService(SqlConnection sqlconn)
        {
            _StatusDBservice = new EventDBservice(sqlconn);
        }
        public bool Delete(int id)
        {
            return _StatusDBservice.Delete(id);
        }

        public List<Model.Event> GetAll()
        {
            return _StatusDBservice.GetAll();
        }

        public Model.Event GetById(int id)
        {
            return _StatusDBservice.GetById(id);
        }
    }
}

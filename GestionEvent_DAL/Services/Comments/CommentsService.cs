using GestionEvent_DAL.Interface;
using GestionEvent_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Services.Comments
{
    public class CommentService : ICommentsRepository
    {
        private readonly CommentsDBService _commentDBService;
        public CommentService(SqlConnection conn)
        {
            _commentDBService = new CommentsDBService(conn);
        }
        public bool AddComment(Model.Comments comment)
        {
            return _commentDBService.AddComment(comment);
        }

        public bool Delete(int id)
        {
            return _commentDBService.Delete(id);
        }

        public List<Model.Comments> getByEvent(int id)
        {
            return _commentDBService.getByEvent(id);
        }

        public List<Model.Comments> GetAll()
        {
            return _commentDBService.GetAll();
        }

        public Model.Comments GetById(int id)
        {
            return _commentDBService.GetById(id);
        }
    }
}
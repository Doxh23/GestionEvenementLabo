using GestionEvent_DAL.Interface;
using System.Collections.Generic;

namespace GestionEvent_DAL.Services.Comments
{
    public interface ICommentsRepository : IBaseRepository<Model.Comments>
    {
        bool AddComment(Model.Comments comment);
        List<Model.Comments> getByEvent(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEvent_DAL.Interface
{
      public interface IBaseRepository<T> 
    {
        List<T>  GetAll();
        T GetById(int id);
        
        bool Delete(int id);




        
    }
}

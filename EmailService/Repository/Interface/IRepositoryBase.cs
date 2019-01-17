using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Repository.Interface
{
    interface IRepositoryBase<T>
    {
        List<T> GetByID(int ID);
        int Save(T entity);
        bool Update(T entity);
        bool DeleteByID(T entity);
        
    }
}

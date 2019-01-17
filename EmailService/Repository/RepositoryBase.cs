using EmailService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        public bool DeleteByID(T entity)
        {
            throw new NotImplementedException();
        }
        public List<T> GetByID(int ID)
        {
            throw new NotImplementedException();
        }
        public int Save(T entity)
        {
            throw new NotImplementedException();
        }
        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

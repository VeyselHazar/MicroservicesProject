using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AuthServer.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Core.Repositories
{
    public interface IUserRepository
    {
        void Delete(Tbl_Users p);
        void Insert(Tbl_Users p);
        void Update(Tbl_Users p);
        Task<Tbl_Users> GetSingleAsync(Expression<Func<Tbl_Users, bool>> predicate);
        Tbl_Users Get(Expression<Func<Tbl_Users, bool>> filter);
        Task<Tbl_Users> GetAsync(Expression<Func<Tbl_Users, bool>> filter);
        List<Tbl_Users> List();
        Task<List<Tbl_Users>> ListAsync(Expression<Func<Tbl_Users, bool>> filter);
        List<Tbl_Users> List(Expression<Func<Tbl_Users, bool>> filter);

    }
    public class UserRepository:IUserRepository
    {
        private readonly DbContext c;
        DbSet<Tbl_Users> _object;

        public UserRepository(DbContext appDbContext)
        {
            c = appDbContext;
            _object = c.Set<Tbl_Users>();

        }

        public async Task<Tbl_Users> GetSingleAsync(Expression<Func<Tbl_Users, bool>> predicate)
        {
            return await _object.SingleOrDefaultAsync(predicate);
        }


        public void Delete(Tbl_Users p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Tbl_Users Get(Expression<Func<Tbl_Users, bool>> filter)
        {
            
            throw new NotImplementedException();

            
        }
      
        public async Task<Tbl_Users> GetAsync(Expression<Func<Tbl_Users, bool>> filter)
        {
            return await _object.FindAsync(filter);
        }

        public void Insert(Tbl_Users p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Tbl_Users> List()
        {
            return _object.ToList();
        }

        public Task<List<Tbl_Users>> ListAsync(Expression<Func<Tbl_Users, bool>> filter)
        {
            return _object.ToListAsync();
        }

        public List<Tbl_Users> List(Expression<Func<Tbl_Users, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Tbl_Users p)
        {
            c.SaveChanges();
        }
    }
}



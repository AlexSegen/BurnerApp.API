using BurnerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnerApp.Data.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(int Id);
        Task<User?> CreateOrUpdate(User user);
        Task<bool> Delete(int id);
    }
}

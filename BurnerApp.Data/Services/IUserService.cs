using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnerApp.Data.Services
{
    public interface IUserService
    {
        Task<Response<List<User>>> GetAll();
        Task<Response<User?>> GetById(int Id);
        Task<Response<User?>> CreateOrUpdate(User user);
        Task<Response<bool>> Delete(int id);
    }
}

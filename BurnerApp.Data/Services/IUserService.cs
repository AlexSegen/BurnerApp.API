using BurnerApp.API.Models;
using BurnerApp.Model;

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

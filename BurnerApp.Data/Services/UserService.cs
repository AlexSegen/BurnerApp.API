using BurnerApp.API.PostgreSQL.Models;
using BurnerApp.Data.Repository;
using BurnerApp.Model;

namespace BurnerApp.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<Response<User?>> CreateOrUpdate(User user)
        {
            try
            {
                var result = await _userRepository.CreateOrUpdate(user);
                return new Response<User?>(result, "User has been created", 201);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<List<User>>> GetAll()
        {
            try
            {
                var result = await _userRepository.GetAll();

                return new Response<List<User>>(result, "Listing all users.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<User?>> GetById(int Id)
        {
            try
            {
                var result = await _userRepository.GetById(Id);

                if (result == null)
                    return new Response<User?>($"User not found with id {Id}", 404);

                return new Response<User?>(result, "User details.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<bool>> Delete(int Id)
        {
            try
            {
                var existing = await _userRepository.GetById(Id);

                if (existing == null)
                    return new Response<bool>(false, $"User not found with id {Id}.", 404);

                var result = await _userRepository.Delete(Id);

                if (!result)
                    return new Response<bool>($"There was a problem deleting the user with id {Id}.", 500);

                return new Response<bool>(result, "User has been deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

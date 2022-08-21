using BurnerApp.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnerApp.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private PostgreSQLConfiguration _configuration;
        public UserRepository(PostgreSQLConfiguration configuration) => _configuration = configuration;
        
        protected NpgsqlConnection dbConnection() => new NpgsqlConnection(_configuration._connectionString);

        public Task<bool> Create(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

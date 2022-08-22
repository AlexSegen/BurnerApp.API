using BurnerApp.Model;
using Dapper;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnerApp.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private PostgreSQLConfiguration _configuration;
        public UserRepository(PostgreSQLConfiguration configuration) => _configuration = configuration;
        protected NpgsqlConnection DbConnection() => new(_configuration._connectionString);

        public async Task<User?> CreateOrUpdate(User user)
        {
            try
            {
                using var db = DbConnection();
                var result = new User();

                var dbResult = db.Query<string>("fn_set_user", new { 
                    userid = user.Id,
                    iname = user.Name,
                    iusername = user.Username,
                    iemail = user.Email,
                    iphone = user.Phone,
                    iwebsite = user.Website
                },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (dbResult != null)
                    result = JsonConvert.DeserializeObject<User>(dbResult);

                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                using var db = DbConnection();

                var result = new List<User>();
                var dbResult = db.Query<string>("fn_get_users", null,
                commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (dbResult != null)
                    result = JsonConvert.DeserializeObject<List<User>>(dbResult);

                return result ?? new List<User>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User?> GetById(int id)
        {
            try
            {
                using var db = DbConnection();
                var result = new User();

                var dbResult = db.Query<string>("fn_get_user_by_id", new { userid = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (dbResult != null)
                    result = JsonConvert.DeserializeObject<User>(dbResult);

                return result?.Id > 0 ? result : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public async Task<bool> Delete(int id)
        {
            try
            {
                using var db = DbConnection();

                var dbResult = db.Query<string>("fn_delete_user_by_id", new { userid = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();

                return !String.IsNullOrEmpty(dbResult) && dbResult == "True";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

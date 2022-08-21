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

        #region old

        private async Task<bool> Delete2(int id)
        {
            try
            {
                var db = DbConnection();

                var sql = @"
                            DELETE
                            FROM public.""users""
                            WHERE id = @Id
                          ";

                var result = await db.ExecuteAsync(sql, new
                {
                    Id = id
                });

                return result > 0;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> Create2(User user)
        {
            try
            {
                var db = DbConnection();

                var sql = @"
                            INSERT INTO public.""users"" (name,username,email,phone,website) 
                            VALUES (@Name,@Username,@Email,@Phone,@Website);
                          ";
                var result = await db.ExecuteAsync(sql, new
                {
                    user.Name,
                    user.Username,
                    user.Email,
                    user.Phone,
                    user.Website
                });

                return result > 0;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> Update2(User user)
        {
            try
            {
                var db = DbConnection();

                var sql = @"
                            UPDATE public.""users""
                            SET 
                                name = @name,
                                username = @Username,
                                email = @Email,
                                phone = @Phone,
                                website = @Website
                            WHERE id = @Id
                          ";

                var result = await db.ExecuteAsync(sql, new
                {
                    user.Id,
                    user.Name,
                    user.Username,
                    user.Email,
                    user.Phone,
                    user.Website
                });

                return result > 0;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private async Task<IEnumerable<User>> GetAll2()
        {
            try
            {
                var db = DbConnection();

                var sql = @"
                            SELECT id, name, username, email, phone, website
                            FROM public.""users""
                          ";
                return await db.QueryAsync<User>(sql, new { });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private async Task<User> GetById2(int id)
        {
            try
            {
                var db = DbConnection();

                var sql = @"
                            SELECT id, name, username, email, phone, website
                            FROM public.""users""
                            WHERE id = @Id
                          ";
                return await db.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

    }
}

using BurnerApp.Model;
using Dapper;
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
        protected NpgsqlConnection DbConnection() => new(_configuration._connectionString);

        public async Task<bool> Create(User user)
        {
            try
            {
                var db = DbConnection();

                var sql = @"
                            INSERT INTO public.""users"" (name,username,email,phone,website) 
                            VALUES (@Name,@Username,@Email,@Phone,@Website);
                          ";
                var result = await db.ExecuteAsync(sql, new { 
                   user.Username, user.Email, user.Phone, user.Website
                });

                return result > 0;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<User>> GetAll()
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
        public async Task<User> GetById(int id)
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
        public async Task<bool> Update(User user)
        {
            try
            {
                var db = DbConnection();

                var sql = @"
                            UPDATE INTO public.""users"" (name,username,email,phone,website)
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
        public async Task<bool> Delete(User user)
        {
            try
            {
                var db = DbConnection();

                var sql = @"
                            DELETE
                            FROM public.""users"" (name,username,email,phone,website)
                            WHERE id = @Id
                          ";

                var result = await db.ExecuteAsync(sql, new
                {
                    user.Id
                });

                return result > 0;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

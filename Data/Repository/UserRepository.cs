using Dapper;
using Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }
        
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

       
        public async Task<User> FindUserByIdAsync(Guid ID_User)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"select * from Users where ID_User = @ID_User";
                    return await dbConnection.QueryFirstOrDefaultAsync<User>(query, new { ID_User = ID_User });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Users";
                    return await dbConnection.QueryAsync<User>(query);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
       
        public void AddUserAsync(User user)
        {
            try
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO Users(FirstName, LastName, PhoneNumber, Email) VALUES(@FirstName, @LastName, @PhoneNumber, @Email)";
                    dbConnection.Execute(query,user);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateUserAsync(User user)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE Users SET FirstName=@FirstName, LastName=@LastName, PhoneNumber=@PhoneNumber, Email=@Email where ID_User=@ID_User";
                    dbConnection.Execute(query, user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUserAsync(Guid ID_User)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM Users WHERE ID_User = @ID_User";
                    dbConnection.Execute(query, new { ID_User = ID_User });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

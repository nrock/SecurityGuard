using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NHibernate.Linq;

namespace AspNet.Identity.NHibernate
{
    /// <summary>
    ///     Class UserStore.
    /// </summary>
    /// <typeparam name="TUser">The type of the t user.</typeparam>
    public class UserStore<TUser> : IUserLoginStore<TUser>, IUserClaimStore<TUser>, IUserRoleStore<TUser>,
        IUserPasswordStore<TUser>, IUserSecurityStampStore<TUser>, IUserStore<TUser>, IUserEmailStore<TUser> , IQueryableUserStore<TUser> 
        where TUser : IdentityUser
    {

        IQueryable<TUser> IQueryableUserStore<TUser, string>.Users
        {
            get
            {
                var users = new List<TUser>();
                //users.Add(new TUser { Email = "a@a.com", UserName = "a" });
                //users.Add(new TUser { Email = "a@a.com", UserName = "a" });
                //users.Add(new TUser { Email = "a@a.com", UserName = "a" });
                var user = new IdentityUser();
                user.Email = "a@a.com";
                user.UserName = "a";
                users.Add(user.As<TUser>());

                return users.AsQueryable<TUser>();

            }
        }

        #region Private Methods & Variables
         
        /// <summary>
        ///     The _disposed
        /// </summary>
        private bool _disposed;


        private const string tableName = "AspNetUser";


        //private MongoDatabase GetDatabaseFromSqlStyle(string connectionString)
        //{
        //    var conString = new MongoConnectionStringBuilder(connectionString);
        //    MongoClientSettings settings = MongoClientSettings.FromConnectionStringBuilder(conString);
        //    MongoServer server = new MongoClient(settings).GetServer();
        //    if (conString.DatabaseName == null)
        //    {
        //        throw new Exception("No database name specified in connection string");
        //    }
        //    return server.GetDatabase(conString.DatabaseName);
        //}

        //private MongoDatabase GetDatabaseFromUrl(MongoUrl url)
        //{
        //    var client = new MongoClient(url);
        //    MongoServer server = client.GetServer();
        //    if (url.DatabaseName == null)
        //    {
        //        throw new Exception("No database name specified in connection string");
        //    }
        //    return server.GetDatabase(url.DatabaseName); // WriteConcern defaulted to Acknowledged
        //}


        //private MongoDatabase GetDatabase(string connectionString, string dbName)
        //{
        //    var client = new MongoClient(connectionString);
        //    MongoServer server = client.GetServer();
        //    return server.GetDatabase(dbName);
        //}

        #endregion

        #region Constructors
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="UserStore{TUser}" /> class. Uses DefaultConnection name if none was
        ///     specified.
        /// </summary>
        public UserStore()
            : this("ApplicationConnectionString")
        {
        }


        public UserStore(string connectionNameOrUrl)
        {
            //string connStringFromManager = string.Empty;
            //if (ConfigurationManager.ConnectionStrings[connectionNameOrUrl] != null)
            //{
            //    connStringFromManager = ConfigurationManager.ConnectionStrings[connectionNameOrUrl].ConnectionString;
            //}
            //else if (ConfigurationManager.AppSettings[connectionNameOrUrl] != null)
            //{
            //    connStringFromManager = ConfigurationManager.AppSettings[connectionNameOrUrl];
            //}
            //db = GetDatabaseFromSqlStyle(connStringFromManager);
        }


        //public UserStore(MongoDatabase mongoDatabase)
        //{
        //    db = mongoDatabase;
        //}

         
        //[Obsolete("Use UserStore(connectionNameOrUrl)")]
        //public UserStore(string connectionName, bool useMongoUrlFormat)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        //    if (useMongoUrlFormat)
        //    {
        //        var url = new MongoUrl(connectionString);
        //        db = GetDatabaseFromUrl(url);
        //    }
        //    else
        //    {
        //        db = GetDatabaseFromSqlStyle(connectionString);
        //    }
        //}

        #endregion

        #region Methods

        /// <summary>
        ///     Adds the claim asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="claim">The claim.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task AddClaimAsync(TUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the claims asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task{IList{Claim}}.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Removes the claim asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="claim">The claim.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task RemoveClaimAsync(TUser user, Claim claim)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     Creates the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task CreateAsync(TUser user)
        {
            throw new NotImplementedException("not yet implemented ");
        }

        /// <summary>
        ///     Deletes the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Finds the by identifier asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Task{`0}.</returns>
        public Task<TUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Finds the by name asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>Task{`0}.</returns>
        public Task<TUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Updates the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
        }

        /// <summary>
        ///     Adds the login asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="login">The login.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Finds the user asynchronous.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>Task{`0}.</returns>
        public Task<TUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the logins asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task{IList{UserLoginInfo}}.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Removes the login asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="login">The login.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the password hash asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task{System.String}.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task<string> GetPasswordHashAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Determines whether [has password asynchronous] [the specified user].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task<bool> HasPasswordAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Sets the password hash asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Adds to role asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="role">The role.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task AddToRoleAsync(TUser user, string role)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the roles asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task{IList{System.String}}.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task<IList<string>> GetRolesAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Determines whether [is in role asynchronous] [the specified user].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="role">The role.</param>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task<bool> IsInRoleAsync(TUser user, string role)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Removes from role asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="role">The role.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task RemoveFromRoleAsync(TUser user, string role)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the security stamp asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task{System.String}.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task<string> GetSecurityStampAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Sets the security stamp asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="stamp">The stamp.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task SetSecurityStampAsync(TUser user, string stamp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Throws if disposed.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException"></exception>
        private void ThrowIfDisposed()
        {
            throw new NotImplementedException();
        }

        #endregion


        public Task<TUser> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
         
        public Task<string> GetEmailAsync(TUser user)
        {
            throw new NotImplementedException(); 
        }

        public Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(TUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }
         
         
    }
}
        
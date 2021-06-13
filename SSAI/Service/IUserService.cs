using SSAI.Entity.DB;
using SSAI.Model.Request;
using SSAI.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Service
{
    /// <summary>
    /// Service for manage user authentication
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method for authenticate a user
        /// </summary>
        /// <param name="model">
        /// Object where you can set username and password
        /// </param>
        /// <returns>
        /// The method returns an object that contains user info and JWT token.
        /// </returns>
        AuthenticateResponse Authenticate(AuthenticateRequest model);


        /// <summary>
        /// Get a user by its id
        /// </summary>
        /// <param name="id">
        /// id of user that you want retrieve
        /// </param>
        /// <returns>
        /// The method returns the user.
        /// </returns>
        User GetById(int id);
    }
}

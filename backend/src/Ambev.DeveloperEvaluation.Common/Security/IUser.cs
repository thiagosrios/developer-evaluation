namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Sets the interface for user representation on the system
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Returns the user identifier 
        /// </summary>
        /// <returns>The identifier as a string</returns>
        public string Id { get; }

        /// <summary>
        /// Returns the username/alias of the user
        /// </summary>
        /// <returns>Username</returns>
        public string Username { get; }

        /// <summary>
        /// Returns the role of the user
        /// </summary>
        /// <returns>Role</returns>
        public string Role { get; }
    }
}

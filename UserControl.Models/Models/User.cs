using System;
using System.Collections.Generic;

namespace UserControl.Models.Models
{
    /// <summary>
    /// User model.
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Unique identifier of the current user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Email address of the current user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Name of the current user in a simplified format.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date of birth of the current user.
        /// </summary>
        public DateTime DateBirthday { get; set; }

        /// <summary>
        /// List of current user roles. A user can have multiple roles at the
        /// same time.
        /// </summary>
        public List<Role> Roles { get; set; }

        /// <summary>
        /// Method that defines data about an object without access to
        /// properties.
        /// </summary>
        public override string ToString()
        {
            return $"{Name} {DateBirthday} {Email}";
        }
    }
}

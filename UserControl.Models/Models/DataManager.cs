using System;
using System.Collections.Generic;

namespace UserControl.Models.Models
{
    /// <summary>
    /// Fills collections with fictional data. Required during application
    /// debugging stages.
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Returns a collection of users.
        /// </summary>
        /// <returns>Collection of users</returns>
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    DateBirthday = new DateTime(1993, 8, 12),
                    Name = "Vasja",
                    Email = "vasja@mathart.com"
                },
                new User
                {
                    Id = 2,
                    DateBirthday = new DateTime(1990, 4, 21),
                    Name = "Petro",
                    Email = "petro@mathart.com"
                },
                new User
                {
                    Id = 3,
                    DateBirthday = new DateTime(1989, 3, 2),
                    Name = "Vanja",
                    Email = "vanja@mathart.com"
                },
                new User
                {
                    Id = 4,
                    DateBirthday = new DateTime(1988, 1, 23),
                    Name = "Manja",
                    Email = "manja@mathart.com"
                },
                new User
                {
                    Id = 12,
                    DateBirthday = new DateTime(1994, 11, 13),
                    Name = "Dasha",
                    Email = "dasha@mathart.com"
                },
                new User
                {
                    Id = 13,
                    DateBirthday = new DateTime(1993, 12, 17),
                    Name = "Luba",
                    Email = "luba@mathart.com"
                },
                new User
                {
                    Id = 7,
                    DateBirthday = new DateTime(1991, 4, 1),
                    Name = "Luda",
                    Email = "luda@mathart.com"
                }
            };
        }

        /// <summary>
        /// Returns a collection of roles.
        /// </summary>
        /// <returns>Collection of roles</returns>
        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Administrator"
                },
                new Role
                {
                    Id = 2,
                    Name = "Manager"
                },
                new Role
                {
                    Id = 3,
                    Name = "Programmer"
                },
                new Role
                {
                    Id = 4,
                    Name = "Admin"
                }
            };
        }
    }
}

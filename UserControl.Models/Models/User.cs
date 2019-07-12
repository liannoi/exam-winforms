// Copyright 2019 Maksym Liannoi
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


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

using System;
using System.Collections.Generic;

namespace UserControl.Models.Models
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime DateBirthday { get; set; }
        public List<Role> Roles { get; set; }

        public override string ToString()
        {
            return $"{ Name } { DateBirthday } { Email }";
        }
    }
}

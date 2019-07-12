using System;

namespace UserControl.Models.Models
{
    [Serializable]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
